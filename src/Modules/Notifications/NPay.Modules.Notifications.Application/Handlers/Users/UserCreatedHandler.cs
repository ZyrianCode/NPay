using NPay.Modules.Notifications.Application.Services;
using NPay.Modules.Users.Shared.Events;
using NPay.Shared.Events;

namespace NPay.Modules.Notifications.Application.Handlers.Users;

internal sealed class UserCreatedHandler : IEventHandler<UserCreated>
{
    private readonly IEmailSender _emailSender;

    public UserCreatedHandler(IEmailSender emailSender)
    {
        _emailSender = emailSender;
    }

    Task IEventHandler<UserCreated>.HandleAsync(UserCreated @event, CancellationToken cancellationToken)
        => _emailSender.SendAsync(@event.Email, "account_created");
}