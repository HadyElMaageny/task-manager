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
        [DateGreaterThan("StartDate", ErrorMessage = "EndDate must be after StartDate.")]
        public DateTime EndDate { get; set; }
        public bool IsCompleted
        {
            get; set;

        }
    }

    public class DateGreaterThanAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;

        public DateGreaterThanAttribute(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var currentValue = (DateTime?)value;

            var property = validationContext.ObjectType.GetProperty(_comparisonProperty);
            if (property == null) return new ValidationResult($"Unknown property: {_comparisonProperty}");

            var comparisonValue = (DateTime?)property.GetValue(validationContext.ObjectInstance);

            if (currentValue.HasValue && comparisonValue.HasValue && currentValue <= comparisonValue)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }

}