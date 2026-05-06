using Application.Features.Role.DTOs.RoleResponse;
using FluentResults;
using Mediator;
using Meetline.Modules.SharedKernel.Application.CQRS.Caching;
using Meetline.Modules.SharedKernel.Application.CQRS.Caching.Keys;

namespace Application.Features.Role.GetRoleById;

public record GetRoleByIdQuery(Guid Id) : IQuery<Result<RoleResponse>>, ICacheableRequest
{
    public string CacheKey => RoleCacheKeys.ById(Id);
    public TimeSpan? AbsoluteExpiration => TimeSpan.FromMinutes(10);
    public TimeSpan? SlidingExpiration => TimeSpan.FromMinutes(2);
}