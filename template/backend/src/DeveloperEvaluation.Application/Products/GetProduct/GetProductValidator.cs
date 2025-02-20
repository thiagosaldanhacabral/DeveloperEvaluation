using FluentValidation;

namespace DeveloperEvaluation.Application.Products.GetProduct;


public class GetProductValidator : AbstractValidator<GetProductCommand>
{

    public GetProductValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("User ID is required");
    }
}
