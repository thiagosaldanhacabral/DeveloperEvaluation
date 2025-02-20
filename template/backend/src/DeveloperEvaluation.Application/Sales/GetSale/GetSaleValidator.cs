using FluentValidation;

namespace DeveloperEvaluation.Application.Sales.GetSale;


public class GetSaleValidator : AbstractValidator<GetSaleCommand>
{
    public GetSaleValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("The Sale ID cannot be empty.")
            .NotEqual(Guid.Empty).WithMessage("The Sale ID cannot be an empty GUID.");
    }
}
