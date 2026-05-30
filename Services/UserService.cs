using Finances.DTOs;
using Finances.Entities;
using Finances.Extensions;
using Finances.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Finances.Services;

public class UserService(IUserRepository userRepository, IPasswordHasher<User> passwordHasher) : IUserService
{
    

    public async Task<UserResponseDto> CreateAsync(CreateUserDto dto)
    {
        var existingUser = await userRepository.GetByEmailAsync(dto.Email);

        if (existingUser is not null)
            throw new InvalidOperationException($"User with email '{dto.Email}' already exist");

        var user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            NickName = dto.Nickname,
            Email = dto.Email,
            PasswordHash = string.Empty,
            CreatedAt = DateTimeOffset.UtcNow,
            UpdatedAt = DateTimeOffset.UtcNow
        };
        

        user.PasswordHash = passwordHasher.HashPassword(user, dto.Password);

        userRepository.Create(user);
        await userRepository.SaveChangesAsync();

        return user.ToResponseDto();
    }

    public async Task<UserResponseDto> GetByIdAsync(Guid id)
    {
        var user = await GetUserByIdOrThrowAsync(id);

        return user.ToResponseDto();
    }

    public async Task DeleteAsync(Guid id)
    {
        var user = await GetUserByIdOrThrowAsync(id);

        userRepository.Delete(user);
        
        await userRepository.SaveChangesAsync();
    }

    public async Task<UserResponseDto> UpdateAsync(Guid id, UpdateUserDto dto)
    {
        var user = await GetUserByIdOrThrowAsync(id);

        var existingUser = await userRepository.GetByEmailAsync(dto.Email);

        if (existingUser is not null && existingUser.Id != user.Id)
            throw new InvalidOperationException($"User with email '{dto.Email}' already exists");

        user.FirstName = dto.FirstName;
        user.LastName = dto.LastName;
        user.NickName = dto.Nickname;
        user.Email = dto.Email;
        user.UpdatedAt = DateTimeOffset.UtcNow;

        await userRepository.SaveChangesAsync();

        return user.ToResponseDto();
    }

    private async Task<User> GetUserByIdOrThrowAsync(Guid id)
    {
        var user = await userRepository.GetByIdAsync(id);

        if (user is null)
            throw new KeyNotFoundException($"User with id '{id}' was not found");

        return user;
    }
    
}