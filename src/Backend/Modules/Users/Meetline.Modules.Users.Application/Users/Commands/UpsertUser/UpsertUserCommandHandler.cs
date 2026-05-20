using Meetline.Modules.Users.Application.Repositories;
using Meetline.Modules.Users.Application.Users.Mappers;

namespace Meetline.Modules.Users.Application.Users.Commands.UpsertUser;

public static class UpsertUserCommandHandler
{
    public static Task Handle(UpsertUserCommand command, IUserRepository userRepository, CancellationToken ct)
    {
        var user = UserMapper.ToEntity(command.Data);
        return userRepository.UpsertByExternalIdAsync(user, ct);
    }
}