namespace Finances.DTOs;

public sealed record UserResponseDto(
    Guid Id,
    string FirstName,
    string LastName,
    string Nickname,
    string Email,
    DateTimeOffset CreatedAt,
    DateTimeOffset UpdatedAt);