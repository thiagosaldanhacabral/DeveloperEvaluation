using AutoMapper;
using DeveloperEvaluation.Domain.Dto;
using DeveloperEvaluation.Domain.Entities;

namespace DeveloperEvaluation.Application.Sales.GetSale;


public class GetSaleProfile : Profile
{
 
    public GetSaleProfile()
    {
        CreateMap<GetSaleCommand, Sale>();
        CreateMap<GetSaleDto, GetSaleResult>()
           .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.CustomerId))
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.SaleDate.ToString()))
        .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Items));

    }
}
