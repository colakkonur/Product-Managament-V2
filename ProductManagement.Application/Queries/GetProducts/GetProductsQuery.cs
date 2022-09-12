using MediatR;

namespace ProductManagement.Application.Queries.GetProducts;

public class GetProductsQuery : IRequest<List<GetProductsQueryResponse>>
{
}