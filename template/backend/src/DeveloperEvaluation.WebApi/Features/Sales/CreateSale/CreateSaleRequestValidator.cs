using FluentValidation;

namespace DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
    {
        public CreateSaleRequestValidator()
        {
            RuleFor(x => x.CustomerId)
            .NotEmpty().WithMessage("The customer ID cannot be empty.")
            .NotEqual(Guid.Empty).WithMessage("The customer ID cannot be an empty GUID.");

            RuleFor(x => x.SaleDate)
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("The sale date cannot be in the future.");

            RuleFor(x => x.SalesItems)
                .NotEmpty().WithMessage("The sale must contain at least one item.");

            RuleForEach(x => x.SalesItems)
                .ChildRules(item =>
                {
                    item.RuleFor(i => i.ProductId)
                        .NotEmpty().WithMessage("The product ID cannot be empty.");

                    item.RuleFor(i => i.Quantity)
                        .GreaterThan(0).WithMessage("The product quantity must be greater than 0.");
                });
        }
    }
}
