using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using NPay.Modules.Notifications.Api.Extensions;
using NPay.Modules.Users.Api.Extensions;
using NPay.Modules.Wallets.Api.Extensions;
using NPay.Shared;

var builder = WebApplication
    .CreateBuilder(args);

builder.Services
    .AddNotificationsModule()
    .AddUsersModule()
    .AddWalletsModule()
    .AddSharedFramework(builder.Configuration);

var app = builder.Build();

app.UseSharedFramework();
app.UseNotificationsModule();
app.UseUsersModule();
app.UseWalletsModule();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapGet("/", ctx => ctx.Response.WriteAsync("NPay API"));
});

app.Run();