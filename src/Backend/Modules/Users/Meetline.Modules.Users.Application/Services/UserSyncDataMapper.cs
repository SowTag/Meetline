using Meetline.Modules.Users.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace Meetline.Modules.Users.Application.Services;

[Mapper]
public static partial class UserSyncDataMapper
{
    [MapperIgnoreTarget(nameof(User.Id))]
    [MapperIgnoreTarget(nameof(User.CreatedAt))]
    [MapperIgnoreTarget(nameof(User.UpdatedAt))]
    public static partial User ToUser(UserSyncData idpUserSyncData);
}