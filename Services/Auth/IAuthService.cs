using Finances.DTOs.Auth;

namespace Finances.Services.Auth;

public interface IAuthService
{
    Task<LoginResponseDto> LoginAsync(LoginDto dto);
}
