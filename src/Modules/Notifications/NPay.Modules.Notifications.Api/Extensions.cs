using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NPay.Modules.Notifications.Api.Modules;
using NPay.Modules.Notifications.Core;


namespace NPay.Modules.Notifications.Api;

public static class Extensions
{
    public static IServiceCollection AddNotificationsModule(this IServiceCollection services)
    {
        services.AddCoreLayer();
        services.AddApi();

        return services;
    }
        
    public static IApplicationBuilder UseNotificationsModule(this IApplicationBuilder app)
    {
        return app;
    }
}