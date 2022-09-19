using Microsoft.EntityFrameworkCore;
using ProductManagement.Application.Interfaces;
using ProductManagement.Application.Interfaces.Security;
using ProductManagement.Domain.Entities;
using ProductManagement.Infrastructure.Contexts;

namespace ProductManagement.Infrastructure.Repositories;

public class SecurityRepository : ISecurityRepository
{
    private readonly ProductManagementDbContext _context;

    public SecurityRepository(ProductManagementDbContext context)
    {
        _context = context;
    }

    public async Task<User> GetUser(string mail, string password)
    {
        var vUser = await _context.Users.Where(w => w.Mail == mail && w.Password == password)
            .FirstOrDefaultAsync();
        return vUser;
    }
}