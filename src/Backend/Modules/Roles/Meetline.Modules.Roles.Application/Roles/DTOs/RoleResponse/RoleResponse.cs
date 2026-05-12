using Meetline.Modules.SharedKernel.Domain.Wrappers;

namespace Meetline.Modules.Roles.Application.Roles.DTOs.RoleResponse;

public record RoleResponse(Guid Id, string Name, bool Hoist, int Position, PermissionSet Permissions);