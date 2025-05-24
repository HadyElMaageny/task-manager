using TaskManagement.Core.Dtos.Task;

namespace TaskManagement.Core.Dtos.User
{
    public class UserDto
    {
        public long Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<TaskDto> Tasks { get; set; } = new List<TaskDto>();
    }
}