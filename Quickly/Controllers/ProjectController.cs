using EntityLayer.Models;
using EntityLayer.Models.Project;
using LogicLayer.AuthServices;
using LogicLayer.DbServices;
using LogicLayer.MiscServices;
using LogicLayer.StorageServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Quickly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public ProjectController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("create")]
        public ActionResult Create([FromHeader][Required]string TOKEN, [FromForm]ProjectCreateModel projectCreateModel)
        {
            long id = new IdFromTokenService().GetId(TOKEN);
            if (id == -1)
            {
                return Unauthorized(new { Message = "User Unauthorized, Please Login" });
            }
            if (projectCreateModel.ProjectImage == null)
            {
                projectCreateModel.ProjectImage = new GenerateImage().GenerateNewImage(projectCreateModel.ProjectName[0].ToString(), 480, 480, 250);
            }
            projectCreateModel.ProjectImageUrl = new BlobService().UploadFileToBlob(Guid.NewGuid().ToString(), projectCreateModel.ProjectImage);
            var projectId = ProjectService.AddGetId(projectCreateModel);
            if (projectId != -1)
            {
                var fk = new FKProjectsUsersModel();
                fk.ProjectId = projectId;
                fk.UserId = id;
                fk.IsOwner=true;
                fk.IsProjectEditor=true;
                fk.IsTaskEditor=true;
                fk.IsInvitor = true;
                FKProjectsUserService.Add(fk);
                return Ok(new { Message = "Project Created" });
            }
            return BadRequest(new { Message = "Project Creation Failed" });
        }

        [HttpPost]
        [Route("update")]
        public ActionResult Update([FromHeader][Required] string TOKEN, [FromForm] ProjectUpdateModel projectUpdateModel, long projectId)
        {
            long id = new IdFromTokenService().GetId(TOKEN);
            if (id == -1)
            {
                return Unauthorized(new { Message = "User Unauthorized, Please Login" });
            }
            var fk = FKProjectsUserService.GetOne(id, projectId);
            if (fk.IsOwner==false && fk.IsProjectEditor==false)
            {
                return Unauthorized(new { Message = "User Unauthorized, You Do Not Have Permission To Edit This Project" });
            }
            if (projectUpdateModel.ProjectImage != null)
            {
                projectUpdateModel.ProjectImageUrl = new BlobService().UploadFileToBlob(Guid.NewGuid().ToString(), projectUpdateModel.ProjectImage);
            }
            if (ProjectService.Update(projectUpdateModel, projectId))
            {
                return Ok(new { Message = "Project Updated" });
            }
            return BadRequest(new { Message = "Project Updation Failed" });
        }

        [HttpGet]
        [Route("delete")]
        public ActionResult Delete([FromHeader][Required]string TOKEN, long projectId)
        {
            long id = new IdFromTokenService().GetId(TOKEN);
            if (id == -1)
            {
                return Unauthorized(new { Message = "User Unauthorized, Please Login" });
            }
            var fk = FKProjectsUserService.GetOne(id, projectId);
            if (fk.IsOwner == false)
            {
                return Unauthorized(new { Message = "User Unauthorized, You Do Not Have Permission To Delete This Project" });
            }
            if (ProjectService.Delete(projectId))
            {
                return Ok(new { Message = "Project Deleted" });
            }
            return BadRequest(new { Message = "Project Deletion Failed" });
        }

        [HttpGet]
        [Route("get/for/owner")]
        public ActionResult GetForOwner([FromHeader][Required] string TOKEN)
        {
            long id = new IdFromTokenService().GetId(TOKEN);
            if (id == -1)
            {
                return Unauthorized(new { Message = "User Unauthorized, Please Login" });
            }
            var projects = ProjectService.GetForOwner(id);
            if (projects != null)
            {
                return Ok(projects);
            }
            return NotFound(projects);
        }

        [HttpGet]
        [Route("get/for/member")]
        public ActionResult GetForMember([FromHeader][Required] string TOKEN)
        {
            long id = new IdFromTokenService().GetId(TOKEN);
            if (id == -1)
            {
                return Unauthorized(new { Message = "User Unauthorized, Please Login" });
            }
            var projects = ProjectService.GetForMember(id);
            if (projects != null)
            {
                return Ok(projects);
            }
            return NotFound(projects);
        }

        [HttpGet]
        [Route("get/for/user")]
        public ActionResult GetForUser([FromHeader][Required] string TOKEN)
        {
            long id = new IdFromTokenService().GetId(TOKEN);
            if (id == -1)
            {
                return Unauthorized(new { Message = "User Unauthorized, Please Login" });
            }
            var projects = ProjectService.GetForUser(id);
            if (projects != null)
            {
                return Ok(projects);
            }
            return NotFound(projects);
        }
    }
}
