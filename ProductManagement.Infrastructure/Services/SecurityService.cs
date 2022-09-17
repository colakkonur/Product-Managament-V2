using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProductManagement.Application.Commands.Security.AuthenticateUser;
using ProductManagement.Application.Interfaces;

namespace ProductManagement.Infrastructure.Services;

public class SecurityService : ISecurityService
{
    private readonly ISecurityRepository _securityRepository;
    private readonly IConfiguration _configuration;

    public SecurityService(ISecurityRepository securityRepository, IConfiguration configuration)
    {
        _securityRepository = securityRepository;
        _configuration = configuration;
    }

    public async Task<AuthenticateUserCommandResponse> GetUserLogin(string mail, string password)
    {
        var vUser = _securityRepository.GetUser(mail, password);
        if (vUser.Result != null)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, vUser.Result.NameSurname),
                new Claim(ClaimTypes.Email, vUser.Result.Mail),
                new Claim(ClaimTypes.Role, vUser.Result.Role),
            };
            var securityKey =
                new SymmetricSecurityKey(
                    System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Secret").Value));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var vUserResponse = new AuthenticateUserCommandResponse()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: credentials
                )),
                Status = new Status()
                {
                    Type = 200,
                    Message = "Success"
                }
            };
            return vUserResponse;
        }
        else
        {
            var vUserResponse = new AuthenticateUserCommandResponse()
            {
                Token = "NOT TOKEN",
                Status = new Status()
                {
                    Type = 401,
                    Message = "Unauthorized"
                }
            };
            return vUserResponse;
        }
    }
}