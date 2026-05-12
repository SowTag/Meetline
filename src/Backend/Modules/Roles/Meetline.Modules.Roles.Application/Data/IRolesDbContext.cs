using Meetline.Modules.Roles.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Meetline.Modules.Roles.Application.Data;

public interface IRolesDbContext
{
    DbSet<Role> Roles { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}