using MediatR;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ProductManagement.Application.Commands.Security.AuthenticateUser;

public class AuthenticateUserCommand : IRequest<AuthenticateUserCommandResponse>
{
    public AuthenticateUserCommand(string mail, string password)
    {
        Mail = mail;
        Password = password;
    }
    
    [EmailAddress,Required]
    public string Mail { get; set; }
    [PasswordPropertyText,Required]
    public string Password { get; set; }
    
}