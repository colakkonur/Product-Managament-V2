using System.Security.Claims;

namespace ProductManagement.Application.Commands.Security.AuthenticateUser;

public class AuthenticateUserCommandResponse
{
    public string Token { get; set; }
    public Status Status { get; set; }
}

public class Status
{
    public int Type { get; set; }
    public string Message { get; set; }
}