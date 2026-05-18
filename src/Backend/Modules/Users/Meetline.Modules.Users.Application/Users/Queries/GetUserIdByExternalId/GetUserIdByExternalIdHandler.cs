using Meetline.Modules.Users.Application.Data;
using Microsoft.EntityFrameworkCore;

namespace Meetline.Modules.Users.Application.Users.Queries.GetUserIdByExternalId;

public static class GetUserIdByExternalIdQueryHandler
{
    public static Task<Guid?> Handle(GetUserIdByExternalIdQuery query,
        IUsersDbContext context,
        CancellationToken cancellationToken)
    {
        return context.Users
            .AsNoTracking()
            .Where(u => u.ExternalId == query.ExternalId)
            .Select(u => (Guid?)u.Id)
            .FirstOrDefaultAsync(cancellationToken);
    }
}