using MediatR;
using DeveloperEvaluation.Domain.Entities;
using DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using DeveloperEvaluation.Application.Event;
using DeveloperEvaluation.Domain.Services;
using Newtonsoft.Json;
using DeveloperEvaluation.Domain.Dto;
using DeveloperEvaluation.Domain.Events;

namespace DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleCommandHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;
    private readonly IRedisService _redisService;
    private readonly EventService _eventService;
    private readonly IProductRepository _productRepository;

    public CreateSaleCommandHandler(ISaleRepository saleRepository, IMapper mapper, IRedisService redisService, EventService eventService,
        IProductRepository productRepository)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
        _redisService = redisService;
        _eventService = eventService;
        _productRepository = productRepository;
    }

    public async Task<CreateSaleResult> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
    {
        try
        {
            decimal totalValue = 0;
            var saleId = Guid.NewGuid();
            var product = new Product();

            var sale = new Sale
            {
                Id = saleId,
                SaleDate = request.SaleDate,
                CustomerId = request.CustomerId,
                SaleProducts = [.. request.SaleItems!.Select(i =>

                {
                    // Applies the limitation of 20 items
                    var quantity = i.Quantity > 20 ? 20 : i.Quantity;

                    if (quantity > 20)
                        throw new Exception("It is not possible to sell more than 20 items");

                    product = _productRepository.GetByIdAsync(i.ProductId).Result;

                    if (product!.Amount < quantity)
                        throw new Exception($"It is not possible to sell the quantity {quantity}. Only {product.Amount} available.");

                    // Calculates the discount based on the quantity
                    decimal discount = 0;
                    if (quantity >= 4 && quantity < 10)
                    {
                        discount = 0.10m; // 10% discount
                    }
                    else if (quantity >= 10 && quantity <= 20)
                    {
                        discount = 0.20m; // 20% discount
                    }

                    // Calculates the total value per product
                    decimal unitPriceWithDiscount = product!.Price * (1 - discount);
                    decimal totalProductValue = quantity * unitPriceWithDiscount;

                    // Updates the total sale value
                    totalValue += totalProductValue;

                    var newAmount = product.Amount - i.Quantity;
                    _productRepository.UpdateAmountAsync(product.Id, newAmount, cancellationToken);

                    // Returns the SaleProduct object with the calculated values
                    return new SaleProduct
                    {
                        SaleId = saleId,
                        ProductId = i.ProductId,
                        Quantity = quantity,
                        UnitPrice = product!.Price,
                        Discount = discount * 100, // Discount in % to save
                        TotalValue = totalProductValue
                    };

                })],
                TotalValue = totalValue
            };

            await _saleRepository.CreateSaleAsync(sale);

            var saleCreatedEvent = new SaleCreatedEvent(
                saleId,
                request.CustomerId,
                Guid.Empty,
                totalValue,
                request.SaleDate,

            [.. request.SaleItems!.Select(i => new SaleItemDto
            {
                ProductId = i.ProductId,
                Quantity = i.Quantity

            })]);

            _eventService.PublishSaleCreatedEvent(saleCreatedEvent);

            _redisService.SetCache($"sale: {sale.Id}", JsonConvert.SerializeObject(request));

            return _mapper.Map<CreateSaleResult>(saleCreatedEvent);
        }
        catch (Exception ex)
        {
            throw new Exception("It was not possible to create the sale", ex);
        }
    }
}
