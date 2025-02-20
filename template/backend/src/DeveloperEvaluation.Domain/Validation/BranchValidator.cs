using DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace DeveloperEvaluation.Domain.Validation;

public class BranchValidator : AbstractValidator<Branch>
{
    public BranchValidator()
    {
        RuleFor(ads => ads.Name).NotEmpty()
            .WithMessage("Nome cannot be None");

        RuleFor(ads => ads.Address).NotEmpty()
            .WithMessage("Endereco cannot be None");
    }
}
