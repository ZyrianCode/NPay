using NPay.Modules.Notifications.Core.Abstractions.Services;
using NPay.Modules.Users.Shared.Events;
using NPay.Shared.Events;

namespace NPay.Modules.Notifications.Application.Handlers.Users;

internal sealed class UserVerifiedHandler : IEventHandler<UserVerified>
{
    private readonly IEmailSender _emailSender;

    public UserVerifiedHandler(IEmailSender emailSender)
    {
        _emailSender = emailSender;
    }

    public Task HandleAsync(UserVerified @event, CancellationToken cancellationToken = default)
        => _emailSender.SendAsync(@event.Email, "account_verified");
}