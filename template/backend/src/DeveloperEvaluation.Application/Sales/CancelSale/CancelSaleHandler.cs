using DeveloperEvaluation.Application.Event;
using DeveloperEvaluation.Domain.Dto;
using DeveloperEvaluation.Domain.Events;
using DeveloperEvaluation.Domain.Repositories;
using DeveloperEvaluation.Domain.Services;
using AutoMapper;
using MediatR;

namespace DeveloperEvaluation.Application.Sales.CancelSale;

public class CancelSaleCommandHandler : IRequestHandler<CancelSaleCommand, CancelSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;
    private readonly IRedisService _redisService;
    private readonly EventService _eventService;

    public CancelSaleCommandHandler(ISaleRepository saleRepository, IMapper mapper, IRedisService redisService, EventService eventService)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
        _redisService = redisService;
        _eventService = eventService;
    }

    public async Task<CancelSaleResult> Handle(CancelSaleCommand request, CancellationToken cancellationToken)
    {
        var sale = _saleRepository.GetSaleAsync(request.Id).Result ?? throw new KeyNotFoundException($"Not possible cancelled sale. Because not found sale for {request.Id}");
        if (sale.Canceled == true)
            throw new InvalidOperationException($"Not possible cancelled sale. Because in sale with status cancelada");

        sale.Canceled = true;
        await _saleRepository.UpdateSaleAsync(request.Id, sale);

        var saleCancelledEvent = new SaleCancelledEvent(
                sale.Id,
                sale.CustomerId,
                Guid.Empty,
                sale.TotalValue,
                sale.SaleDate,

            [.. sale.SaleProducts!.Select(i => new SaleItemDto
            {
                ProductId = i.ProductId,
                Quantity = i.Quantity

            })],
            "Sale Canceled"
        );

        _eventService.PublishSaleCancelledEvent(saleCancelledEvent);

        _redisService.RemoveCache($"sale: {sale.Id}");

        return _mapper.Map<CancelSaleResult>(saleCancelledEvent);
    }
}
