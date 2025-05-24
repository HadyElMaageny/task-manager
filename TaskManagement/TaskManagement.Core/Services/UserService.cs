using TaskManagement.Core.Entities;
using TaskManagement.Core.Interfaces.Repositries;
using TaskManagement.Core.Interfaces.Servicies;
using TaskManagement.Core.Dtos.User;

namespace TaskManagement.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepositry _userRepositry;

        public UserService(IUserRepositry userRepositry)
        {
            _userRepositry = userRepositry;
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            var users = await _userRepositry.GetAllAsync();
            return users.Select(u => u.ToUserDto()).ToList();
        }

        public async Task<UserDto?> GetByIdAsync(long id)
        {
            var user = await _userRepositry.GetByIdAsync(id);
            return user == null ? null : user.ToUserDto();
        }

        public async Task<long> AddAsync(UserSaveDto userSaveDto)
        {
            var user = userSaveDto.ToUserItemFromCreateDto();
            await _userRepositry.AddAsync(user);
            await _userRepositry.SaveChangesAsync();
            return user.Id;
        }

        public async Task<bool> UpdateUserAsync(long id, UserSaveDto dto)
        {
            var existing = await _userRepositry.GetByIdAsync(id);
            if (existing == null)
                return false;
            existing.Update(dto);
            await _userRepositry.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var existing = await _userRepositry.GetByIdAsync(id);
            if (existing == null)
                return false;

            await _userRepositry.DeleteAsync(existing);
            await _userRepositry.SaveChangesAsync();
            return true;
        }


    }
}