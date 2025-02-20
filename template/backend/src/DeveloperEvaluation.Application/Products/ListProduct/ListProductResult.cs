using DeveloperEvaluation.Domain.Entities;

namespace DeveloperEvaluation.Application.Products.ListProduct;

/// <summary>
/// Response model for GetUser operation
/// </summary>
public class ListProductResult
{
    public List<Product>? products { get; set; }
}
