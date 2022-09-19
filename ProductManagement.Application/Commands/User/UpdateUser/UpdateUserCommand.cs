using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace ProductManagement.Application.Commands.User.UpdateUser;

public class UpdateUserCommand : IRequest
{
    public UpdateUserCommand(int id, string sNameSurname, string sMail, string sPassword, string sRole,
        string sPosition, int iCompanyId)
    {
        Id = id;
        NameSurname = sNameSurname;
        Mail = sMail;
        Password = sPassword;
        Role = sRole;
        Position = sPosition;
        CompanyId = iCompanyId;
    }

    public int Id { get; set; }
    public string NameSurname { get; set; }
    [EmailAddress] public string Mail { get; set; }
    [PasswordPropertyText] public string Password { get; set; }
    public string Role { get; set; }
    public string Position { get; set; }
    public int CompanyId { get; set; }
}