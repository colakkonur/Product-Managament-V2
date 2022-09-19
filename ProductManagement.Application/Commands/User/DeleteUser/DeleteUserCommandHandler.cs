using MediatR;
using ProductManagement.Application.Interfaces.User;

namespace ProductManagement.Application.Commands.User.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly IUserService _service;

    public DeleteUserCommandHandler(IUserService service)
    {
        _service = service;
    }
    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        await _service.DeleteUser(request.Id);
        return Unit.Value;
    }
}