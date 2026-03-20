using Application.Repositories;
using FluentResults;
using Mediator;

namespace Application.Features.User.GetOwnUserById;

public class GetOwnUserByIdHandler(IUserRepository repository)
    : IQueryHandler<GetOwnUserByIdQuery, Result<GetOwnUserByIdResponse>>
{
    private readonly GetOwnUserByIdResponseMapper _mapper = new();

    public async ValueTask<Result<GetOwnUserByIdResponse>> Handle(GetOwnUserByIdQuery query,
        CancellationToken cancellationToken)
    {
        var user = await repository.GetUserById(query.Id, cancellationToken);

        return user is null
            ? Result.Fail(GetOwnUserByIdErrors.UserNotFoundError(query.Id))
            : Result.Ok(_mapper.ToResponse(user));
    }
}