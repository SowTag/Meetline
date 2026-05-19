using Meetline.Modules.Users.Application.Services;

namespace Meetline.Modules.Users.Application.Users.Commands.UpsertUser;

public record UpsertUserCommand(UserSyncData Data);