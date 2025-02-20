using DeveloperEvaluation.Application.Products.UpdateProduct;
using AutoMapper;


namespace DeveloperEvaluation.WebApi.Features.Products.UpdateProduct;


public class UpdateProductProfile : Profile
{

    public UpdateProductProfile()
    {
        CreateMap<UpdateProductRequest, UpdateProductCommand>();
        CreateMap<UpdateProductResult, UpdateProductCommand>();
    }
}
