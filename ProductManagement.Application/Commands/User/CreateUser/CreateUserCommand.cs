using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace ProductManagement.Application.Commands.User.CreateUser;

public class CreateUserCommand : IRequest
{
    [Required, MaxLength(200)] public string NameSurname { get; set; }

    [Required, EmailAddress, MaxLength(200)]
    public string Mail { get; set; }

    [Required, PasswordPropertyText, MaxLength(200)]
    public string Password { get; set; }

    [Required, MaxLength(50)] public string Role { get; set; }
    [Required, MaxLength(200)] public string Position { get; set; }
    [Required] public int CompanyId { get; set; }
}