using DeveloperEvaluation.Domain.Dto;

namespace DeveloperEvaluation.Application.Sales.UpdateSale;

public class UpdateSaleResult
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }

    public DateTime Date { get; set; }

    public List<SaleItemDto>? Product { get; set; }
}
