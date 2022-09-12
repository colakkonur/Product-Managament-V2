using ProductManagement.Application.Interfaces;
using ProductManagement.Application.Queries.GetProductById;
using ProductManagement.Application.Queries.GetProducts;

namespace ProductManagement.Infrastructure.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<GetProductsQueryResponse>> GetAllProducts()
    {
        var vProducts = await _productRepository.GetProducts();
        var vProductsResponse = vProducts.Select(products => new GetProductsQueryResponse
        {
            Id = products.Id,
            Title = products.Title,
            Description = products.Description,
            Image = products.Images.Path,
            Quantity = products.Quantity,
            Price = Convert.ToDouble(products.Prices.Price1),
            Tags = products.Tags,
            Category = products.Category.Name
        }).ToList();
        return vProductsResponse;
    }

    public async Task<GetProductByIdQueryResponse> GetProductById(int id)
    {
        var vProduct = await _productRepository.GetProduct(id);
        if (vProduct is null)
        {
            var vProductResponse = new GetProductByIdQueryResponse
            {
                Status = new ResposeStatus()
                {
                    Type = 404,
                    Status = "Failed",
                    Message = "The product was not found."
                }
            };
            return vProductResponse;
        }
        else
        {
            var vProductResponse = new GetProductByIdQueryResponse
            {
                Id = vProduct.Id,
                Title = vProduct.Title,
                Description = vProduct.Description,
                Image = vProduct.Images.Path,
                Quantity = vProduct.Quantity,
                Price = Convert.ToDouble(vProduct.Prices.Price1),
                Tags = vProduct.Tags,
                Category = vProduct.Category.Name,
                Status = new ResposeStatus()
                {
                    Type = 200,
                    Status = "Success",
                    Message = "Ok"
                }
            };
            return vProductResponse;
        }
    }
}