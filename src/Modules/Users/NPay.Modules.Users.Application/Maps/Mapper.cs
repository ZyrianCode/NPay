using NPay.Modules.Users.Core.Entities;
using NPay.Modules.Users.Shared.DTO;

namespace NPay.Modules.Users.Application.Maps;

internal static class Mapper
{
    public static UserDto MapToDto(this User user) => Map<UserDto>(user);

    public static UserDetailsDto MapToDetailsDto(this User user)
    {
        var dto = Map<UserDetailsDto>(user);
        dto.Address = user.Address;
        dto.Identity = user.Identity;

        return dto;
    }

    private static T Map<T>(this User user) where T : UserDto, new()
        => new()
        {
            UserId = user.Id,
            Email = user.Email,
            FullName = user.FullName,
            Nationality = user.Nationality,
            State = user.VerifiedAt.HasValue ? "verified" : "unverified",
            CreatedAt = user.CreatedAt
        };
}