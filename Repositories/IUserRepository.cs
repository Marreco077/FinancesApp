using Finances.Entities;

namespace Finances.Repositories;

public interface IUserRepository
{
    void Create(User user);
    void Delete(User user);
    Task<User?> GetByEmailAsync(string email);
    Task<User?> GetByIdAsync(Guid id);
    Task SaveChangesAsync();
}