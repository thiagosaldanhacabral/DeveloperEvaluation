using MediatR;

namespace DeveloperEvaluation.Application.Products.GetProduct;


public record GetProductCommand : IRequest<GetProductResult>
{

    public Guid Id { get; }


    public GetProductCommand(Guid id)
    {
        Id = id;
    }
}
