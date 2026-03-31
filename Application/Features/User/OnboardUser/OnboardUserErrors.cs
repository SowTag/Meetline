using Application.Errors;

namespace Application.Features.User.OnboardUser;

public static class OnboardUserErrors
{
    public static ApplicationError UserAlreadyOnboardError()
    {
        return ApplicationError.Conflict("User.AlreadyOnboard", "User already onboard",
            "The user is already onboard and cannot be onboarded again.");
    }
}