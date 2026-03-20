using Application.Errors;

namespace Application.Features.User.GetOwnUserById;

public static class GetOwnUserByIdErrors
{
    public static ApplicationError UserNotFoundError(Guid id)
    {
        return ApplicationError.Forbidden("User.NotOnboard", "User is not onboard",
            $"User with ID {id} not found, maybe they're not onboard?");
    }
}