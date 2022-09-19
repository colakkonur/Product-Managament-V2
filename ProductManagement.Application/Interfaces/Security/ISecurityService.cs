using ProductManagement.Application.Commands.Security.AuthenticateUser;

namespace ProductManagement.Application.Interfaces;

public interface ISecurityService
{
    Task<AuthenticateUserCommandResponse> GetUserLogin(string mail, string password);
}