﻿using AutoMapper;
using MediatR;
using FluentValidation;
using DeveloperEvaluation.Domain.Repositories;
using DeveloperEvaluation.Domain.Entities;
using Newtonsoft.Json;
using DeveloperEvaluation.Domain.Services;

namespace DeveloperEvaluation.Application.Products.CreateProduct;

/// <summary>
/// Handler for processing CreateUserCommand requests
/// </summary>
public class CreateProductHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly IRatingRepository _ratingRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRedisService _redisService;

    
    public CreateProductHandler(IProductRepository productRepository, IMapper mapper, IRatingRepository ratingRepository, 
        IUnitOfWork unitOfWork, IRedisService redisService)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _ratingRepository = ratingRepository;
        _unitOfWork = unitOfWork;
        _redisService = redisService;
    }


    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateProductComandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var existingProduct = await _productRepository.GetByTitleAsync(command.Title, cancellationToken);
        if (existingProduct != null)
            throw new InvalidOperationException($"Product with title {command.Title} already exists");


            var rating = new Rating
            {
                Id = Guid.NewGuid(),
                Rate = command.Rate,
                Count = command.Count
            };

            await _ratingRepository.CreateAsync(rating);

            var product = _mapper.Map<Product>(command);
            product.Id = Guid.NewGuid();
            product.RatingId = rating.Id;

            var createdProduct = await _productRepository.CreateAsync(product, cancellationToken);

            // Salvar todas as alterações no banco de dados
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            _redisService.SetCache($"product:{product.Id}", JsonConvert.SerializeObject(command));

            var products = await _productRepository.GetByIdAsync(product.Id);
            var result = _mapper.Map<CreateProductResult>(products);

            return result;

    }
}
