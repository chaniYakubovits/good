using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ex2.Services;
using ex2.Models;
using ex2.Services.Logger;

namespace ex2.Controlers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITasksServices _taskService;
        private readonly IAdoServices _AdoServices;
        private readonly ILoggerService _LoggerData;
        private readonly Services.Logger.LoggerFactory _LoggerFactory;

        public TasksController(ITasksServices taskService, IAdoServices AdoServices, Services.Logger.LoggerFactory loggerFactory)
        {
            _taskService = taskService;
            _AdoServices = AdoServices;
            _LoggerFactory = loggerFactory;
            _LoggerData = _LoggerFactory.GetLogger("DATA");
        }

        [HttpGet]
        public IActionResult Get()
        {
            var task = _taskService.Get();
            _LoggerData.Log("get all the task");
            return Ok(task);
        }
        [HttpGet("{id}")]
        public IActionResult GetTaskByUser(int id)
        {
            var task = _taskService.GetTaskByUser(id);
            if (task != null)
                return Ok(task);
            else
                return BadRequest("not found");
        }
        [Route("api/Tasks/Add")]
        [HttpPost]
        public IActionResult Add([FromQuery] Tasks task)
        {

            var success = _taskService.Add(task);
            if (success)  
                return CreatedAtAction(nameof(Get), new { id = task.Id }, task);
             
            return BadRequest("userId undefind");
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromQuery] Tasks task)
        {
            if (id != task.Id)
            {
                _LoggerData.Log("taks" + task.Id + "update not-successfuly");
                return BadRequest();
            }

            _taskService.Update(task);
            _LoggerData.Log("taks" + task.Id + "update successfuly");
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _taskService.Delete(id);
            return NoContent();
        }
        [Route("api/Tasks/ProcessTransaction")]
        [HttpPost]
        public IActionResult ProcessTransaction([FromQuery] TaskAndAttechment taskAndAttechment)
        {

            var success = _AdoServices.ProcessTransaction(taskAndAttechment);
            if (success)
                return CreatedAtAction(nameof(Get), new { id = taskAndAttechment.task.Id }, taskAndAttechment.task);
            return BadRequest("not success");
        }
    }
}
//[HttpPost]
//public IActionResult addAttachment(Attachment attachment)
//{
//    return Ok(_taskService.addAttachment(attachment));
//}

//[HttpGet("{id}")]
//public IActionResult getByProject(int ProjactId)
//{
//    var succeed = _taskService.getByProject(ProjactId);
//    if (succeed != null)
//        return Ok(succeed);
//    else
//        return BadRequest("not found");
//}
