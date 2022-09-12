﻿using ProductManagement.Application.Queries.Product.GetProductById;
using ProductManagement.Application.Queries.Product.GetProducts;

namespace ProductManagement.Application.Interfaces;

public interface IProductService
{
    Task<List<GetProductsQueryResponse>> GetAllProducts();
    Task<GetProductByIdQueryResponse> GetProductById(int id);
}