using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NPay.Modules.Users.Api.Modules;
using NPay.Modules.Users.Core;
using NPay.Modules.Users.Data;
using NPay.Modules.Users.Services;


namespace NPay.Modules.Users.Api;

public static class Extensions
{
    public static IServiceCollection AddUsersModule(this IServiceCollection services)
    {
        services.AddCoreLayer();
        services.AddDataLayer();
        services.AddServicesLayer();
        services.AddApi();
        return services;
    }
        
    public static IApplicationBuilder UseUsersModule(this IApplicationBuilder app)
    {
        return app;
    }
}