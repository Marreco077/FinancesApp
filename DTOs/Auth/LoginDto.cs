using System.ComponentModel.DataAnnotations;

namespace Finances.DTOs.Auth;

public sealed record LoginDto(
    [Required]
    [EmailAddress]
    string Email,

    [Required]
    string Password);
