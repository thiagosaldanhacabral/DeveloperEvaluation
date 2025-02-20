using AutoMapper;
using DeveloperEvaluation.Domain.Entities;
namespace DeveloperEvaluation.Application.Products.GetProduct;

/// <summary>
/// Profile for mapping between User entity and GetUserResponse
/// </summary>
public class GetProductProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetUser operation
    /// </summary>
    public GetProductProfile()
    {
        CreateMap<GetProductCommand, Product>();
        CreateMap<Product, GetProductResult>();

    }
}
