using Meetline.Modules.Users.Application.Data;
using Meetline.Modules.Users.Application.Users.Commands.SyncUserFromIdentityProvider;
using Microsoft.EntityFrameworkCore;
using Wolverine;

namespace Meetline.Modules.Users.Application.Users.Queries.GetInternalUserId;

public static class GetInternalUserIdQueryHandler
{
    public static async Task<Guid> Handle(
        GetInternalUserIdQuery query,
        IUsersDbContext context,
        IMessageBus bus,
        CancellationToken ct)
    {
        var userId = await context.Users
            .AsNoTracking()
            .Where(u => u.ExternalId == query.ExternalId)
            .Select(u => (Guid?)u.Id)
            .FirstOrDefaultAsync(ct);

        if (userId.HasValue) return userId.Value;

        await bus.InvokeAsync(new SyncUserFromIdentityProviderCommand(query.ExternalId), ct);

        return await context.Users
            .AsNoTracking()
            .Where(u => u.ExternalId == query.ExternalId)
            .Select(u => u.Id)
            .FirstAsync(ct);
    }
}