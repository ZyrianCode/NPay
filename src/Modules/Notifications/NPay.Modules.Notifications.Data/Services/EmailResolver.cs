using NPay.Modules.Notifications.Application.Services;

namespace NPay.Modules.Notifications.Data.Services;

internal sealed class EmailResolver : IEmailResolver
{
    // TODO: Resolve the user/owner email address from other modules
    string IEmailResolver.GetForOwner(Guid ownerId) => $"{ownerId:N}@npay.io";
}