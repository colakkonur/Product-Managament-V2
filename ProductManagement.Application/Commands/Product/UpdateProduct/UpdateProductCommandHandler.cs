using MediatR;
using ProductManagement.Application.Interfaces;

namespace ProductManagement.Application.Commands.Product.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
{
    private readonly IProductService _service;

    public UpdateProductCommandHandler(IProductService service)
    {
        _service = service;
    }
    public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        await _service.UpdateProduct(request);
        return Unit.Value;
    }
}