using Microsoft.Extensions.DependencyInjection;

namespace NPay.Modules.Wallets.Application;

internal static class LayerExtensions
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        return services;
    }
}