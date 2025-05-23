namespace TaskManagement.Core.Dtos.Task
{
    public class TaskDto
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public long AssignedUserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsCompleted
        {
            get; set;
        }
    }
}