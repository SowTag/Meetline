using Application.Repositories;
using FluentResults;
using Mediator;

namespace Application.Features.User.OnboardUser;

public class OnboardUserHandler(IUserRepository repository) : ICommandHandler<OnboardUserCommand, Result<Guid>>
{
    public async ValueTask<Result<Guid>> Handle(OnboardUserCommand command, CancellationToken cancellationToken)
    {
        var existingUserId = await repository.GetUserIdFromExternalId(command.ExternalId, cancellationToken);
        if (existingUserId is not null) return Result.Fail(OnboardUserErrors.UserAlreadyOnboardError());

        var user = new Domain.Entities.User
        {
            Id = Guid.NewGuid(),
            ExternalId = command.ExternalId,
            Username = command.Username,
            Email = command.Email,
            FirstName = command.FirstName,
            LastName = command.LastName
        };

        await repository.CreateAsync(user, cancellationToken);

        return Result.Ok(user.Id);
    }
}