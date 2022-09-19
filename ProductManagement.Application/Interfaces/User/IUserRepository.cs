namespace ProductManagement.Application.Interfaces.User;
using Domain.Entities;
public interface IUserRepository
{
    Task<List<User>> GetUsers();
    Task<User> GetUser(int id);
    Task CreateUser(User user);
    Task UpdateUser(User user);
    Task DeleteUser(int id);
}