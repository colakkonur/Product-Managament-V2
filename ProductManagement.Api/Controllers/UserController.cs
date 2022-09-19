using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Api.Requests;
using ProductManagement.Application.Commands.User.CreateUser;
using ProductManagement.Application.Commands.User.DeleteUser;
using ProductManagement.Application.Commands.User.UpdateUser;
using ProductManagement.Application.Queries.User.GetUserById;
using ProductManagement.Application.Queries.User.GetUsers;

namespace ProductManagement.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var response = await _mediator.Send(new GetUsersQuery());
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var response = await _mediator.Send(new GetUserByIdQuery(id));
        if (response.Status.Type == 404)
        {
            return NotFound(response);
        }

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateUserCommand createUserCommand)
    {
        await _mediator.Send(createUserCommand);
        return Ok();
    }

    [HttpPut(("{id}"))]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUserRequest updateUserRequest)
    {
        await _mediator.Send(new UpdateUserCommand(id, updateUserRequest.NameSurname, updateUserRequest.Mail,
            updateUserRequest.Password,
            updateUserRequest.Role, updateUserRequest.Position, updateUserRequest.CompanyId));
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        await _mediator.Send(new DeleteUserCommand(id));
        return Ok();
    }
}