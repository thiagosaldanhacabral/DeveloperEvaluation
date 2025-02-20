using DeveloperEvaluation.Domain.Enums;
using DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace DeveloperEvaluation.Application.Users.UpdateUser;

/// <summary>
/// Validator for CreateUserCommand that defines validation rules for user creation command.
/// </summary>
public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(user => user.Email).SetValidator(new EmailValidator());
        RuleFor(user => user.Username).NotEmpty().Length(3, 50);
        RuleFor(user => user.Password).SetValidator(new PasswordValidator());
        RuleFor(user => user.FirstName).NotEmpty().MinimumLength(3).MaximumLength(50);
        RuleFor(user => user.LastName).NotEmpty().MinimumLength(1).MaximumLength(50);
        RuleFor(user => user.City).NotEmpty();
        RuleFor(user => user.Street).NotEmpty();
        RuleFor(user => user.Number).NotEmpty();
        RuleFor(user => user.ZipCode).NotEmpty().MinimumLength(8).MaximumLength(8);
        RuleFor(user => user.Phone).Matches(@"^\+?[1-9]\d{1,14}$");
        RuleFor(user => user.Status).NotEqual(UserStatus.Unknown);
        RuleFor(user => user.Role).NotEqual(UserRole.None);
    }
}