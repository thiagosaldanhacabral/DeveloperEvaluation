using DeveloperEvaluation.Domain.Entities;

namespace DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

public record CreateProductResponse
{
    public string Id { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public Rating? Rating { get; set; }

}