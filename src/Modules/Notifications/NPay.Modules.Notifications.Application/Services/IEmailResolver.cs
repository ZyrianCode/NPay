namespace NPay.Modules.Notifications.Application.Services;

internal interface IEmailResolver
{
    internal string GetForOwner(Guid ownerId);
}