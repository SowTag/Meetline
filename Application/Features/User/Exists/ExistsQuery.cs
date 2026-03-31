using Application.Common.Caching;
using Application.Common.Caching.Keys;
using FluentResults;
using Mediator;

namespace Application.Features.User.Exists;

public record ExistsQuery(Guid Id) : IQuery<Result<ExistsResponse>>, ICachableRequest
{
    public string CacheKey => UserCacheKeys.Exists(Id);
    public TimeSpan? AbsoluteExpiration => TimeSpan.FromMinutes(30);
    public TimeSpan? SlidingExpiration => TimeSpan.FromMinutes(5);
}