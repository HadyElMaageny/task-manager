using TaskManagement.Core.Entities;
using TaskManagement.Core.Interfaces.Repositries;
using TaskManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Core.Dtos.Task;

namespace TaskManagement.Infrastructure.Repositries
{
    public class TaskRepositry : ITaskRepositry
    {
        private readonly AppDbContext _context;
        public TaskRepositry(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<TaskItem>> GetAllAsync()
        {
            return await _context.TaskItems
                .Include(t => t.AssignedUserNav)
                .ToListAsync();
        }

        public async Task<TaskItem?> GetByIdAsync(long id)
        {
            return await _context.TaskItems
                .Include(t => t.AssignedUserNav)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task AddAsync(TaskItem task)
        {
            await _context.TaskItems.AddAsync(task);
        }

        public Task UpdateAsync(TaskItem task)
        {
            _context.TaskItems.Update(task);
            return Task.CompletedTask;
        }

        public Task MarkCompletedAsync(TaskItem task)
        {
            task.MarkCompleted();
            return Task.CompletedTask;
        }

        public Task DeleteAsync(TaskItem taskItem)
        {
            _context.TaskItems.Remove(taskItem);
            return Task.CompletedTask;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}