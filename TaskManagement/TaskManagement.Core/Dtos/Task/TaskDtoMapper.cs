using TaskManagement.Core.Entities;

namespace TaskManagement.Core.Dtos.Task
{
    public static class TaskDtoMapper
    {
        public static TaskDto ToTaskDto(this TaskItem taskItem)
        {
            return new TaskDto
            {
                Id = taskItem.Id,
                Title = taskItem.Title,
                Description = taskItem.Description,
                AssignedUserId = taskItem.AssignedUserId,
                StartDate = taskItem.StartDate,
                EndDate = taskItem.EndDate,
                IsCompleted = taskItem.IsCompleted
            };
        }

        public static TaskItem ToTaskItemFromCreateDto(this TaskSaveDto taskSaveDto)
        {
            return new TaskItem(taskSaveDto);
        }
    }
}