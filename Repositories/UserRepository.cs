using Finances.Data;
using Microsoft.EntityFrameworkCore;
using Finances.Entities;

namespace Finances.Repositories;

public class UserRepository : IUserRepository
{
    private readonly FinancesDbContext _context;

    public UserRepository(FinancesDbContext context)
    {
        _context = context;
    }

    public void Create(User user)
    {
        _context.Users.Add(user);
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public void Delete(User user)
    {
        _context.Users.Remove(user);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}