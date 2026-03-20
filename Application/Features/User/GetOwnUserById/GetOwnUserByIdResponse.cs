namespace Application.Features.User.GetOwnUserById;

public class GetOwnUserByIdResponse
{
    public Guid Id { get; init; }

    public required string Username { get; init; }
    public required string Email { get; init; }

    public string? FirstName { get; init; }
    public string? LastName { get; init; }

    public DateTime CreatedAt { get; init; }
    public DateTime? UpdatedAt { get; init; }
}