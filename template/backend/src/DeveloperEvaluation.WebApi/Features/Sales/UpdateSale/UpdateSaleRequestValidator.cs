using FluentValidation;

namespace DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    public class UpdateSaleRequestValidator : AbstractValidator<UpdateSaleRequest>
    {
        public UpdateSaleRequestValidator()
        {
            RuleFor(x => x.CustomerId)
            .NotEmpty().WithMessage("Customer ID cannot be empty.")
            .NotEqual(Guid.Empty).WithMessage("Customer ID cannot be an empty GUID.");

            RuleFor(x => x.SaleDate)
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Sale date cannot be in the future.");

            RuleFor(x => x.SaleItems)
                .NotEmpty().WithMessage("The sale must contain at least one item.");

            RuleForEach(x => x.SaleItems)
                .ChildRules(item =>
                {
                    item.RuleFor(i => i.ProductId)
                        .NotEmpty().WithMessage("Product ID cannot be empty.");

                    item.RuleFor(i => i.Quantity)
                        .GreaterThan(0).WithMessage("Product quantity must be greater than 0.");
                });
        }
    }
}
