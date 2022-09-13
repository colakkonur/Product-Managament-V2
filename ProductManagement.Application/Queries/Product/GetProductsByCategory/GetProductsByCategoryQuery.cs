using MediatR;

namespace ProductManagement.Application.Queries.Product.GetProductsByCategory;

public class GetProductsByCategoryQuery : IRequest<List<GetProductsByCategoryQueryResponse>>
{
    public int CategoryId { get; set; }

    public GetProductsByCategoryQuery(int id)
    {
        CategoryId = id;
    }
}