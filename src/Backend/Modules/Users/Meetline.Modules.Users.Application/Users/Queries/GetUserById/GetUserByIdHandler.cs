using FluentResults;
using Mediator;
using Meetline.Modules.Users.Application.Data;
using Meetline.Modules.Users.Application.Users.DTOs.UserResponse;
using Meetline.Modules.Users.Application.Users.Errors;

namespace Meetline.Modules.Users.Application.Users.Queries.GetUserById;

public class GetUserByIdHandler(IUsersDbContext context)
    : IQueryHandler<GetUserByIdQuery, Result<UserResponse>>
{
    private readonly UserResponseMapper _mapper = new();

    public async ValueTask<Result<UserResponse>> Handle(GetUserByIdQuery query,
        CancellationToken cancellationToken)
    {
        var user = await context.Users.FindAsync([query.Id], cancellationToken);

        return user is null
            ? Result.Fail(new UserNotFoundError(query.Id))
            : Result.Ok(_mapper.ToResponse(user));
    }
}