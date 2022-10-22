using Microsoft.Extensions.DependencyInjection;
using NPay.Modules.Notifications.Shared;

namespace NPay.Modules.Notifications.Api.Modules;

public static class Extensions
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddTransient<INotificationsModuleApi, NotificationsModuleApi>();
        return services;
    }
}