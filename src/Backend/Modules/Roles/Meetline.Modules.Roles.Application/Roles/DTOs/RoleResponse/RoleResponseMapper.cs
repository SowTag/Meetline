using Riok.Mapperly.Abstractions;

namespace Meetline.Modules.Roles.Application.Roles.DTOs.RoleResponse;

[Mapper]
public partial class RoleResponseMapper
{
    [MapperIgnoreSource(nameof(Meetline.Modules.Roles.Domain.Entities.Role.CreatedAt))]
    [MapperIgnoreSource(nameof(Meetline.Modules.Roles.Domain.Entities.Role.UpdatedAt))]
    public partial RoleResponse ToResponse(Meetline.Modules.Roles.Domain.Entities.Role role);

    public partial List<RoleResponse> ToResponse(ICollection<Meetline.Modules.Roles.Domain.Entities.Role> roles);
}