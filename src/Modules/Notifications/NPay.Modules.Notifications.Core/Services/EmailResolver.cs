using NPay.Modules.Notifications.Core.Abstractions.Services;

namespace NPay.Modules.Notifications.Core.Services;

internal sealed class EmailResolver : IEmailResolver
{
    // TODO: Resolve the user/owner email address from other modules
    public string GetForOwner(Guid ownerId) => $"{ownerId:N}@npay.io";
}