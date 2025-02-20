﻿namespace DeveloperEvaluation.WebApi.Features.Sales.GetSale;

public class GetSaleRequest
{
    public Guid Id { get; set; }

    public GetSaleRequest(Guid id)
    {
        Id  = id;
    }
}
