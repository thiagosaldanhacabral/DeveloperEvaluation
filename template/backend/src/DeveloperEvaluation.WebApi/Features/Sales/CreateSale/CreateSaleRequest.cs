using DeveloperEvaluation.Domain.Dto;

namespace DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CreateSaleRequest
    {
        public Guid CustomerId { get; set; }
        public DateTime SaleDate { get; set; }
        public List<SaleItemDto>? SalesItems { get; set; }
    }
}
