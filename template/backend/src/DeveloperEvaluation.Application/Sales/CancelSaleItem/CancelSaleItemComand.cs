﻿using MediatR;

namespace DeveloperEvaluation.Application.Sales.CancelSaleItem;

public class CancelSaleItemCommand : IRequest<CancelSaleItemResult>
{
    public Guid SaleId { get; set; }
    public Guid ProductId { get; set; }
}
