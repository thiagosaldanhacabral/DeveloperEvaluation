using DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace DeveloperEvaluation.Domain.Validation;

public class SaleProductValidator : AbstractValidator<SaleProduct>
{
    public SaleProductValidator()
    {
        RuleFor(ads => ads.SaleId).NotEmpty()
            .WithMessage("Sale Id cannot be empty");

        RuleFor(ads => ads.ProductId).NotEmpty()
            .WithMessage("Product Id cannot be empty");

        RuleFor(ads => ads.Quantity).NotEmpty()
            .WithMessage("Quantity cannot be empty");

        RuleFor(ads => ads.UnitPrice).NotEmpty()
            .WithMessage("Unit Price cannot be empty");

        RuleFor(ads => ads.Discount).NotEmpty()
            .WithMessage("Discount cannot be empty");

        RuleFor(ads => ads.TotalValue).NotEmpty()
            .WithMessage("TotalAmmount cannot be empty");
    }
}
