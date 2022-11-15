using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NPay.Modules.Users.Application;
using NPay.Modules.Users.Core;
using NPay.Modules.Users.Data;

namespace NPay.Modules.Users.Api.Extensions;

public static class ModuleExtensions
{
    public static IServiceCollection AddUsersModule(this IServiceCollection services)
    {
        services.AddCoreLayer();
        services.AddApplicationLayer();
        services.AddDataLayer();
        services.AddApi();
        return services;
    }
        
    public static IApplicationBuilder UseUsersModule(this IApplicationBuilder app)
    {
        return app;
    }
}