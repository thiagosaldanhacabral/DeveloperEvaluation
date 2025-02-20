using DeveloperEvaluation.Domain.Entities;

namespace DeveloperEvaluation.WebApi.Features.Products.UpdateProduct;

public record UpdateProductResponse
{
    public string Id { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Amount { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public Rating? Rating { get; set; }
}
