using MediatR;
using ProductManagement.Application.Interfaces;

namespace ProductManagement.Application.Queries.GetProducts;

public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<GetProductsQueryResponse>>
{
    private readonly IProductService _service;

    public GetProductsQueryHandler(IProductService service)
    {
        _service = service;
    }
    public async Task<List<GetProductsQueryResponse>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        return await _service.GetAllProducts();
    }
}