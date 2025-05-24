using TaskManagement.Core.Dtos.Task;
using TaskManagement.Core.Interfaces.Services;
using TaskManagement.Core.Interfaces.Repositries;
using TaskManagement.Core.Entities;


namespace TaskManagement.Core.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepositry _taskRepo;
        public TaskService(ITaskRepositry taskRepo)
        {
            _taskRepo = taskRepo;
        }

        public async Task<TaskDto?> GetTaskById(long id)
        {
            var task = await _taskRepo.GetByIdAsync(id);
            return task == null ? null : task.ToTaskDto();
        }

        public async Task<long> CreateTask(TaskSaveDto dto)
        {
            var task = dto.ToTaskItemFromCreateDto();
            await _taskRepo.AddAsync(task);
            await _taskRepo.SaveChangesAsync();
            return task.Id;
        }

        public async Task UpdateTask(long id, TaskSaveDto dto)
        {
            var existing = await _taskRepo.GetByIdAsync(id);
            if (existing == null)
                throw new KeyNotFoundException($"Task with ID {id} not found.");

            existing.Update(dto);
            await _taskRepo.UpdateAsync(existing);
            await _taskRepo.SaveChangesAsync();
        }
        public async Task<List<TaskDto>> ListTasks()
        {
            var tasks = await _taskRepo.GetAllAsync();
            return tasks.Select(t => t.ToTaskDto()).ToList();
        }

        public async Task MarkComplete(long id)
        {
            var task = await _taskRepo.GetByIdAsync(id);
            if (task == null)
                throw new KeyNotFoundException($"Task with ID {id} not found.");

            task.MarkCompleted();
            await _taskRepo.UpdateAsync(task);
            await _taskRepo.SaveChangesAsync();
        }

        public async Task<bool> DeleteTask(long id)
        {
            var task = await _taskRepo.GetByIdAsync(id);
            if (task == null)
                return false;

            await _taskRepo.DeleteAsync(task);
            await _taskRepo.SaveChangesAsync();
            return true;
        }
    }
}