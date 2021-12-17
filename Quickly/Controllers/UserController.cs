using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Providers;
using LogicLayer.DbServices;

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

        [HttpGet]
        [Route("all/users")]
        public ActionResult<User> Get()
        {
            var users = UserService.Get();
            return users!=null? Ok(users):NotFound();
        }
    }
}
