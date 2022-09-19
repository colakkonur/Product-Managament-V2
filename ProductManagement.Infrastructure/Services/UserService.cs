using ProductManagement.Application.Commands.User.CreateUser;
using ProductManagement.Application.Commands.User.UpdateUser;
using ProductManagement.Application.Interfaces.User;
using ProductManagement.Application.Queries.User.GetUserById;
using ProductManagement.Application.Queries.User.GetUsers;
using ProductManagement.Domain.Entities;
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
            Id = user.Id,
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
        if (vUser is null)
        {
            var vUserResponse = new GetUserByIdQueryResponse()
            {
                Status = new ResposeStatus()
                {
                    Type = 404,
                    Status = "Failed",
                    Message = "User not found."
                }
            };
            return vUserResponse;
        }
        else
        {
            var vUserResponse = new GetUserByIdQueryResponse()
            {
                Id = vUser.Id,
                NameSurname = vUser.NameSurname,
                Mail = vUser.Mail,
                Role = vUser.Role,
                Position = vUser.Position,
                Company = new Application.Queries.User.GetUserById.Company()
                {
                    Name = vUser.Company.Name,
                    FullAdress = vUser.Company.FullAdress
                },
                Status = new ResposeStatus()
                {
                    Type = 200,
                    Status = "Success",
                    Message = "Ok"
                }
            };
            return vUserResponse;
        }
    }

    public async Task CreateUser(CreateUserCommand user)
    {
        await _userRepository.CreateUser(new User()
        {
            NameSurname = user.NameSurname,
            Mail = user.Mail,
            Password = user.Password,
            Role = user.Role,
            Position = user.Position,
            CompanyId = user.CompanyId
        });
    }

    public async Task UpdateUser(UpdateUserCommand user)
    {
        await _userRepository.UpdateUser(new User()
        {
            Id = user.Id,
            NameSurname = user.NameSurname,
            Mail = user.Mail,
            Password = user.Password,
            Role = user.Role,
            Position = user.Position,
            CompanyId = user.CompanyId
        });
    }

    public async Task DeleteUser(int id)
    {
        await _userRepository.DeleteUser(id);
    }
}