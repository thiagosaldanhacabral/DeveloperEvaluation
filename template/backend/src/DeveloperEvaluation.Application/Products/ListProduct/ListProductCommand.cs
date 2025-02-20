using DeveloperEvaluation.Domain.Entities;
using MediatR;
using DeveloperEvaluation.Common.Common;

namespace DeveloperEvaluation.Application.Products.ListProduct;

/// <summary>
/// Command for retrieving a user by their ID
/// </summary>
public record ListProductCommand : IRequest<PaginatedList<Product>>
{
    /// <summary>
    /// The unique identifier of the user to retrieve
    /// </summary>
    public int Page { get; set; }

    /// <summary>
    /// Size por page
    /// </summary>
    public int Size { get; set; }

    /// <summary>
    /// Order type asc / desc
    /// </summary>
    public string Order { get; set; }

    
    public ListProductCommand(int page, int size, string order)
    {
        Page = page;
        Size = size;
        Order = order;
    }
}
