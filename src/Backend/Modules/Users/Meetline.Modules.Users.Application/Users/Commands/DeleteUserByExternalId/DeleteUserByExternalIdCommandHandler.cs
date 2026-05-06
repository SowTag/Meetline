using FluentResults;
using Mediator;
using Meetline.Modules.Users.Application.Users.Errors;

namespace Meetline.Modules.Users.Application.Users.Commands.DeleteUserByExternalId;

public class DeleteUserByExternalIdCommandHandler(IUserRepository repository)
    : ICommandHandler<DeleteUserByExternalIdCommand, Result>
{
    public async ValueTask<Result> Handle(DeleteUserByExternalIdCommand byExternalIdCommand,
        CancellationToken cancellationToken)
    {
        var user = await repository.GetUserByExternalId(byExternalIdCommand.ExternalId, cancellationToken);

        if (user is null) return Result.Fail(new UserNotFoundError(byExternalIdCommand.ExternalId));

        await repository.DeleteUser(user, cancellationToken);

        return Result.Ok();
    }
}