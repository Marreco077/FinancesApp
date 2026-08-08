using Finances.DTOs.Users;

namespace Finances.Services.Users;

public interface IUserService
{
    Task<UserResponseDto> CreateAsync(CreateUserDto dto);
    Task<UserResponseDto> UpdateAsync(Guid id, UpdateUserDto dto);
    Task DeleteAsync(Guid id);
    Task<UserResponseDto> GetByIdAsync(Guid id);
    Task<IReadOnlyList<UserResponseDto>> GetAllAsync();
}
