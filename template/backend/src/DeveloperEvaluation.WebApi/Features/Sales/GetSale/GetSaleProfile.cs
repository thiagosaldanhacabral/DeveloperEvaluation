using AutoMapper;
using DeveloperEvaluation.Application.Sales.GetSale;

namespace DeveloperEvaluation.WebApi.Features.Sales.GetSale;

public class GetSaleProfile : Profile
{
    public GetSaleProfile()
    {
        CreateMap<GetSaleRequest, GetSaleCommand>()
         .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

        CreateMap<GetSaleResult, GetSaleResponse>();
    }
}
