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

    public async Task CreateProduct(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateProduct(Product product)
    {
        var vProduct = await _context.Products.FirstOrDefaultAsync(w => w.Id == product.Id);
        vProduct.Title = product.Title;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteProduct(int id)
    {
        var vProduct = await _context.Products.FirstOrDefaultAsync(w => w.Id == id);
        _context.Products.Remove(vProduct);
        await _context.SaveChangesAsync();
    }
}