using NPay.Modules.Users.Shared.DTO;

namespace NPay.Modules.Users.Application.Services;

internal interface IUsersService
{
    internal Task<UserDetailsDto> GetAsync(Guid userId);
    internal Task<UserDetailsDto> GetAsync(string email);
    internal Task<IReadOnlyList<UserDto>> BrowseAsync();
    internal Task AddAsync(UserDetailsDto dto);
    internal Task VerifyAsync(Guid userId);
}