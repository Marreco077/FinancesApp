using System.ComponentModel.DataAnnotations;

namespace Finances.DTOs;

public sealed record CreateUserDto(
    [Required]
    [StringLength(50, MinimumLength = 2)]
    string FirstName,
    [Required]
    [StringLength(100, MinimumLength = 2)]
    string LastName,
    [Required]
    [StringLength(50, MinimumLength = 2)]
    string Nickname,
    
    [Required]
    [StringLength(100)]
    [EmailAddress]
    string Email,
    
    [Required]
    [StringLength(255, MinimumLength = 8)]
    string Password);