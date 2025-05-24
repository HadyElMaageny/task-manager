using FluentValidation;
using TaskManagement.Core.Dtos.User;
using TaskManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace TaskManagement.Infrastructure.Validators;

public class UserSaveDtoValidator : AbstractValidator<UserSaveDto>
{
    public UserSaveDtoValidator(AppDbContext dbContext)
    {
        RuleFor(x => x.UserName)
            .NotEmpty()
            .WithMessage("UserName is required.")
            .MaximumLength(50)
            .WithMessage("UserName must not exceed 50 characters.")
            .MustAsync(async (userName, cancellation) =>
                !await dbContext.Users.AnyAsync(u => u.UserName == userName, cancellation))
            .WithMessage("UserName already exists.");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email is required.")
            .EmailAddress()
            .WithMessage("Invalid email format.")
            .MaximumLength(100)
            .WithMessage("Email must not exceed 100 characters.")
            .MustAsync(async (email, cancellation) =>
                !await dbContext.Users.AnyAsync(u => u.Email == email, cancellation))
            .WithMessage("Email already exists.");

        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage("First name is required.")
            .MaximumLength(50)
            .WithMessage("First name must not exceed 50 characters.");

        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("Last name is required.")
            .MaximumLength(50)
            .WithMessage("Last name must not exceed 50 characters.");
    }
}
