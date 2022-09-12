using MediatR;

namespace ProductManagement.Application.Queries.GetProductById;

public class GetProductByIdQuery : IRequest<GetProductByIdQueryResponse>
{
    public int Id { get; set; }

    public GetProductByIdQuery(int id)
    {
        Id = id;
    }
}