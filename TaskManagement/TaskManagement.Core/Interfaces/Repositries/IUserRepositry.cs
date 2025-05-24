
using TaskManagement.Core.Entities;

namespace TaskManagement.Core.Interfaces.Repositries
{
    public interface IUserRepositry
    {
        Task<User?> GetByIdAsync(long id);
        Task<List<User>> GetAllAsync();
        Task AddAsync(User user);
        // Task UpdateAsync(User user);
        Task DeleteAsync(User user);
        Task SaveChangesAsync();
    }
}