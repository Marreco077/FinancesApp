namespace Finances.DTOs;

public sealed record CreateUserDto(
    string FirstName,
    string LastName,
    string Nickname,
    string Email,
    string Password);