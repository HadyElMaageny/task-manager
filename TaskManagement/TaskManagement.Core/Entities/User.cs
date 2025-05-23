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
    }
}