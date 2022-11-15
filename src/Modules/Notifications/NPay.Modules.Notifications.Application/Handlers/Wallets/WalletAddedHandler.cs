using NPay.Modules.Notifications.Application.Services;
using NPay.Modules.Wallets.Shared.Events;
using NPay.Shared.Events;

namespace NPay.Modules.Notifications.Application.Handlers.Wallets;

internal sealed class WalletAddedHandler : IEventHandler<WalletAdded>
{
    private readonly IEmailSender _emailSender;
    private readonly IEmailResolver _emailResolver;

    public WalletAddedHandler(IEmailSender emailSender, IEmailResolver emailResolver)
    {
        _emailSender = emailSender;
        _emailResolver = emailResolver;
    }

    Task IEventHandler<WalletAdded>.HandleAsync(WalletAdded @event, CancellationToken cancellationToken)
        => _emailSender.SendAsync(_emailResolver.GetForOwner(@event.OwnerId), "wallet_added");
}