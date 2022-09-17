using ProductManagement.Domain.Entities;

namespace ProductManagement.Application.Interfaces;

public interface ISecurityRepository
{
    Task<User> GetUser(string mail, string password);
}