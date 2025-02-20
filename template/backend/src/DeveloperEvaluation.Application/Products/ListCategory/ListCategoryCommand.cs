using DeveloperEvaluation.Common.Validation;
using MediatR;

namespace DeveloperEvaluation.Application.Products.ListCategory;


public record ListCategoryCommand : IRequest<List<string>>
{
    public ListCategoryCommand()
    {
      
    }

    public ValidationResultDetail Validate()
    {
        var validator = new ListCategoryValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}
