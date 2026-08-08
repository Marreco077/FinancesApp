using Finances.DTOs.Users;

namespace Finances.DTOs.Auth;

public sealed record LoginResponseDto(
    string Token,
    DateTime ExpiresAt,
    UserResponseDto User);
