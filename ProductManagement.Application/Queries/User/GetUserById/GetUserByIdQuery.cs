using MediatR;

namespace ProductManagement.Application.Queries.User.GetUserById;

public class GetUserByIdQuery : IRequest<GetUserByIdQueryResponse>
{
    public int Id { get; set; }

    public GetUserByIdQuery(int id)
    {
        Id = id;
    }
}
