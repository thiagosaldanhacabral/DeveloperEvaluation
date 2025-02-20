using AutoMapper;
using DeveloperEvaluation.Domain.Entities;
using DeveloperEvaluation.Domain.Events;

namespace DeveloperEvaluation.Application.Sales.CancelSale;

/// <summary>
/// Profile for mapping between User entity and CreateUserResponse
/// </summary>
public class CancelSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateUser operation
    /// </summary>
    public CancelSaleProfile()
    {
        CreateMap<CancelSaleCommand, Sale>();
        CreateMap<SaleCancelledEvent, CancelSaleResult>()
           .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.CustomerId))
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.SaleDate.ToString()))
        .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Items));
    }
}
