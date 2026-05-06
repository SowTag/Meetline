using FluentValidation;

namespace Meetline.Modules.Users.Application.Users.Commands.SyncUserFromIdentityProvider;

public class SyncUserFromIdentityProviderCommandValidator : AbstractValidator<SyncUserFromIdentityProviderCommand>
{
    public SyncUserFromIdentityProviderCommandValidator()
    {
        RuleFor(x => x.ExternalId).IsExternalId();
    }
}