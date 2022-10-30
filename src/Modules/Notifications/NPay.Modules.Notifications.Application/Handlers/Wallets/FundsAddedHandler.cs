using NPay.Modules.Notifications.Core.Abstractions.Services;
using NPay.Modules.Wallets.Shared.Events;
using NPay.Shared.Events;

namespace NPay.Modules.Notifications.Application.Handlers.Wallets;

internal sealed class FundsAddedHandler : IEventHandler<FundsAdded>
{
    private readonly IEmailSender _emailSender;
    private readonly IEmailResolver _emailResolver;

    public FundsAddedHandler(IEmailSender emailSender, IEmailResolver emailResolver)
    {
        _emailSender = emailSender;
        _emailResolver = emailResolver;
    }

    Task IEventHandler<FundsAdded>.HandleAsync(FundsAdded @event, CancellationToken cancellationToken)
        => _emailSender.SendAsync(_emailResolver.GetForOwner(@event.OwnerId), "funds_added");
}