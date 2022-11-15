using Microsoft.Extensions.DependencyInjection;
using NPay.Modules.Notifications.Application.Services;
using NPay.Modules.Notifications.Data.Services;

namespace NPay.Modules.Notifications.Data;

internal static class LayerExtensions
{
    public static IServiceCollection AddDataLayer(this IServiceCollection services)
    {
        services.AddSingleton<IEmailSender, EmailSender>();
        services.AddSingleton<IEmailResolver, EmailResolver>();

        return services;
    }
}