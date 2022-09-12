using MediatR;
using ProductManagement.Application.Interfaces;

namespace ProductManagement.Application.Queries.Product.GetProductById;

public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery,GetProductByIdQueryResponse>
{
    private readonly IProductService _service;

    public GetProductByIdQueryHandler(IProductService service)
    {
        _service = service;
    }
    public async Task<GetProductByIdQueryResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var response = await _service.GetProductById(request.Id);
        return response;
    }
    
    
}