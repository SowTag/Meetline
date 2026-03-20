using Application.Errors;

namespace Application.Features.User.GetUserIdByExternalId;

public static class GetUserIdByExternalIdErrors
{
    public static ApplicationError UserNotFoundError(string id)
    {
        return ApplicationError.NotFound("User.NotFound", "User not found", $"User with external ID {id} not found");
    }
}