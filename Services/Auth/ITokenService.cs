using Finances.Entities;

namespace Finances.Services.Auth;

public interface ITokenService
{
    (string Token, DateTime ExpiresAt) CreateToken(User user, IEnumerable<string> roles);

}
