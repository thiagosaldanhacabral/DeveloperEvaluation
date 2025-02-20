using DeveloperEvaluation.Application.Event;
using DeveloperEvaluation.Domain.Dto;
using DeveloperEvaluation.Domain.Entities;
using DeveloperEvaluation.Domain.Events;
using DeveloperEvaluation.Domain.Repositories;
using DeveloperEvaluation.Domain.Services;
using AutoMapper;
using MediatR;
using Newtonsoft.Json;

namespace DeveloperEvaluation.Application.Sales.UpdateSale;

public class UpdateSaleCommandHandler : IRequestHandler<UpdateSaleComand, UpdateSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;
    private readonly IRedisService _redisService;
    private readonly EventService _eventService;
    private readonly IProductRepository _productRepository;

    public UpdateSaleCommandHandler(ISaleRepository saleRepository, IMapper mapper, IRedisService redisService, EventService eventService,
        IProductRepository productRepository)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
        _redisService = redisService;
        _eventService = eventService;
        _productRepository = productRepository;
    }

    public async Task<UpdateSaleResult> Handle(UpdateSaleComand request, CancellationToken cancellationToken)
    {
        decimal totalValue = 0;
        var existingSale = _saleRepository.GetSaleAsync(request.Id).Result ?? throw new KeyNotFoundException($"Sale not found for Id {request.CustomerId}");
        existingSale.SaleDate = request.SaleDate;
        existingSale.CustomerId = request.CustomerId;
        existingSale.SaleProducts = [.. request!.SaleItems!.Select(i =>
        {
            if (i.Quantity > 20)
                throw new Exception("Cannot sell more than 20 items");

            var product = _productRepository.GetByIdAsync(i.ProductId).Result ?? throw new Exception($"Not found registry for Id: {i.ProductId}.");

            // Check the previous quantity (product quantity in the existing sale)
            var existingSaleProduct = existingSale!.SaleProducts!.FirstOrDefault(p => p.ProductId == i.ProductId);
            if (existingSaleProduct != null)
            {
                // If the quantity has changed, adjust the stock
                var previousQuantity = existingSaleProduct.Quantity;
                if (i.Quantity > previousQuantity)
                {
                    // If the quantity has increased, reduce the stock
                    var newStock = product.Amount - (i.Quantity - previousQuantity);
                    if (newStock < 0)
                        throw new Exception($"Insufficient stock for the requested quantity. Only {product.Amount} are available.");

                    // Update the stock
                    _productRepository.UpdateAmountAsync(product.Id, newStock, cancellationToken);
                }
                else if (i.Quantity < previousQuantity)
                {
                    // If the quantity has decreased, increase the stock
                    var newStock = product.Amount + (previousQuantity - i.Quantity);

                    if (newStock < 0)
                        throw new Exception($"Insufficient stock for the requested quantity. Only {product.Amount} are available.");
                    _productRepository.UpdateAmountAsync(product.Id, newStock, cancellationToken);
                }
            }

            // Calculate the discount based on the quantity
            decimal discount = 0;
            if (i.Quantity >= 4 && i.Quantity < 10)
            {
                discount = 0.10m; // 10% discount
            }
            else if (i.Quantity >= 10 && i.Quantity <= 20)
            {
                discount = 0.20m; // 20% discount
            }

            // Calculate the total value per product
            decimal unitPriceWithDiscount = product!.Price * (1 - discount);
            decimal totalProductValue = i.Quantity * unitPriceWithDiscount;

            // Update the total sale value
            totalValue += totalProductValue;

            // Return the SaleProduct object with the calculated values
            var saleProduct = new SaleProduct
            {
                SaleId = existingSale.Id,
                ProductId = i.ProductId,
                Quantity = i.Quantity,
                UnitPrice = product!.Price,
                Discount = discount * 100, // Discount in % to save
                TotalValue = totalProductValue
            };

            return saleProduct;

        })];
        existingSale.TotalValue = totalValue;

        await _saleRepository.UpdateSaleAsync(request.Id, existingSale);

        var saleModifiedEvent = new SaleModifiedEvent(
                existingSale.Id,
                request.CustomerId,
                Guid.Empty,
                totalValue,
                request.SaleDate,

            [.. request.SaleItems!.Select(i => new SaleItemDto
            {
                ProductId = i.ProductId,
                Quantity = i.Quantity

            })]
        );

        _eventService.PublishSaleModifiedEvent(saleModifiedEvent);

        _redisService.SetCache($"sale: {existingSale.Id}", JsonConvert.SerializeObject(saleModifiedEvent));

        return _mapper.Map<UpdateSaleResult>(saleModifiedEvent);
    }
}
