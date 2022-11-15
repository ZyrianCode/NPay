using Microsoft.Extensions.DependencyInjection;
using NPay.Modules.Wallets.Core.Wallets.Services;

namespace NPay.Modules.Wallets.Core;

internal static class LayerExtensions
{
    public static IServiceCollection AddCoreLayer(this IServiceCollection services)
    {
        services.AddSingleton<ICurrencyResolver, CurrencyResolver>();
            
        return services;
    }
}