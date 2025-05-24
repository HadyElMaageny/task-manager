using Microsoft.EntityFrameworkCore;
using TaskManagement.Core.Entities;
using TaskManagement.Core.Interfaces.Repositries;
using TaskManagement.Infrastructure.Data;



namespace TaskManagement.Infrastructure.Repositries
{
    public class UserRepositry : IUserRepositry
    {
        private readonly AppDbContext _context;
        public UserRepositry(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users
                .Include(c => c.Tasks)
                .ToListAsync();
        }

        public async Task<User?> GetByIdAsync(long id)
        {
            return await _context.Users
                .Include(c => c.Tasks)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public Task DeleteAsync(User user)
        {
            _context.Users.Remove(user);
            return Task.CompletedTask;
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}