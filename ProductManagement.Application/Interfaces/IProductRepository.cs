﻿using ProductManagement.Domain.Entities;

namespace ProductManagement.Application.Interfaces;

public interface IProductRepository
{
    Task<List<Product>> GetProducts();
    Task<Product> GetProduct(int id);
    Task<List<Product>> GetProductsByCategory(int category_id);
    Task<List<Product>> GetProductBySearch(string key);
    Task CreateProduct(Product product);
    Task UpdateProduct(Product product);
    Task DeleteProduct(int id);
}