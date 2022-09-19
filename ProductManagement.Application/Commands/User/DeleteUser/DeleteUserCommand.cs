using System.ComponentModel.DataAnnotations;
using MediatR;

namespace ProductManagement.Application.Commands.User.DeleteUser;

public class DeleteUserCommand : IRequest
{
    public DeleteUserCommand(int id)
    {
        Id = id;
    }

    [Required] public int Id { get; set; }
}