using FluentValidation;

namespace DeveloperEvaluation.WebApi.Features.Products.ListProducts;

/// <summary>
/// Validator for GetUserRequest
/// </summary>
public class ListProductRequestValidator : AbstractValidator<ListProductRequest>
{
    /// <summary>
    /// Initializes validation rules for GetUserRequest
    /// </summary>
    public ListProductRequestValidator()
    {
        RuleFor(x => x.Page)
              .NotEmpty()
              .WithMessage("User Page is required");

        RuleFor(x => x.Size)
             .NotEmpty()
             .WithMessage("User Size is required");
    }
}
