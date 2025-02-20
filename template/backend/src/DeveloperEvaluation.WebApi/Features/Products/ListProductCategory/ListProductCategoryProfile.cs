using AutoMapper;
using DeveloperEvaluation.Application.Products.ListProductCategory;

namespace DeveloperEvaluation.WebApi.Features.Products.ListProductCategory;

/// <summary>
/// Profile for mapping GetUser feature requests to commands
/// </summary>
public class ListProductCategoryProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetUser feature
    /// </summary>
    public ListProductCategoryProfile()
    {
        CreateMap<ListProductCategoryRequest, ListProductCategoryCommand>();
    }
}
