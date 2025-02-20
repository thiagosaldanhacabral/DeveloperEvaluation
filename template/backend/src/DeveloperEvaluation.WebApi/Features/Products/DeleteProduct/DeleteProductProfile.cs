using DeveloperEvaluation.Application.Products.DeleteProduct;
using AutoMapper;

namespace DeveloperEvaluation.WebApi.Features.Products.DeleteProduct;


public class DeleteProductProfile : Profile
{
    public DeleteProductProfile()
    {
        CreateMap<Guid, DeleteProductCommand>()
            .ConstructUsing(id => new DeleteProductCommand(id));

        CreateMap<DeleteProductRequest, DeleteProductCommand>();
        CreateMap<DeleteProductResult, DeleteProductResponse>();
    }
}
