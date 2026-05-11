using Meetline.Modules.SharedKernel.Application.Errors.ErrorTypes;

namespace Meetline.Modules.Roles.Application.Roles.Errors;

public class RoleNotFoundError(Guid id)
    : NotFoundError("Role.NotFound", "Role not found", $"Role with ID {id} not found");