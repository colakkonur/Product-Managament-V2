﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Application.Queries.Product.GetProductById;
using ProductManagement.Application.Queries.Product.GetProducts;

namespace ProductManagement.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(Name = "GetAllProducts")]
    public async Task<IActionResult> Get()
    {
        var response = await _mediator.Send(new GetProductsQuery());
        if (!response.Any())
        {
            return NotFound();
        }

        return Ok(response);
    }

    [HttpGet("{id}", Name = "GetProductById")]
    public async Task<IActionResult> GetById(int id)
    {
        var response = await _mediator.Send(new GetProductByIdQuery(id));
        if (response.Status.Type == 404)
        {
            return NotFound(response);
        }
        return Ok(response);
    }
}