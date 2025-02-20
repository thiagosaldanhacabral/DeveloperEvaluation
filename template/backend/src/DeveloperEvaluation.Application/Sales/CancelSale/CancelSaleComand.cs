﻿using DeveloperEvaluation.Common.Validation;
using MediatR;

namespace DeveloperEvaluation.Application.Sales.CancelSale;

public class CancelSaleCommand : IRequest<CancelSaleResult>
{
    public Guid Id { get; set; }

    public CancelSaleCommand(Guid id)
    {
        Id = id;
    }
    public ValidationResultDetail Validate()
    {
        var validator = new CancelSaleValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}
