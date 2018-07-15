using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTS.TaskSolution.Domain;
using MTS.TaskSolution.Services;
using MTS.TaskSolution.WebApi.ViewModels;

namespace MTS.TaskSolution.WebApi.Controllers
{
    [Route("[controller]")]
    public class TaskController : Controller
    {
        ITaskService _service;
        public TaskController(ITaskService service)
        {
            _service = service;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            return BadRequest();
        }

        [HttpGet("{input}")]
        public async Task<IActionResult> Get(string input)
        {
            if (Guid.TryParse(input, out Guid uid))
            {
                var task = await _service.GetTaskByUid(uid);
                if (task != null)
                    return Json(task.ToViewModel());
                else
                    return NotFound();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var uid = await _service.CreateTask();
            Response.StatusCode = StatusCodes.Status202Accepted;
            return Content(uid.ToString());
        }
    }
}
