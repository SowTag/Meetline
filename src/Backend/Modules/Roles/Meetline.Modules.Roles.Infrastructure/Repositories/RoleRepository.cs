using Meetline.Modules.Roles.Application.Repositories;
using Meetline.Modules.Roles.Infrastructure.Database;

namespace Meetline.Modules.Roles.Infrastructure.Repositories;

internal class RoleRepository(RolesDbContext ctx) : IRoleRepository
{
}