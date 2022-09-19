using ProductManagement.Application.Queries.User.GetUserById;
using ProductManagement.Application.Queries.User.GetUsers;

namespace ProductManagement.Application.Interfaces.User;

public interface IUserService
{
    Task<List<GetUsersQueryResponse>> GetAllUsers();
    Task<GetUserByIdQueryResponse> GetUserById(int id);
}