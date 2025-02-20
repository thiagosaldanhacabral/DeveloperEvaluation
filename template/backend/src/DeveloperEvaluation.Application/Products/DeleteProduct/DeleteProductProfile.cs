using AutoMapper;
using DeveloperEvaluation.Domain.Entities;

namespace DeveloperEvaluation.Application.Products.DeleteProduct;


public class DeleteProductProfile : Profile
{

    public DeleteProductProfile()
    {
        CreateMap<DeleteProductCommand, Product>();
        CreateMap<Product, DeleteProductResult>();

    }
}
