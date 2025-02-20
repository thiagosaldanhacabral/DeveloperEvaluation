using AutoMapper;
using DeveloperEvaluation.Application.Sales.UpdateSale;

namespace DeveloperEvaluation.WebApi.Features.Sales.UpdateSale
{
    public class UpdateSaleProfile : Profile
    {
        public UpdateSaleProfile()
        {
            CreateMap<Guid, UpdateSaleComand>()
           .ConstructUsing(id => new UpdateSaleComand(id));

            CreateMap<UpdateSaleRequest, UpdateSaleComand>();
            CreateMap<UpdateSaleResult, UpdateSaleResponse>();
        }
    }
}
