using NPay.Modules.Users.Shared.DTO;

namespace NPay.Modules.Users.Core.Abstractions.Services;

internal interface IUsersService
{
    Task<UserDetailsDto> GetAsync(Guid userId);
    Task<UserDetailsDto> GetAsync(string email);
    Task<IReadOnlyList<UserDto>> BrowseAsync();
    Task AddAsync(UserDetailsDto dto);
    Task VerifyAsync(Guid userId);
}