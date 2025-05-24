using FluentValidation;
using TaskManagement.Core.Dtos.Task;
using TaskManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace TaskManagement.Infrastructure.Validators;

public class TaskSaveDtoValidator : AbstractValidator<TaskSaveDto>
{
    public TaskSaveDtoValidator(AppDbContext dbContext)
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .Length(3, 100);

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(500);

        RuleFor(x => x.AssignedUserId)
            .MustAsync(async (userId, cancellation) =>
                await dbContext.Users.AnyAsync(u => u.Id == userId, cancellation))
            .WithMessage("Assigned user does not exist.");

        RuleFor(x => x.EndDate)
            .GreaterThan(x => x.StartDate)
            .WithMessage("EndDate must be after StartDate.");
    }
}
