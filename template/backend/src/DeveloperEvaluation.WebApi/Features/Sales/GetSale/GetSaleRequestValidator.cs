using FluentValidation;

namespace DeveloperEvaluation.WebApi.Features.Sales.GetSale;

public class GetSaleRequestValidator : AbstractValidator<GetSaleRequest>
{
    public GetSaleRequestValidator()
    {
        RuleFor(x => x.Id)
        .NotEmpty().WithMessage("The sale ID cannot be empty.")
        .NotEqual(Guid.Empty).WithMessage("The sale ID cannot be an empty GUID.");
    }
}
