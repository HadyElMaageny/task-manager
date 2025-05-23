using TaskManagement.Core.Interfaces;
using TaskManagement.Core.Dtos.Task;

namespace TaskManagement.Core.Entities
{
    public class TaskItem : BaseEntityDel<long>, IAggregateRoot
    {
        public string Title { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public long AssignedUserId { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public bool IsCompleted { get; private set; }
        public virtual User? AssignedUserNav { get; private set; } = null!;

        protected TaskItem() { }

        public TaskItem(TaskSaveDto dto)
        {
            Title = dto.Title;
            Description = dto.Description;
            AssignedUserId = dto.AssignedUserId;
            StartDate = dto.StartDate;
            EndDate = dto.EndDate;
            IsCompleted = false;
        }

        public void Update(TaskSaveDto dto)
        {
            Title = dto.Title;
            Description = dto.Description;
            AssignedUserId = dto.AssignedUserId;
            StartDate = dto.StartDate;
            EndDate = dto.EndDate;
        }

        public void MarkCompleted() => IsCompleted = true;

    }
}