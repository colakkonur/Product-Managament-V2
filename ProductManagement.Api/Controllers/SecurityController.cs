using System.IdentityModel.Tokens.Jwt;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProductManagement.Application.Commands.Security.AuthenticateUser;

namespace ProductManagement.Api.Controllers;

[Route("api/authentication")]
[ApiController]
public class SecurityController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IConfiguration _configuration;

    public SecurityController(IMediator mediator, IConfiguration configuration)
    {
        _mediator = mediator;
        _configuration = configuration;
    }

    [HttpPost]
    public async Task<IActionResult> Login(AuthenticateUserCommand userCommand)
    {
        var response = await _mediator.Send(new AuthenticateUserCommand(userCommand.Mail, userCommand.Password));
        if (response.Status.Type == 200)
        {
            return Ok(response);
        }
        else if (response.Status.Type == 401)
        {
            return Unauthorized(response);
        }

        return Ok(response);
    }
}