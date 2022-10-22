using Microsoft.Extensions.DependencyInjection;
using NPay.Modules.Users.Shared;

namespace NPay.Modules.Users.Api.Modules
{
    public static class Extensions
    {
        public static IServiceCollection AddApi(this IServiceCollection services)
        {
            services.AddTransient<IUsersModuleApi, UsersModuleApi>();

            return services;
        }
    }
}
