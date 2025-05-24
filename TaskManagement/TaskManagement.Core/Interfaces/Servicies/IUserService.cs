using TaskManagement.Core.Dtos.User;
using TaskManagement.Core.Entities;

namespace TaskManagement.Core.Interfaces.Servicies
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllAsync();
        Task<UserDto?> GetByIdAsync(long id);
        Task<long> AddAsync(UserSaveDto userSaveDto);
        Task<bool> UpdateUserAsync(long id, UserSaveDto dto);
        Task<bool> DeleteAsync(long id);
        // Task SaveChangesAsync();
    }
}