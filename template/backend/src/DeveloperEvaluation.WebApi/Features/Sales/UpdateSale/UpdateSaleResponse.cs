using DeveloperEvaluation.Domain.Dto;

namespace DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    public record UpdateSaleResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public DateTime Date { get; set; }

        public List<SaleItemDto>? Product { get; set; }
    }
}
