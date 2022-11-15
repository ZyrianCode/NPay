using System;
using System.Threading.Tasks;
using NPay.Modules.Users.Application.Services;
using NPay.Modules.Users.Shared;
using NPay.Modules.Users.Shared.DTO;

namespace NPay.Modules.Users.Api.Modules;

internal sealed class UsersModuleApi : IUsersModuleApi
{
    private readonly IUsersService _usersService;

    public UsersModuleApi(IUsersService usersService)
    {
        _usersService = usersService;
    }

    Task<UserDetailsDto> IUsersModuleApi.GetUserAsync(Guid userId) => _usersService.GetAsync(userId);

    Task<UserDetailsDto> IUsersModuleApi.GetUserAsync(string email) => _usersService.GetAsync(email);
}