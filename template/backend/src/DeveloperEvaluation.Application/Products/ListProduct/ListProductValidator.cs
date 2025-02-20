using FluentValidation;

namespace DeveloperEvaluation.Application.Products.ListProduct;

public class ListProductValidator : AbstractValidator<ListProductCommand>
{
    /// <summary>
    /// Initializes validation rules for GetUserCommand
    /// </summary>
    public ListProductValidator()
    {
        RuleFor(x => x.Page)
           .GreaterThan(0).WithMessage("Page must be greater than 0.");

        RuleFor(x => x.Size)
           .GreaterThan(0).WithMessage("Size must be greater than 0.");
    }
}
