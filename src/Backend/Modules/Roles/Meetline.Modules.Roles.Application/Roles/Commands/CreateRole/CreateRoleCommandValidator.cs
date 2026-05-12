using FluentValidation;
using Meetline.Modules.Roles.Application.Roles.DTOs.CreateRoleRequest;

namespace Meetline.Modules.Roles.Application.Roles.Commands.CreateRole;

public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
{
    public CreateRoleCommandValidator()
    {
        RuleFor(x => x.Request).SetValidator(new CreateRoleRequestValidator());
    }
}