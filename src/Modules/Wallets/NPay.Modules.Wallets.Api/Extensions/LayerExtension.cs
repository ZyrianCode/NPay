using Microsoft.Extensions.DependencyInjection;
using NPay.Modules.Wallets.Api.Modules;
using NPay.Modules.Wallets.Shared;

namespace NPay.Modules.Wallets.Api.Extensions
{
    public static class LayerExtensions
    {
        public static IServiceCollection AddApi(this IServiceCollection services)
        {
            services.AddTransient<IWalletsModuleApi, WalletsModuleApi>();
            return services;
        }
    }
}
