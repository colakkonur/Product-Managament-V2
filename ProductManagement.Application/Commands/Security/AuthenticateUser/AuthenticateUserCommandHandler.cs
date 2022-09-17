using MediatR;
using ProductManagement.Application.Interfaces;

namespace ProductManagement.Application.Commands.Security.AuthenticateUser;

public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, AuthenticateUserCommandResponse>
{
    private readonly ISecurityService _service;

    public AuthenticateUserCommandHandler(ISecurityService service)
    {
        _service = service;
    }

    public async Task<AuthenticateUserCommandResponse> Handle(AuthenticateUserCommand request,
        CancellationToken cancellationToken)
    {
        var response = await _service.GetUserLogin(request.Mail, request.Password);
        return response;
    }
}