using Application.Features.Role.DTOs.RoleResponse;
using Application.Features.Role.Errors;
using FluentResults;
using Mediator;
using Meetline.Modules.Roles.Application.Data;

namespace Application.Features.Role.GetRoleById;

public class GetRoleByIdHandler(RolesDbContext context)
    : IQueryHandler<GetRoleByIdQuery, Result<RoleResponse>>
{
    private readonly RoleResponseMapper _mapper = new();

    public async ValueTask<Result<RoleResponse>> Handle(GetRoleByIdQuery query,
        CancellationToken cancellationToken)
    {
        var role = await context.Roles.FindAsync([query.Id], cancellationToken);

        if (role is null) return Result.Fail(new RoleNotFoundError(query.Id));

        return _mapper.ToResponse(role);
    }
}