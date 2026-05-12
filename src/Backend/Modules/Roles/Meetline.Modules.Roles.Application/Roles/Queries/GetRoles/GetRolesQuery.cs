using FluentResults;
using Mediator;
using Meetline.Modules.Roles.Application.Roles.DTOs.RoleResponse;
using Meetline.Modules.SharedKernel.Application.CQRS.Caching;
using Meetline.Modules.SharedKernel.Application.CQRS.Caching.Keys;

namespace Meetline.Modules.Roles.Application.Roles.Queries.GetRoles;

public record GetRolesQuery : IQuery<Result<ICollection<RoleResponse>>>, ICacheableRequest
{
    public string CacheKey => RoleCacheKeys.All;
    public TimeSpan? AbsoluteExpiration => TimeSpan.FromMinutes(10);
    public TimeSpan? SlidingExpiration => TimeSpan.FromMinutes(2);
}