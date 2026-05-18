using Meetline.Modules.Users.Application.Data;
using Meetline.Modules.Users.Application.Users.DTOs.UserResponse;
using Microsoft.EntityFrameworkCore;

namespace Meetline.Modules.Users.Application.Users.Queries.GetUserById;

public static class GetUserByIdHandler
{ 
    public static Task<UserResponse?> Handle(GetUserByIdQuery query,
        IUsersDbContext context,
        CancellationToken cancellationToken)
    {
        return context.Users
            .AsNoTracking()
            .Where(u => u.Id == query.Id)
            .Select(u => UserResponseMapper.ToResponse(u))
            .FirstOrDefaultAsync(cancellationToken);
    }
}