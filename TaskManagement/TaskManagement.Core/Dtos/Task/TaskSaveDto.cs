using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Core.Dtos.Task
{
    public class TaskSaveDto
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; } = string.Empty;
        [Required]
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;
        [Required]
        [Range(1, long.MaxValue, ErrorMessage = "AssignedUserId must be a valid user ID.")]
        public long AssignedUserId { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public bool IsCompleted
        {
            get; set;

        }
    }

}