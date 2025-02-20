using DeveloperEvaluation.Common.Validation;
using DeveloperEvaluation.Domain.Dto;
using MediatR;

namespace DeveloperEvaluation.Application.Sales.UpdateSale;

public class UpdateSaleComand : IRequest<UpdateSaleResult>
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public DateTime SaleDate { get; set; }

    public List<SaleItemDto>? SaleItems { get; set; }

    public UpdateSaleComand(Guid id)
    {
        Id = id;
    }

    public ValidationResultDetail Validate()
    {
        var validator = new UpdateSaleCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}
