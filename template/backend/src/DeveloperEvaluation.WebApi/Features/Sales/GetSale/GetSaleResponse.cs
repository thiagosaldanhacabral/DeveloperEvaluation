using DeveloperEvaluation.Domain.Dto;

namespace DeveloperEvaluation.WebApi.Features.Sales.GetSale
{
    public record GetSaleResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public DateTime Date { get; set; }

        public List<SaleItemDto>? Product { get; set; }
    }
}
