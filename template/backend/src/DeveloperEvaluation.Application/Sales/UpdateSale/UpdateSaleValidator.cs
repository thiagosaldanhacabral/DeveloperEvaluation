using FluentValidation;

namespace DeveloperEvaluation.Application.Sales.UpdateSale;

public class UpdateSaleCommandValidator : AbstractValidator<UpdateSaleComand>
{
    public UpdateSaleCommandValidator()
    {
        RuleFor(x => x.CustomerId)
            .NotEmpty().WithMessage("Customer ID cannot be empty.")
            .NotEqual(Guid.Empty).WithMessage("Customer ID cannot be an empty GUID.");

        RuleFor(x => x.SaleDate)
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Sale date cannot be in the future.");

        RuleFor(x => x.SaleItems)
            .NotEmpty().WithMessage("The sale must contain at least one item.");
    }
}
