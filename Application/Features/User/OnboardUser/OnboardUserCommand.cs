using Application.Common.Caching;
using Application.Common.Caching.Keys;
using FluentResults;
using Mediator;

namespace Application.Features.User.OnboardUser;

public record OnboardUserCommand(
    string ExternalId,
    string Username,
    string Email,
    string? FirstName,
    string? LastName) : ICommand<Result<Guid>>, IInvalidateCacheRequest
{
    public string[] CacheKeysToInvalidate => [UserCacheKeys.ByExternalId(ExternalId)];
}