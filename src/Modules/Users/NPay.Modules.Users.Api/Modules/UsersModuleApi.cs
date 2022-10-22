using System;
using System.Threading.Tasks;
using NPay.Modules.Users.Core.Abstractions.Services;
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

    public Task<UserDetailsDto> GetUserAsync(Guid userId) => _usersService.GetAsync(userId);
        
    public Task<UserDetailsDto> GetUserAsync(string email) => _usersService.GetAsync(email);
}