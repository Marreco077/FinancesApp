using System.ComponentModel.DataAnnotations;

namespace Finances.DTOs;

public sealed record UpdateUserDto(
    [StringLength(50, MinimumLength = 2)]
    string FirstName,
    [StringLength(50, MinimumLength = 2)]
    string LastName,
    [StringLength(50, MinimumLength = 2)]
    string Nickname,
    [StringLength(100)]
    [EmailAddress]
    string Email);