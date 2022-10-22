namespace NPay.Modules.Notifications.Core.Abstractions.Services;

internal interface IEmailResolver
{
    string GetForOwner(Guid ownerId);
}