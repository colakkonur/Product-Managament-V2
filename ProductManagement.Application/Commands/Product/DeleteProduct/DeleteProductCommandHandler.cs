using MediatR;
using ProductManagement.Application.Interfaces;

namespace ProductManagement.Application.Commands.Product.DeleteProduct;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly IProductService _service;

    public DeleteProductCommandHandler(IProductService service)
    {
        _service = service;
    }
    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        await _service.DeleteProduct(request.Id);
        return Unit.Value;
    }
}