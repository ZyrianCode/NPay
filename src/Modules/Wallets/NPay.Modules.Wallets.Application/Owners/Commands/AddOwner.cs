using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NPay.Modules.Users.Shared;
using NPay.Modules.Wallets.Application.Owners.Exceptions;
using NPay.Modules.Wallets.Core.Owners.Aggregates;
using NPay.Modules.Wallets.Core.Owners.Repositories;
using NPay.Shared.Commands;
using NPay.Shared.Time;

namespace NPay.Modules.Wallets.Application.Owners.Commands;

public sealed class AddOwner
{
    public record Command(string Email) : ICommand;

    internal sealed class AddOwnerHandler : ICommandHandler<Command>
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IUsersModuleApi _usersModuleApi;
        private readonly IClock _clock;
        private readonly ILogger<AddOwnerHandler> _logger;

        public AddOwnerHandler(IOwnerRepository ownerRepository, IUsersModuleApi usersModuleApi, IClock clock,
            ILogger<AddOwnerHandler> logger)
        {
            _ownerRepository = ownerRepository;
            _usersModuleApi = usersModuleApi;
            _clock = clock;
            _logger = logger;
        }

        async Task ICommandHandler<Command>.HandleAsync(Command command, CancellationToken cancellationToken)
        {
            var user = await _usersModuleApi.GetUserAsync(command.Email);
            if (user is null)
            {
                throw new UserNotFoundException(command.Email);
            }

            var owner = await _ownerRepository.GetAsync(user.UserId);

            if (owner is not null)
            {
                throw new OwnerAlreadyExistsException(command.Email);
            }

            var now = _clock.CurrentDate();
            var newOwner = new Owner(user.UserId, user.FullName, user.Nationality, now);
            await _ownerRepository.AddAsync(newOwner);
            _logger.LogInformation($"Created an owner for the user with ID: '{user.UserId}'.");
        }
    }
}
