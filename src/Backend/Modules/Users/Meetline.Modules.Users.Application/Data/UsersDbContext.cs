using Meetline.Modules.SharedKernel.Infrastructure.Abstractions;
using Meetline.Modules.Users.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Meetline.Modules.Users.Application.Data;

public sealed class UsersDbContext(DbContextOptions options) : AuditingDbContext(options)
{
    public DbSet<User> Users { get; set; }
}