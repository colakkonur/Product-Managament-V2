﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Application.Commands.Product.CreateProduct;
using ProductManagement.Application.Commands.Product.DeleteProduct;
using ProductManagement.Application.Commands.Product.UpdateProduct;
using ProductManagement.Application.Queries.Product.GetProductById;
using ProductManagement.Application.Queries.Product.GetProducts;
using ProductManagement.Application.Queries.Product.GetProductsByCategory;
using ProductManagement.Application.Queries.Product.GetProductsBySearch;

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

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var response = await _mediator.Send(new GetProductsQuery());
        if (!response.Any())
        {
            return NotFound();
        }

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var response = await _mediator.Send(new GetProductByIdQuery(id));
        if (response.Status.Type == 404)
        {
            return NotFound(response);
        }
        return Ok(response);
    }
    
    [HttpGet("GetProductsByCategory/{categoryId}", Name = "GetProductsByCategory")]
    public async Task<IActionResult> GetByCategory(int categoryId)
    {
        var response = await _mediator.Send(new GetProductsByCategoryQuery(categoryId));
        return Ok(response);
    }
    
    [HttpGet("GetProductsBySearch/{searchText}", Name = "GetProductsBySearch")]
    public async Task<IActionResult> GetBySearch(string searchText)
    {
        var response = await _mediator.Send(new GetProductsBySearchQuery(searchText));
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post(CreateProductCommand createProductCommand)
    {
        await _mediator.Send(createProductCommand);
        return Ok();
    }
    
    [HttpPut]
    public async Task<IActionResult> Update(UpdateProductCommand updateProductCommand)
    {
        await _mediator.Send(updateProductCommand);
        return Ok();
    }
    
    [HttpDelete]
    public async Task<IActionResult> Delete(DeleteProductCommand deleteProductCommand)
    {
        await _mediator.Send(deleteProductCommand);
        return Accepted();
    }
}