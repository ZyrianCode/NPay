namespace NPay.Modules.Notifications.Core.Abstractions.Services;

internal interface IEmailResolver
{
    internal string GetForOwner(Guid ownerId);
}