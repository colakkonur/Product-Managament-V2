using Microsoft.EntityFrameworkCore;
using ProductManagement.Application.Interfaces;
using ProductManagement.Domain.Entities;
using ProductManagement.Infrastructure.Contexts;

namespace ProductManagement.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ProductManagementDbContext _context;

    public ProductRepository(ProductManagementDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetProducts()
    {
        return await _context.Products
            .Include(w => w.Category)
            .Include(w => w.Images)
            .Include(w => w.Prices)
            .ToListAsync();
    }

    public async Task<Product> GetProduct(int id)
    {
        return await _context.Products.Where(w => w.Id == id)
            .Include(w => w.Category)
            .Include(w => w.Images)
            .Include(w => w.Prices)
            .FirstOrDefaultAsync();
    }

    public async Task<List<Product>> GetProductsByCategory(int id)
    {
        return await _context.Products.Where(w => w.CategoryId == id)
            .Include(w => w.Category)
            .Include(w => w.Images)
            .Include(w => w.Prices)
            .ToListAsync();
    }

    public async Task<List<Product>> GetProductBySearch(string key)
    {
        return await _context.Products.Where(w => w.Title.Contains(key))
            .Include(w => w.Category)
            .Include(w => w.Images)
            .Include(w => w.Prices)
            .ToListAsync();
    }

    public async Task CreateProduct(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.Prices.AddAsync(product.Prices);
        await _context.Images.AddAsync(product.Images);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateProduct(Product product)
    {
        var vProduct = await _context.Products
            .Include(w => w.Category)
            .Include(w => w.Images)
            .Include(w => w.Prices)
            .FirstOrDefaultAsync(w => w.Id == product.Id);

        vProduct.Title = product.Title;
        vProduct.Description = product.Description;
        vProduct.Tags = product.Tags;
        vProduct.Quantity = product.Quantity;
        vProduct.CategoryId = product.CategoryId;
        vProduct.Prices.TaxRate = product.Prices.TaxRate;
        vProduct.Prices.TaxAmount = product.Prices.TaxAmount;
        vProduct.Prices.Margin = product.Prices.Margin;
        vProduct.Prices.ShippingCost = product.Prices.ShippingCost;
        vProduct.Images.Path = product.Images.Path;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteProduct(int id)
    {
        var vProduct = await _context.Products
            .Include(w => w.Prices)
            .Include(w => w.Images)
            .FirstOrDefaultAsync(w => w.Id == id);
        _context.Remove(vProduct);
        _context.Remove(vProduct.Images);
        _context.Remove(vProduct.Prices);
        await _context.SaveChangesAsync();
    }
}