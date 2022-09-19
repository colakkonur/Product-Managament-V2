using MediatR;
using ProductManagement.Application.Interfaces.Product;

namespace ProductManagement.Application.Commands.Product.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
{
    private readonly IProductService _service;
    public CreateProductCommandHandler(IProductService service)
    {
        _service = service;
    }
    public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        await _service.AddProduct(request);
        return Unit.Value;
    }
}