using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EntityLayer.Models.Task;
using System.ComponentModel.DataAnnotations;
using LogicLayer.AuthServices;
using LogicLayer.DbServices;

namespace Quickly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public TaskController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("create")]
        public ActionResult Create([FromHeader][Required] string TOKEN, [FromForm]CreateTaskModel createTaskModel)
        {
            long id = new IdFromTokenService().GetId(TOKEN);
            if (id == -1)
            {
                return Unauthorized(new { Message = "User Unauthorized, Please Login" });
            }
            var fk = FKProjectsUserService.GetOne(id, createTaskModel.ProjectId.GetValueOrDefault());
            if (fk.IsTaskEditor == false)
            {
                return Unauthorized(new { Message = "User Unauthorized, You Do Not Have Permission To Create Task" });
            }
            if (TaskService.Add(createTaskModel))
            {
                return Ok(new { Message = "Task Created" });
            }
            return BadRequest(new { Message = "Task Creation Failed" });
        }

        [HttpGet]
        [Route("delete")]
        public ActionResult Delete([FromHeader][Required] string TOKEN, [Required]long taskId, [Required] long projectId)
        {
            long id = new IdFromTokenService().GetId(TOKEN);
            if (id == -1)
            {
                return Unauthorized(new { Message = "User Unauthorized, Please Login" });
            }
            var fk = FKProjectsUserService.GetOne(id, projectId);
            if (fk.IsTaskEditor == false)
            {
                return Unauthorized(new { Message = "User Unauthorized, You Do Not Have Permission To Delete Task" });
            }
            if (TaskService.Delete(taskId))
            {
                return Ok(new { Message = "Task Deleted" });
            }
            return BadRequest(new { Message = "Task Deletion Failed" });
        }

        [HttpGet]
        [Route("change/status")]
        public ActionResult ChangeStatus([FromHeader][Required]string TOKEN, [Required]string taskStatus, [Required]long taskId)
        {
            long id = new IdFromTokenService().GetId(TOKEN);
            if (id == -1)
            {
                return Unauthorized(new { Message = "User Unauthorized, Please Login" });
            }
            if(TaskService.ChangeStatus(taskStatus, taskId))
            {
                return Ok(new { Message = "Task Status Changed" });
            }
            return BadRequest(new { Message = "Task Status Changing Failed" });
        }

        [HttpGet]
        [Route("get/project/tasks")]
        public ActionResult<TaskModel> GetTasks([FromHeader][Required]string TOKEN, [Required]long projectId)
        {
            long id = new IdFromTokenService().GetId(TOKEN);
            if (id == -1)
            {
                return Unauthorized(new { Message = "User Unauthorized, Please Login" });
            }
            var fk = FKProjectsUserService.GetOne(id, projectId);
            if (fk.IsOwner == true)
            {
                var tasks = TaskService.Get(projectId);
                return Ok(tasks);
            }
            else
            {
                var tasks = TaskService.GetForAssignee(projectId, id);
                return Ok(tasks);
            }
        }
    }
}
