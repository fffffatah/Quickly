using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EntityLayer.Models.User;
using LogicLayer.DbServices;
using LogicLayer.EmailServices;
using LogicLayer.MiscServices;
using LogicLayer.StorageServices;
using LogicLayer.AuthServices;
using System.ComponentModel.DataAnnotations;

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
                string url = "http://localhost:3000/verify/" + tempUser.Id.ToString();
                new SendgridService().Send("info@quickly.com", "Quickly", user.Email, user.FullName, "Quickly Account Verification", "Confirmation Email for Your Quickly Account", "<strong>Confirm Your Email Address: <u><a href=" + url + " target=\"_blank\">Click Here</a></u></strong>");
                return Ok(new { Message = "Registration Successful" });
            }
            return BadRequest(new { Message = "Registration Failed" });
        }

        [HttpPost]
        [Route("update")]
        public ActionResult Update([FromHeader][Required] string TOKEN, [FromForm] UserUpdateModel userUpdateModel)
        {
            long id = new IdFromTokenService().GetId(TOKEN);
            if(id == -1)
            {
                return Unauthorized(new { Message = "User Unauthorized, Please Login" });
            }
            var user = UserService.GetById(id);
            if (userUpdateModel.ProfileImage != null)
            {
                userUpdateModel.ProfileImageUrl = new BlobService().UploadFileToBlob(Guid.NewGuid().ToString(), userUpdateModel.ProfileImage);
            }
            if (UserService.Update(userUpdateModel, id))
            {
                return Ok(new { Message = "User Update Successful" });
            }
            return BadRequest(new { Message = "User Update Failed" });
        }

        [HttpGet]
        [Route("send/otp")]
        public ActionResult SendOtp(string email)
        {
            var tempUser = UserService.GetByEmail(email);
            if(tempUser != null)
            {
                string otp = new Random().Next(111111, 999999).ToString();
                new SendgridService().Send("info@quickly.com", "Quickly", tempUser.Email, tempUser.FullName, "Quickly OTP", "Your Quickly OTP", "<strong>OTP: " + otp + "</strong>");
                var myotp = new UserOtpModel();
                myotp.Otp1 = otp;
                myotp.UserId = tempUser.Id;
                OtpService.Add(myotp);
                return Ok(new { Message = "OTP Sent" });
            }
            return NotFound(new { Message = "User Not Found" });
        }

        [HttpGet]
        [Route("get/token/by/otp")]
        public ActionResult GetTokenByOtp(string otp)
        {
            var tempotp = OtpService.GetByOtp(otp);
            if(tempotp != null)
            {
                var myClaims = new Dictionary<string, string>();
                myClaims.Add("Id", tempotp.UserId.ToString());
                OtpService.Delete(tempotp.Id);
                return Ok(new { Message = "OTP Verified", ResetToken = new TokenService(5).GenerateJsonWebToken(myClaims) });
            }
            return BadRequest(new { Message = "Invalid OTP" });
        }

        [HttpPost]
        [Route("reset/pass")]
        public ActionResult ResetPass([FromHeader][Required] string TOKEN, [FromForm] UserResetPassModel userResetPassModel)
        {
            long id = new IdFromTokenService().GetId(TOKEN);
            if (id == -1)
            {
                return Unauthorized(new { Message = "User Unauthorized, Please Get Token First" });
            }
            if (UserService.ResetPass(userResetPassModel, id))
            {
                return Ok(new { Message = "Password Reset Successful" });
            }
            return BadRequest(new { Message = "Password Reset Failed" });
        }

        [HttpPost]
        [Route("login")]
        public ActionResult Login([FromForm]UserLoginModel userLoginModel)
        {
            var user = UserService.Login(userLoginModel.Email, userLoginModel.Pass);
            if (user != null)
            {
                if (!user.IsVerified)
                {
                    return BadRequest(new { Message = "User Unverified, Please Verify Email First." });
                }
                var myClaims = new Dictionary<string, string>();
                myClaims.Add("Id", user.Id.ToString());
                return Ok(new { Message = "Logged in Successfully", Token = new TokenService((userLoginModel.RememberMe) ? 525948:5).GenerateJsonWebToken(myClaims) });
            }
            return NotFound(new { Message = "Invalid Email/Password" });
        }

        [HttpGet]
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
        [Route("get/project/members")]
        public ActionResult<List<UserModel>> Get([FromHeader][Required] string TOKEN, [Required]long projectId)
        {
            long id = new IdFromTokenService().GetId(TOKEN);
            if (id == -1)
            {
                return Unauthorized(new { Message = "User Unauthorized, Please Login" });
            }
            var fk = FKProjectsUserService.GetOne(id, projectId);
            if (fk == null)
            {
                return Unauthorized(new { Message = "User Unauthorized, You Do Not Have Permission To Access This UserGroup" });
            }
            if (fk.IsOwner == false)
            {
                return Unauthorized(new { Message = "User Unauthorized, You Do Not Have Permission To Access This UserGroup" });
            }
            var members=UserService.GetMembers(projectId);
            return Ok(members);
        }

        [HttpGet]
        [Route("all/users")]
        public ActionResult<List<UserModel>> Get()
        {
            return UserService.Get();
        }

        [HttpGet]
        [Route("get/one")]
        public ActionResult<UserModel> Get([FromHeader][Required] string TOKEN)
        {
            long id = new IdFromTokenService().GetId(TOKEN);
            if (id == -1)
            {
                return Unauthorized(new { Message = "User Unauthorized, Please Login" });
            }
            var user = UserService.GetById(id);
            if (user != null)
            {
                return Ok(user);
            }
            return BadRequest(new { Message = "Fetch User Failed" });
        }
    }
}
