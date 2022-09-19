using ProductManagement.Application.Commands.Product.CreateProduct;
using ProductManagement.Application.Commands.Product.UpdateProduct;
using ProductManagement.Application.Queries.Product.GetProductById;
using ProductManagement.Application.Queries.Product.GetProducts;
using ProductManagement.Application.Queries.Product.GetProductsByCategory;
using ProductManagement.Application.Queries.Product.GetProductsBySearch;

namespace ProductManagement.Application.Interfaces.Product;

public interface IProductService
{
    Task<List<GetProductsQueryResponse>> GetAllProducts();
    Task<GetProductByIdQueryResponse> GetProductById(int id);
    Task<List<GetProductsByCategoryQueryResponse>> GetProductsByCategory(int id);
    Task<List<GetProductsBySearchQueryResponse>> GetProductsBySearch(string key);
    Task AddProduct(CreateProductCommand product);
    Task UpdateProduct(UpdateProductCommand product);
    Task DeleteProduct(int id);
}