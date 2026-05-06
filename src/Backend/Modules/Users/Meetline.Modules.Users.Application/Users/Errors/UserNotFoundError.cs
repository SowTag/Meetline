using Meetline.Modules.SharedKernel.Application.Errors.ErrorTypes;

namespace Meetline.Modules.Users.Application.Users.Errors;

public class UserNotFoundError(string externalId) : NotFoundError("User.NotFound", "User not found",
    $"User with ID {externalId} not found.")
{
    public UserNotFoundError(Guid id) : this(id.ToString())
    {
    }
}