namespace Finances.DTOs;

public sealed record UpdateUserDto(
    string FirstName,
    string LastName,
    string Nickname,
    string Email);