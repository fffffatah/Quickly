using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EntityLayer.Models.User;
using LogicLayer.DbServices;
using LogicLayer.EmailServices;
using LogicLayer.MiscServices;
using LogicLayer.StorageServices;


namespace Quickly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("register")]
        public ActionResult Register([FromForm]UserRegistrationModel user)
        {
            user.UserType = "user";
            user.IsVerified = false;
            if(user.ProfileImage == null)
            {
                user.ProfileImage = new GenerateImage().GenerateNewImage(user.FullName[0].ToString(), 480, 480, 250);
            }
            user.ProfileImageUrl = new BlobService().UploadFileToBlob(Guid.NewGuid().ToString(), user.ProfileImage);
            if (UserService.Add(user))
            {
                var tempUser=UserService.GetByEmail(user.Email);
                string url = Environment.GetEnvironmentVariable("REACT_EMAIL_VERIFICATION_URL")+"?id="+tempUser.Id.ToString();
                new SendgridService().Send("info@quickly.com", "Quickly", user.Email, user.FullName, "Quickly Account Verification", "Confirmation Email for Your Quickly Account", "<strong>Confirm Your Email Address: <u><a href=" + url + " target=\"_blank\">Click Here</a></u></strong>");
                return Ok(new { Message = "Registration Successful" });
            }
            return BadRequest(new { Message = "Registration Failed" });
        }

        [HttpPost]
        [Route("verify")]
        public ActionResult Verify(long id)
        {
            if (UserService.Verify(id))
            {
                return Ok(new { Message = "Verification Successful" });
            }
            return BadRequest(new { Message = "Verification Failed" });
        }

        [HttpGet]
        [Route("all/users")]
        public ActionResult<List<UserModel>> Get()
        {
            return UserService.Get();
        }
    }
}
