using TaskManagement.Core.Dtos.User;
using TaskManagement.Core.Interfaces;

namespace TaskManagement.Core.Entities
{
    public class User : BaseEntityDel<long>, IAggregateRoot
    {
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public virtual List<TaskItem> Tasks { get; set; } = new List<TaskItem>();

        public User(string userName, string email, string password, string firstName, string lastName)
        {
            UserName = userName;
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
        }

        public User()
        {
        }

        public void Update(UserSaveDto userSaveDto)
        {
            UserName = userSaveDto.UserName;
            Email = userSaveDto.Email;
            FirstName = userSaveDto.FirstName;
            LastName = userSaveDto.LastName;
            Password = userSaveDto.Password;
        }
    }
}