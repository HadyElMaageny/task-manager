using Microsoft.AspNetCore.Mvc;
using TaskManagement.Core.Interfaces.Services;
using TaskManagement.Core.Dtos.Task;
using FluentValidation;

namespace TaskManagement.API.Controllers
{
    [ApiController]
    [Route("api/task")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly IValidator<TaskSaveDto> _validator;

        public TaskController(ITaskService taskService, IValidator<TaskSaveDto> validator)
        {
            _taskService = taskService;
            _validator = validator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TaskSaveDto dto)
        {
            var validationResult = await _validator.ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                return BadRequest(new
                {
                    Errors = validationResult.Errors.Select(e => new { e.PropertyName, e.ErrorMessage })
                });
            }
            var id = await _taskService.CreateTask(dto);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] long id, [FromBody] TaskSaveDto dto)
        {
            var validationResult = await _validator.ValidateAsync(dto);

            if (!validationResult.IsValid)
            {
                return BadRequest(new
                {
                    Errors = validationResult.Errors.Select(e => new { e.PropertyName, e.ErrorMessage })
                });
            }
            await _taskService.UpdateTask(id, dto);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _taskService.ListTasks();
            if (tasks == null || !tasks.Any())
            {
                return NotFound("No tasks found.");
            }
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var task = await _taskService.GetTaskById(id);
            if (task == null)
            {
                return NotFound($"Task with ID {id} not found.");
            }
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
            var deleted = await _taskService.DeleteTask(id);
            if (!deleted)
                return NotFound(new { Message = $"Task with ID {id} not found." });

            return NoContent();
        }
    }
}