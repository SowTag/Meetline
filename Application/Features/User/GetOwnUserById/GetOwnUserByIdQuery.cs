using FluentResults;
using Mediator;

namespace Application.Features.User.GetOwnUserById;

/// <summary>
///     Gets a user from their ID, assuming in a private context. This query might return information considered private
/// </summary>
/// <param name="Id"></param>
public record GetOwnUserByIdQuery(Guid Id) : IQuery<Result<GetOwnUserByIdResponse>>;