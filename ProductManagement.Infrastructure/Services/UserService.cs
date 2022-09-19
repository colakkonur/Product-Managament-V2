using ProductManagement.Application.Interfaces.User;
using ProductManagement.Application.Queries.User.GetUserById;
using ProductManagement.Application.Queries.User.GetUsers;
using Company = ProductManagement.Application.Queries.User.GetUsers.Company;

namespace ProductManagement.Infrastructure.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<GetUsersQueryResponse>> GetAllUsers()
    {
        var vUser = await _userRepository.GetUsers();
        var vUserResponse = vUser.Select(user => new GetUsersQueryResponse()
        {
            NameSurname = user.NameSurname,
            Mail = user.Mail,
            Role = user.Role,
            Position = user.Position,
            Company = new Company()
            {
                Name = user.Company.Name,
                FullAdress = user.Company.FullAdress
            }
        }).ToList();
        return vUserResponse;
    }

    public async Task<GetUserByIdQueryResponse> GetUserById(int id)
    {
        var vUser = await _userRepository.GetUser(id);
        var vUserResponse = new GetUserByIdQueryResponse()
        {
            NameSurname = vUser.NameSurname,
            Mail = vUser.Mail,
            Role = vUser.Role,
            Position = vUser.Position,
            Company = new Application.Queries.User.GetUserById.Company()
            {
                Name = vUser.Company.Name,
                FullAdress = vUser.Company.FullAdress
            }
        };
        return vUserResponse;
    }
    
}