using FluentResults;
using Mediator;

namespace Application.Features.User.GetUserById;

/// <summary>
///     Gets a user by their ID, used for public queries (does not include private info)
/// </summary>
/// <param name="Id">The user's ID</param>
public record GetUserByIdQuery(Guid Id) : IQuery<Result<GetUserByIdResponse>>;