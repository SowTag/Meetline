using Meetline.Modules.Users.Application.Services;
using Meetline.Modules.Users.Domain.Entities;
using Riok.Mapperly.Abstractions;

namespace Meetline.Modules.Users.Application.Users.Mappers;

[Mapper]
public static partial class UserMapper
{
    public static User ToEntity(UserSyncData data)
    {
        return MapToUser(data, Guid.NewGuid());
    }

    [MapProperty(nameof(UserSyncData.ExternalId), nameof(User.ExternalId))]
    [MapperIgnoreTarget(nameof(User.CreatedAt))]
    [MapperIgnoreTarget(nameof(User.UpdatedAt))]
    private static partial User MapToUser(UserSyncData data, Guid id);
}