using Microsoft.Extensions.DependencyInjection;
using NPay.Modules.Wallets.Shared;

namespace NPay.Modules.Wallets.Api.Modules
{
    public static class Extensions
    {
        public static IServiceCollection AddApi(this IServiceCollection services)
        {
            services.AddTransient<IWalletsModuleApi, WalletsModuleApi>();
            return services;
        }
    }
}
