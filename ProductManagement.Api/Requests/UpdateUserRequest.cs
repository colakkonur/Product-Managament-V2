using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProductManagement.Api.Requests;

public class UpdateUserRequest
{
    [MaxLength(200)]public string NameSurname { get; set; }
    [EmailAddress,MaxLength(200)] public string Mail { get; set; }
    [PasswordPropertyText,MaxLength(200)] public string Password { get; set; }
    [MaxLength(50)]public string Role { get; set; }
    [MaxLength(200)]public string Position { get; set; }
    public int CompanyId { get; set; }
}