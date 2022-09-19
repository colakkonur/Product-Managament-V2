using Microsoft.EntityFrameworkCore;
using ProductManagement.Application.Interfaces.User;
using ProductManagement.Domain.Entities;
using ProductManagement.Infrastructure.Contexts;

namespace ProductManagement.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ProductManagementDbContext _context;

    public UserRepository(ProductManagementDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<User>> GetUsers()
    {
        return await _context.Users.Include(w=>w.Company).ToListAsync();
    }

    public async Task<User> GetUser(int id)
    {
        return await _context.Users.Include(w=>w.Company).FirstOrDefaultAsync(w => w.Id == id);
    }

    public async Task CreateUser(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

    }

    public async Task UpdateUser(User user)
    {
        var vUser = await _context.Users.FirstOrDefaultAsync(w => w.Id == user.Id);
        vUser.NameSurname = (user.NameSurname != "" ? user.NameSurname : vUser.NameSurname);
        vUser.Mail = user.Mail;
        vUser.Password = user.Password;
        vUser.Role = user.Role;
        vUser.Position = user.Position;
        vUser.CompanyId = user.CompanyId;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteUser(int id)
    {
        var vUser = await _context.Users.FirstOrDefaultAsync(w => w.Id == id);
        _context.Remove(vUser);
        await _context.SaveChangesAsync();
    }
}