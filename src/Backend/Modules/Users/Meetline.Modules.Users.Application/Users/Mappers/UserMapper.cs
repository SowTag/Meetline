using Meetline.Modules.Users.Application.Services;
using Meetline.Modules.Users.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace Meetline.Modules.Users.Application.Users.Mappers;

[Mapper]
public partial class UserMapper
{
    [MapperIgnoreTarget(nameof(User.Id))]
    [MapperIgnoreTarget(nameof(User.CreatedAt))]
    [MapperIgnoreTarget(nameof(User.UpdatedAt))]
    public partial User ToEntity(UserSyncData data);
}