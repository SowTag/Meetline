using Meetline.Modules.SharedKernel.Domain.Wrappers;

namespace Meetline.Modules.Roles.Application.Roles.DTOs.CreateRoleRequest;

public record CreateRoleRequest
{
    public required string Name { get; init; }
    public required bool Hoist { get; init; }
    public required int Position { get; init; }
    public required PermissionSet Permissions { get; init; }
}