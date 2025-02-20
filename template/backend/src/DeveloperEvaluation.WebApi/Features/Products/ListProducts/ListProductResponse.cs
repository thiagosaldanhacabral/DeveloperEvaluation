using DeveloperEvaluation.Domain.Entities;

namespace DeveloperEvaluation.WebApi.Features.Products.ListProducts;

/// <summary>
/// API response model for GetUser operation
/// </summary>
public record ListProductResponse
{
    public List<Product>? Data { get; set; }
    public int TotalItems { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
}
