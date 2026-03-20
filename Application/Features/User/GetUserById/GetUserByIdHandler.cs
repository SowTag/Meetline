using Application.Repositories;
using FluentResults;
using Mediator;

namespace Application.Features.User.GetUserById;

public class GetUserByIdHandler(IUserRepository repository)
    : IQueryHandler<GetUserByIdQuery, Result<GetUserByIdResponse>>
{
    private readonly GetUserByIdResponseMapper _mapper = new();

    public async ValueTask<Result<GetUserByIdResponse>> Handle(GetUserByIdQuery query,
        CancellationToken cancellationToken)
    {
        var user = await repository.GetUserById(query.Id, cancellationToken);

        return user is null
            ? Result.Fail(GetUserByIdErrors.UserNotFoundError(query.Id))
            : Result.Ok(_mapper.ToResponse(user));
    }
}