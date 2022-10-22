using Microsoft.Extensions.DependencyInjection;

namespace NPay.Modules.Wallets.Application;

public static class Extensions
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        return services;
    }
}