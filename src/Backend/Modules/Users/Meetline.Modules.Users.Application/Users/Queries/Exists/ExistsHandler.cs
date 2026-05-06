using FluentResults;
using Mediator;
using Meetline.Modules.Users.Application.Users.Errors;

namespace Meetline.Modules.Users.Application.Users.Queries.Exists;

public class ExistsHandler(IUserRepository repository) : IQueryHandler<ExistsQuery, Result<ExistsResponse>>
{
    public async ValueTask<Result<ExistsResponse>> Handle(ExistsQuery query, CancellationToken cancellationToken)
    {
        var exists = await repository.ExistsAsync(query.Id, cancellationToken);

        return exists ? Result.Ok() : Result.Fail(new UserNotFoundError(query.Id));
    }
}