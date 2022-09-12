using ProductManagement.Application.Queries.GetProductById;
using ProductManagement.Application.Queries.GetProducts;

namespace ProductManagement.Application.Interfaces;

public interface IProductService
{
    Task<List<GetProductsQueryResponse>> GetAllProducts();
    Task<GetProductByIdQueryResponse> GetProductById(int id);
}