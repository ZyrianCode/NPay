namespace NPay.Modules.Notifications.Core.Abstractions.Services;

internal interface IEmailSender
{
    Task SendAsync(string receiver, string template);
}