using DeveloperEvaluation.Domain.Entities;

namespace DeveloperEvaluation.Application.Products.GetProduct;


public class GetProductResult
{
    public string Id { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public Rating? Rating { get; set; }
}
