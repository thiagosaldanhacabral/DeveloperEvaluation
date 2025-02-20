using AutoMapper;
using DeveloperEvaluation.Domain.Entities;
using DeveloperEvaluation.Domain.Events;

namespace DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Profile for mapping between User entity and CreateUserResponse
/// </summary>
public class CreateSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateUser operation
    /// </summary>
    public CreateSaleProfile()
    {
        CreateMap<CreateSaleCommand, Sale>();
        CreateMap<SaleCreatedEvent, CreateSaleResult>()
           .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.CustomerId))
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.SaleDate.ToString()))
        .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Items));
    }
}
