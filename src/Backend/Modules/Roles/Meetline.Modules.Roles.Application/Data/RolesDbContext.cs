using Meetline.Modules.Roles.Domain.Entities;
using Meetline.Modules.SharedKernel.Infrastructure.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Meetline.Modules.Roles.Application.Data;

public sealed class RolesDbContext(DbContextOptions options) : AuditingDbContext(options)
{
    internal DbSet<Role> Roles { get; set; }
}