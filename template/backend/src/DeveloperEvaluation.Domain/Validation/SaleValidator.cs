using DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace DeveloperEvaluation.Domain.Validation;

public class SaleValidator : AbstractValidator<Sale>
{
    public SaleValidator()
    {
        RuleFor(ads => ads.SaleDate).NotEmpty()
            .WithMessage("Sale Date cannot be None");

        RuleFor(ads => ads.TotalValue).NotEmpty()
            .WithMessage("Total Value cannot be None");

        RuleFor(ads => ads.TotalValue).NotEmpty()
            .WithMessage("Total Value cannot be None");

        RuleFor(ads => ads.Canceled).NotEmpty()
            .WithMessage("Canceled cannot be None");

        RuleFor(ads => ads.CustomerId).NotEmpty()
            .WithMessage("Customer Id cannot be None");
    }
}
