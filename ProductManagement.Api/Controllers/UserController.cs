using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        return Ok(response);
    }
}