using Application.Features.Role.DTOs.CreateRoleRequest;
using Application.Features.Role.DTOs.RoleResponse;
using FluentResults;
using Mediator;
using Meetline.Modules.SharedKernel.Application.CQRS.Caching;
using Meetline.Modules.SharedKernel.Application.CQRS.Caching.Keys;

namespace Application.Features.Role.CreateRole;

public record CreateRoleCommand(CreateRoleRequest Request)
    : ICommand<Result<RoleResponse>>, ICacheInvalidatingRequest
{
    public string[] CacheKeysToInvalidate =>
    [
        RoleCacheKeys.All
    ];
}