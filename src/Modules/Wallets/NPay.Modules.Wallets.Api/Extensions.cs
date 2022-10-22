using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NPay.Modules.Wallets.Api.Modules;
using NPay.Modules.Wallets.Application;
using NPay.Modules.Wallets.Core;
using NPay.Modules.Wallets.Data;


namespace NPay.Modules.Wallets.Api;

public static class Extensions
{
    public static IServiceCollection AddWalletsModule(this IServiceCollection services)
    {
        services.AddCoreLayer();
        services.AddApplicationLayer();
        services.AddDataLayer();
        services.AddApi();
        return services;
    }

    public static IApplicationBuilder UseWalletsModule(this IApplicationBuilder app)
    {
        return app;
    }
}