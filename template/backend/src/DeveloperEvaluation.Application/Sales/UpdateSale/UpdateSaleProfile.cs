using AutoMapper;
using DeveloperEvaluation.Domain.Entities;
using DeveloperEvaluation.Domain.Events;

namespace DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Profile for mapping between User entity and CreateUserResponse
/// </summary>
public class UpdateSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateUser operation
    /// </summary>
    public UpdateSaleProfile()
    {
        CreateMap<UpdateSaleComand, Sale>();
        CreateMap<SaleModifiedEvent, UpdateSaleResult>()
           .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.CustomerId))
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.SaleDate.ToString()))
        .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Items));
    }
}
