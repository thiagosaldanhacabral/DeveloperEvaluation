using FluentValidation;

namespace DeveloperEvaluation.WebApi.Features.Sales.DeleteSale
{
    public class CancelSaleRequestValidator : AbstractValidator<CancelSaleRequest>
    {
        public CancelSaleRequestValidator()
        {
            RuleFor(x => x.Id)
            .NotEmpty().WithMessage("The sale ID cannot be empty.")
            .NotEqual(Guid.Empty).WithMessage("The sale ID cannot be an empty GUID.");
        }
    }
}
