using FluentResults;
using Mediator;
using Meetline.Modules.Users.Application.Users.DTOs.UserResponse;

namespace Meetline.Modules.Users.Application.Users.Queries.GetOwnUserById;

/// <summary>
///     Gets a user from their ID, assuming in a private context. This query might return information considered private
/// </summary>
/// <param name="Id"></param>
public record GetOwnUserByIdQuery(Guid Id) : IQuery<Result<UserResponse>>, ICacheableRequest
{
    public string CacheKey => UserCacheKeys.ById(Id);
    public TimeSpan? AbsoluteExpiration => TimeSpan.FromMinutes(30);
    public TimeSpan? SlidingExpiration => TimeSpan.FromMinutes(15);
}