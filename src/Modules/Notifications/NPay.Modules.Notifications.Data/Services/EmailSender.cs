using Microsoft.Extensions.Logging;
using NPay.Modules.Notifications.Application.Services;

namespace NPay.Modules.Notifications.Data.Services;

internal sealed class EmailSender : IEmailSender
{
    private readonly ILogger<EmailSender> _logger;

    public EmailSender(ILogger<EmailSender> logger)
    {
        _logger = logger;
    }

    Task IEmailSender.SendAsync(string receiver, string template)
    {
        // TODO: Implement an email sender
        _logger.LogInformation($"Sending an email to: '{receiver}', template: '{template}'...");
        return Task.CompletedTask;
    }
}