namespace NPay.Modules.Notifications.Application.Services;

internal interface IEmailSender
{
    internal Task SendAsync(string receiver, string template);
}