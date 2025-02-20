using AutoMapper;
using DeveloperEvaluation.Application.Sales.CancelSale;

namespace DeveloperEvaluation.WebApi.Features.Sales.DeleteSale
{
    public class CancelSaleProfile : Profile
    {
        public CancelSaleProfile()
        {
            CreateMap<Guid, CancelSaleCommand>()
            .ConstructUsing(id => new CancelSaleCommand(id));

            CreateMap<CancelSaleRequest, CancelSaleCommand>();


            CreateMap<CancelSaleResult, CancelSaleResponse>();
        }
    }
}
