using DeveloperEvaluation.Domain.Dto;
using DeveloperEvaluation.Domain.Entities;
using DeveloperEvaluation.Domain.Repositories;
using DeveloperEvaluation.Domain.Services;
using AutoMapper;
using MediatR;
using Newtonsoft.Json;

namespace DeveloperEvaluation.Application.Sales.GetSale;

public class GetSaleCommandHandler : IRequestHandler<GetSaleCommand, GetSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;
    private readonly IRedisService _redisService;


    public GetSaleCommandHandler(ISaleRepository saleRepository, IMapper mapper, IRedisService redisService)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
        _redisService = redisService;
    }

    public async Task<GetSaleResult> Handle(GetSaleCommand command, CancellationToken cancellationToken)
    {
        var sale = new Sale();
        var saleJson = _redisService.GetCache($"sale:{command.Id}");

        if (saleJson != null)
        {
            sale = JsonConvert.DeserializeObject<Sale>(saleJson);
        }
        else
        {
            sale = await _saleRepository.GetSaleAsync(command.Id);

            if (sale == null)
            {
                throw new KeyNotFoundException($"Not possible get sale. Because not found sale for {command.Id}");
            }
        }

        if (sale == null || sale.SaleProducts == null)
        {
            throw new InvalidOperationException("Sale products cannot be null");
        }

        var getSaleDto = new GetSaleDto(sale.Id, sale.CustomerId, Guid.Empty, sale.TotalValue, sale.SaleDate,
            sale.SaleProducts?.Select(i => new SaleItemDto
            {
                ProductId = i.ProductId,
                Quantity = i.Quantity

            }).ToList() ?? []
        );

        return _mapper.Map<GetSaleResult>(getSaleDto);
    }
}
