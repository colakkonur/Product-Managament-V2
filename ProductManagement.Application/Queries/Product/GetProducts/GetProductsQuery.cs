using MediatR;

namespace ProductManagement.Application.Queries.Product.GetProducts;

public class GetProductsQuery : IRequest<List<GetProductsQueryResponse>>
{
}