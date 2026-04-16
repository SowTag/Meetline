using Application.Features.User.DTOs.UserGuidResponse;
using Application.Features.User.GetUserIdByExternalId;
using Application.Features.User.SyncUserFromIdentityProvider;
using Application.Repositories;
using Application.Services;
using FluentResults;
using Mediator;
using UserSyncDataMapper = Application.Features.User.DTOs.UserSyncData.UserSyncDataMapper;

namespace Application.Features.User.ResolveUserIdFromExternalId;

public class ResolveUserIdFromExternalIdCommandHandler(
    IMediator mediator,
    IUserRepository repository,
    IIdentityProviderClientService idpClientService)
    : ICommandHandler<ResolveUserIdFromExternalIdCommand, Result<UserGuidResponse>>
{
    private readonly UserSyncDataMapper _idpUserSyncDataMapper = new();

    public async ValueTask<Result<UserGuidResponse>> Handle(
        ResolveUserIdFromExternalIdCommand command, CancellationToken cancellationToken)
    {
        // Quick path - user already synced once, bail out early
        var internalIdResult =
            await mediator.Send(new GetUserIdByExternalIdQuery(command.ExternalId), cancellationToken);

        if (internalIdResult.IsSuccess) return Result.Ok(new UserGuidResponse(internalIdResult.Value.Id));

        // IdP sync
        var syncResult =
            await mediator.Send(new SyncUserFromIdentityProviderCommand(command.ExternalId), cancellationToken);

        if (syncResult.IsFailed) return Result.Fail(syncResult.Errors);

        return Result.Ok(new UserGuidResponse(syncResult.Value.Id));
    }
}