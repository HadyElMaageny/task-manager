using Microsoft.AspNetCore.Mvc;
using TaskManagement.Core.Interfaces.Services;
using TaskManagement.Core.Dtos.Task;

namespace TaskManagement.API.Controllers
{
    [ApiController]
    [Route("api/task")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TaskSaveDto dto)
        {
            var id = await _taskService.CreateTask(dto);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] long id, [FromBody] TaskSaveDto dto)
        {
            await _taskService.UpdateTask(id, dto);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskDto>>> GetAll()
        {
            var tasks = await _taskService.ListTasks();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDto>> GetById(long id)
        {
            var task = await _taskService.GetTaskById(id);
            return Ok(task);
        }

        [HttpPatch("{id}/complete")]
        public async Task<IActionResult> MarkAsComplete(long id)
        {
            await _taskService.MarkComplete(id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _taskService.DeleteTask(id);
            return NoContent();
        }
    }
}