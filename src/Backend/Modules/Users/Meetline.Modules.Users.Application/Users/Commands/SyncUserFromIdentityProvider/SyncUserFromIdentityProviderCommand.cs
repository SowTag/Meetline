using FluentResults;
using Mediator;
using Meetline.Modules.Users.Application.Users.DTOs.UserResponse;

namespace Meetline.Modules.Users.Application.Users.Commands.SyncUserFromIdentityProvider;

public record SyncUserFromIdentityProviderCommand(string ExternalId) : ICommand<Result<UserResponse>>;