using Finances.Entities;

namespace Finances.Repositories;

public interface IUserRepository
{
    Task<User> CreateAsync(User user);
    Task SaveChangesAsync(); // update
    Task<bool> DeleteAsync(Guid id);
    Task<User?> GetByEmailAsync(string email);
    Task<User?> GetByIdAsync(Guid id);
}