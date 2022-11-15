using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NPay.Modules.Users.Shared.Events;
using NPay.Modules.Wallets.Application.Owners.Exceptions;

using NPay.Modules.Wallets.Core.Owners.Aggregates;
using NPay.Modules.Wallets.Core.Owners.Repositories;
using NPay.Shared.Events;
using NPay.Shared.Time;

namespace NPay.Modules.Wallets.Application.Owners.ExternalEventsHandlers;

internal sealed class UserCreatedHandler : IEventHandler<UserCreated>
{
    private readonly IOwnerRepository _ownerRepository;
    private readonly IClock _clock;
    private readonly ILogger<UserCreatedHandler> _logger;

    public UserCreatedHandler(IOwnerRepository ownerRepository, IClock clock, ILogger<UserCreatedHandler> logger)
    {
        _ownerRepository = ownerRepository;
        _clock = clock;
        _logger = logger;
    }

    async Task IEventHandler<UserCreated>.HandleAsync(UserCreated @event, CancellationToken cancellationToken)
    {
        if (await _ownerRepository.GetAsync(@event.UserId) is not null)
        {
            throw new OwnerAlreadyExistsException(@event.Email);
        }

        var now = _clock.CurrentDate();
        var owner = new Owner(@event.UserId, @event.FullName, @event.Nationality, now);
        await _ownerRepository.AddAsync(owner);
        _logger.LogInformation($"Created an owner for the user with ID: '{@event.UserId}'.");
    }
}