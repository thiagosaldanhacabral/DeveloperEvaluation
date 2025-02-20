using DeveloperEvaluation.Domain.Dto;

namespace DeveloperEvaluation.Application.Sales.CancelSale;

public class CancelSaleResult
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }

    public DateTime Date { get; set; }

    public List<SaleItemDto>? Product { get; set; }

    public string Message { get; set; } = string.Empty;
}
