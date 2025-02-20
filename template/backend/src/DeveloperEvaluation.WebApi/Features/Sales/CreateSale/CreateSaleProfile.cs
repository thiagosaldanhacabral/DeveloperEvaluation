using AutoMapper;
using DeveloperEvaluation.Application.Sales.CreateSale;

namespace DeveloperEvaluation.WebApi.Features.Sales.CreateSale
{
    public class CreateSaleProfile : Profile
    {
        public CreateSaleProfile()
        {
            CreateMap<CreateSaleRequest, CreateSaleCommand>();

            CreateMap<CreateSaleResult, CreateSaleResponse>();
        }
    }
}
