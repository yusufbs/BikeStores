using FluentValidation;
using Lp.AngularBlog.Application.Models;

namespace Lp.AngularBlog.Application.Validators;

public class UserUpdateRequestValidator : AbstractValidator<UserUpdateRequest>
{
    public UserUpdateRequestValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Username is required")
            .MaximumLength(50).WithMessage("Username must not exceed 50 chars");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Email is not valid");

        RuleFor(x => x.Id)
            .NotEmpty().GreaterThan(0).WithMessage("Email is required");
    }
}
