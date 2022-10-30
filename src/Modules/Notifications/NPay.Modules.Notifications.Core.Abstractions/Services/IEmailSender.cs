namespace NPay.Modules.Notifications.Core.Abstractions.Services;

internal interface IEmailSender
{
    internal Task SendAsync(string receiver, string template);
}