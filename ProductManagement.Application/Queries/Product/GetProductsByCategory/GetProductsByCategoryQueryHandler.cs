using MediatR;
using ProductManagement.Application.Interfaces;

namespace ProductManagement.Application.Queries.Product.GetProductsByCategory;

public class GetProductsByCategoryQueryHandler : IRequestHandler<GetProductsByCategoryQuery,List<GetProductsByCategoryQueryResponse>>
{
    private readonly IProductService _service;

    public GetProductsByCategoryQueryHandler(IProductService service)
    {
        _service = service;
    }
    public async Task<List<GetProductsByCategoryQueryResponse>> Handle(GetProductsByCategoryQuery request, CancellationToken cancellationToken)
    {
        var response = await _service.GetProductsByCategory(request.CategoryId);
        return response;
    }
}