using Microsoft.Extensions.DependencyInjection;
using NPay.Modules.Users.Data.DAL.Contexts;
using NPay.Shared.Database;

namespace NPay.Modules.Users.Data;

internal static class LayerExtensions
{
    public static IServiceCollection AddDataLayer(this IServiceCollection services)
    {
        services.AddPostgres<UsersDbContext>();
        
        return services;
    }
}