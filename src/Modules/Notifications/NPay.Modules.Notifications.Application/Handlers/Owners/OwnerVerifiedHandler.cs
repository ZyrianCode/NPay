using NPay.Modules.Notifications.Core.Abstractions.Services;
using NPay.Modules.Wallets.Shared.Events;
using NPay.Shared.Events;

namespace NPay.Modules.Notifications.Application.Handlers.Owners;

internal sealed class OwnerVerifiedHandler : IEventHandler<OwnerVerified>
{
    private readonly IEmailSender _emailSender;
    private readonly IEmailResolver _emailResolver;

    public OwnerVerifiedHandler(IEmailSender emailSender, IEmailResolver emailResolver)
    {
        _emailSender = emailSender;
        _emailResolver = emailResolver;
    }

    Task IEventHandler<OwnerVerified>.HandleAsync(OwnerVerified @event, CancellationToken cancellationToken)
        => _emailSender.SendAsync(_emailResolver.GetForOwner(@event.OwnerId), "owner_verified");
}