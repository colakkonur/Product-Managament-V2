using MediatR;
using ProductManagement.Application.Interfaces.User;

namespace ProductManagement.Application.Queries.User.GetUserById;

public class GetUserByIdQueryHandler :IRequestHandler<GetUserByIdQuery,GetUserByIdQueryResponse>
{
    private readonly IUserService _service;

    public GetUserByIdQueryHandler(IUserService service)
    {
        _service = service;
    }
    public async Task<GetUserByIdQueryResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        return await _service.GetUserById(request.Id);
    }
}