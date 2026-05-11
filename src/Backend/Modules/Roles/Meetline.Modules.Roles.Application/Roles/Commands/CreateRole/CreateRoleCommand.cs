using FluentResults;
using Mediator;
using Meetline.Modules.Roles.Application.Roles.DTOs.CreateRoleRequest;
using Meetline.Modules.Roles.Application.Roles.DTOs.RoleResponse;
using Meetline.Modules.SharedKernel.Application.CQRS.Caching;
using Meetline.Modules.SharedKernel.Application.CQRS.Caching.Keys;

namespace Meetline.Modules.Roles.Application.Roles.Commands.CreateRole;

public record CreateRoleCommand(CreateRoleRequest Request)
    : ICommand<Result<RoleResponse>>, ICacheInvalidatingRequest
{
    public string[] CacheKeysToInvalidate =>
    [
        RoleCacheKeys.All
    ];
}