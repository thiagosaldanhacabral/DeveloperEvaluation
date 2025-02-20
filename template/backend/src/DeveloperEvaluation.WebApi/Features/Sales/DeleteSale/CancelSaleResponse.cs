using DeveloperEvaluation.Domain.Dto;

namespace DeveloperEvaluation.WebApi.Features.Sales.DeleteSale
{
    public record CancelSaleResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public DateTime Date { get; set; }

        public List<SaleItemDto>? Product { get; set; }

        public string Message { get; set; } = string.Empty;
    }
}
