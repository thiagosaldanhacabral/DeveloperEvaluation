using FluentValidation;

namespace DeveloperEvaluation.Application.Sales.CreateSale;


public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
{
    public CreateSaleCommandValidator()
    {
        RuleFor(x => x.CustomerId)
            .NotEmpty().WithMessage("The client ID cannot be empty.")
            .NotEqual(Guid.Empty).WithMessage("The client ID cannot be an empty GUID.");

        RuleFor(x => x.SaleDate)
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("The sale date cannot be in the future.");

        RuleFor(x => x.SaleItems)
            .NotEmpty().WithMessage("The sale must contain at least one item.");

        RuleForEach(x => x.SaleItems)
            .ChildRules(item =>
            {
                item.RuleFor(i => i.ProductId)
                    .NotEmpty().WithMessage("The product ID cannot be empty.");

                item.RuleFor(i => i.Quantity)
                    .GreaterThan(0).WithMessage("The product quantity must be greater than 0.");
            });
    }
}
