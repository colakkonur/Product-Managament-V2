using MediatR;
using ProductManagement.Application.Interfaces.User;

namespace ProductManagement.Application.Commands.User.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
{
    private readonly IUserService _service;

    public CreateUserCommandHandler(IUserService service)
    {
        _service = service;
    }
    public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        await _service.CreateUser(request);
        return Unit.Value;
    }
}