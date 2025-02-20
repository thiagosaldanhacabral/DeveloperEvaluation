using DeveloperEvaluation.Domain.Dto;

namespace DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    public class UpdateSaleRequest
    {
        public Guid CustomerId { get; set; }
        public DateTime SaleDate { get; set; }
        public List<SaleItemDto>? SaleItems { get; set; }
    }
}
