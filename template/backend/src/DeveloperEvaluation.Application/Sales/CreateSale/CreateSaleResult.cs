using DeveloperEvaluation.Domain.Dto;


namespace DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleResult
{
    public Guid Id { get; set; } 
    public Guid UserId { get; set; }

    public DateTime Date { get; set; }

    public List<SaleItemDto>? Product { get; set; }

}
