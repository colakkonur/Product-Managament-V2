using MediatR;
using ProductManagement.Application.Interfaces.User;

namespace ProductManagement.Application.Commands.User.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
{
    private readonly IUserService _service;

    public UpdateUserCommandHandler(IUserService service)
    {
        _service = service;
    }
    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        await _service.UpdateUser(request);
        return Unit.Value;
    }
}