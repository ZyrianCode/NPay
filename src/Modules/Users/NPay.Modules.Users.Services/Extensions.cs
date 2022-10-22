using Microsoft.Extensions.DependencyInjection;
using NPay.Modules.Users.Core.Abstractions.Services;
using NPay.Modules.Users.Services.Services;

namespace NPay.Modules.Users.Services;

public static class Extensions
{
    public static IServiceCollection AddServicesLayer(this IServiceCollection services)
    {
        services.AddTransient<IUsersService, UsersService>();

        return services;
    }
}