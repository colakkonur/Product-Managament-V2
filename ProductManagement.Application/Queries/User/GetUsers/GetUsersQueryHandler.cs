using MediatR;
using ProductManagement.Application.Interfaces.User;

namespace ProductManagement.Application.Queries.User.GetUsers;

public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery,List<GetUsersQueryResponse>>
{
    private readonly IUserService _service;

    public GetUsersQueryHandler(IUserService service)
    {
        _service = service;
    }
    public async Task<List<GetUsersQueryResponse>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        return await _service.GetAllUsers();
    }
}