using Microsoft.Extensions.DependencyInjection;
using NPay.Modules.Users.Api.Modules;
using NPay.Modules.Users.Shared;

namespace NPay.Modules.Users.Api.Extensions
{
    internal static class LayerExtensions
    {
        public static IServiceCollection AddApi(this IServiceCollection services)
        {
            services.AddTransient<IUsersModuleApi, UsersModuleApi>();

            return services;
        }
    }
}
