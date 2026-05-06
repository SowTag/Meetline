using Meetline.Modules.Users.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace Meetline.Modules.Users.Application.Users.DTOs.UserPublicResponse;

[Mapper]
public partial class UserPublicResponseMapper
{
    [MapperIgnoreSource(nameof(User.ExternalId))]
    [MapperIgnoreSource(nameof(User.CreatedAt))]
    [MapperIgnoreSource(nameof(User.UpdatedAt))]
    public partial UserPublicResponse ToResponse(User user);
}