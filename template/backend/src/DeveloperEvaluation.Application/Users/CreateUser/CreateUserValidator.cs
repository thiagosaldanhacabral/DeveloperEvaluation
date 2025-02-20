﻿using DeveloperEvaluation.Domain.Enums;
using DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace DeveloperEvaluation.Application.Users.CreateUser;

/// <summary>
/// Validator for CreateUserCommand that defines validation rules for user creation command.
/// </summary>
public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateUserCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Email: Must be in valid format (using EmailValidator)
    /// - Username: Required, must be between 3 and 50 characters
    /// - Password: Must meet security requirements (using PasswordValidator)
    /// - Phone: Must match international format (+X XXXXXXXXXX)
    /// - Status: Cannot be set to Unknown
    /// - Role: Cannot be set to None
    /// </remarks>
    public CreateUserCommandValidator()
    {
        RuleFor(user => user.Email).SetValidator(new EmailValidator());
        RuleFor(user => user.Username).NotEmpty().Length(3, 50);
        RuleFor(user => user.Password).SetValidator(new PasswordValidator());
        RuleFor(user => user.FirstName).NotEmpty().MinimumLength(10).MaximumLength(50);
        RuleFor(user => user.LastName).NotEmpty().MinimumLength(10).MaximumLength(50);
        RuleFor(user => user.City).NotEmpty();
        RuleFor(user => user.Street).NotEmpty();
        RuleFor(user => user.Number).NotEmpty();
        RuleFor(user => user.ZipCode).NotEmpty().MinimumLength(8).MaximumLength(8);
        RuleFor(user => user.Phone).Matches(@"^\+?[1-9]\d{1,14}$");
        RuleFor(user => user.Status).NotEqual(UserStatus.Unknown);
        RuleFor(user => user.Role).NotEqual(UserRole.None);




    }
}