using DeveloperEvaluation.Domain.Entities;

namespace DeveloperEvaluation.Application.Products.ListProductCategory;

/// <summary>
/// Response model for GetUser operation
/// </summary>
public class ListProductCategoryResult
{
    public List<Product>? products { get; set; }
}
