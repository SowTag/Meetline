using Application.Errors;

namespace Application.Features.User.GetUserById;

public static class GetUserByIdErrors
{
    public static ApplicationError UserNotFoundError(Guid id)
    {
        return ApplicationError.NotFound("User.NotFound", "User not found", $"User with ID {id} not found");
    }
}