using AutoMapper;
using DeveloperEvaluation.Domain.Entities;
using DeveloperEvaluation.Application.Products.CreateProduct;

namespace DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

/// <summary>
/// Profile for mapping between Application and API CreateUser responses
/// </summary>
public class CreateProductProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateUser feature
    /// </summary>
    public CreateProductProfile()
    {
        CreateMap<CreateProductRequest, CreateProductCommand>();
        CreateMap<Product, CreateProductResult>();
        CreateMap<CreateProductResult, CreateProductResponse>();

    }
}
