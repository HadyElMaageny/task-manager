using TaskManagement.Core.Entities;
using TaskManagement.Core.Dtos.Task;

namespace TaskManagement.Core.Interfaces.Repositries
{
    public interface ITaskRepositry
    {
        Task<TaskItem?> GetByIdAsync(long id);
        Task<List<TaskItem>> GetAllAsync();
        Task AddAsync(TaskItem task);
        Task UpdateAsync(TaskItem task);
        Task MarkCompletedAsync(TaskItem task);
        Task DeleteAsync(TaskItem taskItem);
        Task SaveChangesAsync();
    }
}