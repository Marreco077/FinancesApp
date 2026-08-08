using Finances.DTOs.Users;
using Finances.Entities;

namespace Finances.Extensions;

public static class UserMapping
{
    public static UserResponseDto ToResponseDto(this User user)
    {
        return new UserResponseDto(
            user.Id,
            user.FirstName,
            user.LastName,
            user.NickName,
            user.Email,
            user.CreatedAt,
            user.UpdatedAt
        );
    }
}
