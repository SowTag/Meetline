using FluentResults;
using Mediator;
using Meetline.Modules.Users.Application.Users.DTOs.UserPublicResponse;
using Meetline.Modules.Users.Application.Users.Errors;

namespace Meetline.Modules.Users.Application.Users.Queries.GetUserById;

public class GetUserByIdHandler(IUserRepository repository)
    : IQueryHandler<GetUserByIdQuery, Result<UserPublicResponse>>
{
    private readonly UserPublicResponseMapper _mapper = new();

    public async ValueTask<Result<UserPublicResponse>> Handle(GetUserByIdQuery query,
        CancellationToken cancellationToken)
    {
        var user = await repository.GetUserById(query.Id, cancellationToken);

        return user is null
            ? Result.Fail(new UserNotFoundError(query.Id))
            : Result.Ok(_mapper.ToResponse(user));
    }
}