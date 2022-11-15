using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NPay.Modules.Notifications.Application;
using NPay.Modules.Notifications.Core;
using NPay.Modules.Notifications.Data;

namespace NPay.Modules.Notifications.Api.Extensions;

public static class ModuleExtensions
{
    public static IServiceCollection AddNotificationsModule(this IServiceCollection services)
    {
        services.AddCoreLayer();
        services.AddDataLayer();
        services.AddApplicationLayer();
        services.AddApi();

        return services;
    }
        
    public static IApplicationBuilder UseNotificationsModule(this IApplicationBuilder app)
    {
        return app;
    }
}