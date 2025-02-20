using DeveloperEvaluation.Domain.Dto;

namespace DeveloperEvaluation.Application.Sales.CancelSaleItem;

public class CancelSaleItemResult
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }

    public DateTime Date { get; set; }

    public List<SaleItemDto>? Product { get; set; }
}
