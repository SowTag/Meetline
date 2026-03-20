using FluentResults;
using Mediator;

namespace Application.Features.User.GetUserIdByExternalId;

/// <summary>
///     A query for getting a user's internal ID from their external ID
/// </summary>
/// <param name="ExternalId">The user's external ID</param>
public record GetUserIdByExternalIdQuery(string ExternalId) : IQuery<Result<GetUserIdByExternalIdResponse>>;