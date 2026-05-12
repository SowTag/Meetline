using FluentResults;
using Mediator;
using Meetline.Modules.Roles.Application.Roles.DTOs.RoleResponse;
using Meetline.Modules.SharedKernel.Application.CQRS.Caching;
using Meetline.Modules.SharedKernel.Application.CQRS.Caching.Keys;

namespace Meetline.Modules.Roles.Application.Roles.Queries.GetRoleById;

public record GetRoleByIdQuery(Guid Id) : IQuery<Result<RoleResponse>>, ICacheableRequest
{
    public string CacheKey => RoleCacheKeys.ById(Id);
    public TimeSpan? AbsoluteExpiration => TimeSpan.FromMinutes(10);
    public TimeSpan? SlidingExpiration => TimeSpan.FromMinutes(2);
}