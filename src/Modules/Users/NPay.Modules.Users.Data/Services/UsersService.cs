using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NPay.Modules.Users.Application.Maps;
using NPay.Modules.Users.Application.Services;
using NPay.Modules.Users.Core.Entities;
using NPay.Modules.Users.Core.Exceptions;
using NPay.Modules.Users.Data.DAL.Contexts;
using NPay.Modules.Users.Shared.DTO;
using NPay.Modules.Users.Shared.Events;
using NPay.Shared.Messaging;
using NPay.Shared.Time;

namespace NPay.Modules.Users.Data.Services;

internal sealed class UsersService : IUsersService
{
    private readonly UsersDbContext _dbContext;
    private readonly IMessageBroker _messageBroker;
    private readonly IClock _clock;
    private readonly ILogger<UsersService> _logger;

    public UsersService(UsersDbContext dbContext, IMessageBroker messageBroker, IClock clock,
        ILogger<UsersService> logger)
    {
        _dbContext = dbContext;
        _messageBroker = messageBroker;
        _clock = clock;
        _logger = logger;
    }

    async Task<UserDetailsDto> IUsersService.GetAsync(Guid userId)
    {
        var user = await _dbContext.Users.SingleOrDefaultAsync(x => x.Id == userId);

        // TODO: Make use of custom mapping interface or AutoMapper, Mapster etc.

        return user is null ? null : user.MapToDetailsDto();
    }

    async Task<UserDetailsDto> IUsersService.GetAsync(string email)
    {
        // TODO: Additional email validation
        email = email?.ToLowerInvariant();
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new InvalidEmailException(email);
        }

        var user = await _dbContext.Users.SingleOrDefaultAsync(x => x.Email == email);

        return user is null ? null : user.MapToDetailsDto();
    }

    async Task<IReadOnlyList<UserDto>> IUsersService.BrowseAsync()
    {
        var users = await _dbContext.Users.ToListAsync();

        // TODO: Implement pagination, sorting etc.

        return users.Select(x => x.MapToDto()).ToList();
    }

    async Task IUsersService.AddAsync(UserDetailsDto dto)
    {
        var email = dto.Email.ToLowerInvariant();
        if (await _dbContext.Users.AnyAsync(x => x.Email == email))
        {
            throw new UserAlreadyExistsException(email);
        }

        // TODO: Additional validation for the remaining properties
        if (string.IsNullOrWhiteSpace(dto.FullName))
        {
            throw new InvalidFullNameException(dto.FullName);
        }

        if (string.IsNullOrWhiteSpace(dto.Address))
        {
            throw new InvalidAddressException(dto.Address);
        }

        var user = new User(dto.UserId, email, dto.FullName, dto.Address,
            dto.Nationality, dto.Identity, _clock.CurrentDate());
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
        await _messageBroker.PublishAsync(new UserCreated(user.Id, user.Email, user.FullName, user.Nationality));
        _logger.LogInformation($"Created the user with ID: '{dto.UserId}'.");
    }

    async Task IUsersService.VerifyAsync(Guid userId)
    {
        var user = await _dbContext.Users.SingleOrDefaultAsync(x => x.Id == userId);
        if (user is null)
        {
            throw new UserNotFoundException(userId);
        }

        user.Verify(_clock.CurrentDate());
        _dbContext.Users.Update(user);
        await _dbContext.SaveChangesAsync();
        await _messageBroker.PublishAsync(new UserVerified(user.Id, user.Email, user.Nationality));
        _logger.LogInformation($"Verified the user with ID: '{user.Id}'.");
    }
}