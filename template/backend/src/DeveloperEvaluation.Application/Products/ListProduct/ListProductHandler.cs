using AutoMapper;
using MediatR;
using FluentValidation;
using DeveloperEvaluation.Domain.Repositories;
using DeveloperEvaluation.Domain.Entities;
using System.Linq.Dynamic.Core;
using DeveloperEvaluation.Application.Users.ListUser;
using DeveloperEvaluation.Common.Common;

namespace DeveloperEvaluation.Application.Products.ListProduct;

/// <summary>
/// Handler for processing GetUserCommand requests
/// </summary>
public class ListProductHandler : IRequestHandler<ListProductCommand, PaginatedList<Product>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ListProductHandler(
        IProductRepository productRepository,
        IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }


    public async Task<PaginatedList<Product>> Handle(ListProductCommand request, CancellationToken cancellationToken)
    {
        var validator = new ListProductValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var query = _productRepository.GetAllAsync(cancellationToken)
        .OrderBy(request.Order);

        return PaginatedList<Product>.CreateAsync(query, request.Page, request.Size).Result;
    }
}
