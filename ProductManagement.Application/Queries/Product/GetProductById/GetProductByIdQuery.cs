using MediatR;

namespace ProductManagement.Application.Queries.Product.GetProductById;

public class GetProductByIdQuery : IRequest<GetProductByIdQueryResponse>
{
    public int Id { get; set; }

    public GetProductByIdQuery(int id)
    {
        Id = id;
    }
}