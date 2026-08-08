using Finances.DTOs.Auth;
using Finances.Entities;
using Finances.Extensions;
using Finances.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Finances.Services.Auth;

public class AuthService(
    IUserRepository userRepository,
    IPasswordHasher<User> passwordHasher,
    ITokenService tokenService) : IAuthService
{
    public async Task<LoginResponseDto> LoginAsync(LoginDto dto)
    {
        var user = await userRepository.GetByEmailAsync(dto.Email);

        if (user is null)
            throw new UnauthorizedAccessException("Invalid email or password!");

        var result = passwordHasher.VerifyHashedPassword(
            user,
            user.PasswordHash,
            dto.Password);

        if (result == PasswordVerificationResult.Failed)
            throw new UnauthorizedAccessException("Invalid eamil or password");
        
        var roles = new[] { "User" };

        var tokenResult = tokenService.CreateToken(user, roles);

        return new LoginResponseDto(
            tokenResult.Token,
            tokenResult.ExpiresAt,
            user.ToResponseDto());
    }
}
