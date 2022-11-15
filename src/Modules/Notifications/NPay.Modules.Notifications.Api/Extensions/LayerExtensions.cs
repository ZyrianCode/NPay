using Microsoft.Extensions.DependencyInjection;
using NPay.Modules.Notifications.Api.Modules;
using NPay.Modules.Notifications.Shared;

namespace NPay.Modules.Notifications.Api.Extensions;

internal static class Extensions
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddTransient<INotificationsModuleApi, NotificationsModuleApi>();
        return services;
    }
}