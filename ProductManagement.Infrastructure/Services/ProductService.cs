using ProductManagement.Application.Commands.Product.CreateProduct;
using ProductManagement.Application.Commands.Product.UpdateProduct;
using ProductManagement.Application.Interfaces;
using ProductManagement.Application.Interfaces.Product;
using ProductManagement.Application.Queries.Product.GetProductById;
using ProductManagement.Application.Queries.Product.GetProducts;
using ProductManagement.Application.Queries.Product.GetProductsByCategory;
using ProductManagement.Application.Queries.Product.GetProductsBySearch;
using ProductManagement.Domain.Entities;

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

    public async Task<List<GetProductsByCategoryQueryResponse>> GetProductsByCategory(int id)
    {
        var vProducts = await _productRepository.GetProductsByCategory(id);
        var vProductsResponse = vProducts.Select(products => new GetProductsByCategoryQueryResponse()
        {
            Id = products.Id,
            Title = products.Title,
            Description = products.Description,
            Tags = products.Tags,
            Image = products.Images.Path,
            Quantity = products.Quantity,
            Price = Convert.ToDouble(products.Prices.Price1),
            Category = products.Category.Name
        }).ToList();
        return vProductsResponse;
    }

    public async Task<List<GetProductsBySearchQueryResponse>> GetProductsBySearch(string key)
    {
        var vProducts = await _productRepository.GetProductBySearch(key);
        var vProductsResponse = vProducts.Select(products => new GetProductsBySearchQueryResponse()
        {
            Id = products.Id,
            Title = products.Title,
            Description = products.Description,
            Tags = products.Tags,
            Image = products.Images.Path,
            Quantity = products.Quantity,
            Price = Convert.ToDouble(products.Prices.Price1),
            Category = products.Category.Name
        }).ToList();
        return vProductsResponse;
    }

    public async Task AddProduct(CreateProductCommand product)
    {
        await _productRepository.CreateProduct(new Product()
        {
            Title = product.Title,
            Description = product.Description,
            Tags = product.Tags,
            Quantity = product.Quantity,
            CategoryId = product.CategoryId,
            Prices = new Price()
            {
                TaxRate = product.Prices.TaxRate,
                TaxAmount = product.Prices.TaxAmount,
                Margin = product.Prices.Margin,
                ShippingCost = product.Prices.ShippingCost
            },
            Images = new Image()
            {
                Path = (string.IsNullOrEmpty(product.Images.Path) ? "default-img.jpg" : product.Images.Path)
            }
        });
    }

    public async Task UpdateProduct(UpdateProductCommand product)
    {
        var vProduct = new Product()
        {
            Id = product.Id,
            Title = product.Title,
            Description = product.Description,
            Tags = product.Tags,
            Quantity = product.Quantity,
            CategoryId = product.CategoryId,
            Prices = new Price()
            {
                TaxRate = product.Prices.TaxRate,
                TaxAmount = product.Prices.TaxAmount,
                Margin = product.Prices.Margin,
                ShippingCost = product.Prices.ShippingCost
            },
            Images = new Image()
            {
                Path = product.Images.Path
            }
        };
        await _productRepository.UpdateProduct(vProduct);
    }

    public async Task DeleteProduct(int id)
    {
        await _productRepository.DeleteProduct(id);
    }
}