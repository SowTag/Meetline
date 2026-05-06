using FluentResults;
using Mediator;

namespace Meetline.Modules.Users.Application.Users.Queries.Exists;

/// <summary>
///     Checks if a user exists given their ID
/// </summary>
/// <param name="Id">The user's ID</param>
public record ExistsQuery(Guid Id) : IQuery<Result<ExistsResponse>>, ICacheableRequest
{
    public string CacheKey => UserCacheKeys.Exists(Id);
    public TimeSpan? AbsoluteExpiration => TimeSpan.FromMinutes(30);
    public TimeSpan? SlidingExpiration => TimeSpan.FromMinutes(5);
}