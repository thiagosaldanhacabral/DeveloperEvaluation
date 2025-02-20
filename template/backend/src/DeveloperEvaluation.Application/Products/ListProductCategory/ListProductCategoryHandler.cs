using AutoMapper;
using MediatR;
using FluentValidation;
using DeveloperEvaluation.Domain.Repositories;
using DeveloperEvaluation.Domain.Entities;
using System.Linq.Dynamic.Core;
using DeveloperEvaluation.Common.Common;

namespace DeveloperEvaluation.Application.Products.ListProductCategory;

/// <summary>
/// Handler for processing GetUserCommand requests
/// </summary>
public class ListProductCategoryHandler : IRequestHandler<ListProductCategoryCommand, PaginatedList<Product>>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ListProductCategoryHandler(
        IProductRepository productRepository,
        IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }


    public async Task<PaginatedList<Product>> Handle(ListProductCategoryCommand request, CancellationToken cancellationToken)
    {
        var validator = new ListProductCategoryValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var query = _productRepository.GetAllAsync(cancellationToken).Where(c=> c.Category == request.Category)
        .OrderBy(request.Order);

        return PaginatedList<Product>.CreateAsync(query, request.Page, request.Size).Result;
    }
}
