using TaskManagement.Core.Dtos.Task;

namespace TaskManagement.Core.Interfaces.Services
{
    public interface ITaskService
    {
        Task<long> CreateTask(TaskSaveDto dto);
        Task UpdateTask(long id, TaskSaveDto dto);
        Task<List<TaskDto>> ListTasks();
        Task MarkComplete(long id);
        Task<TaskDto?> GetTaskById(long id);
        Task<bool> DeleteTask(long id);
    }
}