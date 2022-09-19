using MediatR;
using ProductManagement.Application.Interfaces;
using ProductManagement.Application.Interfaces.Product;

namespace ProductManagement.Application.Queries.Product.GetProductsBySearch;

public class GetProductsBySearchQueryHandler : IRequestHandler<GetProductsBySearchQuery,List<GetProductsBySearchQueryResponse>>
{
    private readonly IProductService _service;

    public GetProductsBySearchQueryHandler(IProductService service)
    {
        _service = service;
    }
    public async Task<List<GetProductsBySearchQueryResponse>> Handle(GetProductsBySearchQuery request, CancellationToken cancellationToken)
    {
        return await _service.GetProductsBySearch(request.SearchText);
    }
}