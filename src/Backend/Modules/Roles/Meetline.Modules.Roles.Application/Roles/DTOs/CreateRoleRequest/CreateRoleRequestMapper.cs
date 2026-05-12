using Riok.Mapperly.Abstractions;

namespace Meetline.Modules.Roles.Application.Roles.DTOs.CreateRoleRequest;

[Mapper]
public partial class CreateRoleRequestMapper
{
    [MapperIgnoreTarget(nameof(Meetline.Modules.Roles.Domain.Entities.Role.Id))]
    [MapperIgnoreTarget(nameof(Meetline.Modules.Roles.Domain.Entities.Role.CreatedAt))]
    [MapperIgnoreTarget(nameof(Meetline.Modules.Roles.Domain.Entities.Role.UpdatedAt))]
    public partial Meetline.Modules.Roles.Domain.Entities.Role ToRole(CreateRoleRequest request);
}