using FluentResults;
using Mediator;
using Meetline.Modules.Users.Application.Users.DTOs.UserGuidResponse;
using Meetline.Modules.Users.Application.Users.Errors;

namespace Meetline.Modules.Users.Application.Users.Queries.GetUserIdByExternalId;

public class GetUserIdByExternalIdHandler(IUserRepository repository)
    : IQueryHandler<GetUserIdByExternalIdQuery, Result<UserGuidResponse>>
{
    public async ValueTask<Result<UserGuidResponse>> Handle(GetUserIdByExternalIdQuery query,
        CancellationToken cancellationToken)
    {
        var id = await repository.GetUserIdFromExternalId(query.ExternalId, cancellationToken);

        return id is null
            ? Result.Fail(new UserNotFoundError(query.ExternalId))
            : Result.Ok(new UserGuidResponse(id.Value));
    }
}