using Microsoft.AspNetCore.Mvc;
using TaskManagement.Core.Interfaces.Servicies;
using TaskManagement.Core.Dtos.User;
using FluentValidation;

namespace TaskManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IValidator<UserSaveDto> _validator;
        public UserController(IUserService userService, IValidator<UserSaveDto> validator)
        {
            _userService = userService;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            if (users == null || !users.Any())
            {
                return NotFound("No users found.");
            }
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound($"User with ID {id} not found.");
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserSaveDto userDto)
        {
            var validationResult = await _validator.ValidateAsync(userDto);

            if (!validationResult.IsValid)
            {
                return BadRequest(new
                {
                    Errors = validationResult.Errors.Select(e => new { e.PropertyName, e.ErrorMessage })
                });
            }

            var id = await _userService.AddAsync(userDto);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deleted = await _userService.DeleteAsync(id);

            if (!deleted)
                return NotFound(new { Message = $"User with ID {id} not found." });

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] long id, [FromBody] UserSaveDto userDto)
        {
            var validationResult = await _validator.ValidateAsync(userDto);

            if (!validationResult.IsValid)
            {
                return BadRequest(new
                {
                    Errors = validationResult.Errors.Select(e => new { e.PropertyName, e.ErrorMessage })
                });
            }
            var updated = await _userService.UpdateUserAsync(id, userDto);
            if (!updated)
                return NotFound(new { Message = $"User with ID {id} not found." });

            return NoContent();
        }

    }
}