using System.Threading.Tasks;
using NPay.Modules.Notifications.Application.Services;
using NPay.Modules.Notifications.Shared;

namespace NPay.Modules.Notifications.Api.Modules;

internal sealed class NotificationsModuleApi : INotificationsModuleApi
{
    private readonly IEmailSender _emailSender;

    public NotificationsModuleApi(IEmailSender emailSender)
    {
        _emailSender = emailSender;
    }

    Task INotificationsModuleApi.SendEmailAsync(string receiver, string template)
        => _emailSender.SendAsync(receiver, template);
}