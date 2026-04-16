using Application.Features.User.DTOs.UserResponse;
using Application.Features.User.Errors;
using Application.Repositories;
using Application.Services;
using FluentResults;
using Mediator;
using Microsoft.Extensions.Logging;
using UserSyncDataMapper = Application.Features.User.DTOs.UserSyncData.UserSyncDataMapper;

namespace Application.Features.User.SyncUserFromIdentityProvider;

public class SyncUserFromIdentityProviderHandler(
    ILogger<SyncUserFromIdentityProviderHandler> logger,
    IUserRepository repository,
    IIdentityProviderClientService idpClientService)
    : ICommandHandler<SyncUserFromIdentityProviderCommand, Result<UserResponse>>
{
    private readonly UserResponseMapper _responseMapper = new();
    private readonly UserSyncDataMapper _syncDataMapper = new();

    public async ValueTask<Result<UserResponse>> Handle(SyncUserFromIdentityProviderCommand command,
        CancellationToken cancellationToken)
    {
        var idpUserResult = await idpClientService.GetUser(command.ExternalId, cancellationToken);

        if (idpUserResult.IsFailed) return Result.Fail(idpUserResult.Errors);

        var user = _syncDataMapper.ToUser(idpUserResult.Value);

        try
        {
            await repository.UpsertByExternalIdAsync(user, cancellationToken);
        }
        catch (Exception e)
        {
            logger.LogError(e, "Couldn't upsert user sync data");
            return Result.Fail(new IdentityProviderSyncError());
        }

        return Result.Ok(_responseMapper.ToResponse(user));
    }
}