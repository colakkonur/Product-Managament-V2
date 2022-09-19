namespace ProductManagement.Application.Interfaces.Security;
using Domain.Entities;

public interface ISecurityRepository
{
    Task<User> GetUser(string mail, string password);
}