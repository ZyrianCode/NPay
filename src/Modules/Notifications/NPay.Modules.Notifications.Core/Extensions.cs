using Microsoft.Extensions.DependencyInjection;
using NPay.Modules.Notifications.Core.Abstractions.Services;
using NPay.Modules.Notifications.Core.Services;

namespace NPay.Modules.Notifications.Core;

public static class Extensions
{
    public static IServiceCollection AddCoreLayer(this IServiceCollection services)
    {
        services.AddSingleton<IEmailSender, EmailSender>();
        services.AddSingleton<IEmailResolver, EmailResolver>();

        return services;
    }
}