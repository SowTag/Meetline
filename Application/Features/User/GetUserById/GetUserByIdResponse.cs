namespace Application.Features.User.GetUserById;

public class GetUserByIdResponse
{
    public Guid Id { get; init; }

    public required string Username { get; init; }
    public required string Email { get; init; }

    public string? FirstName { get; init; }
    public string? LastName { get; init; }

    public DateTime CreatedAt { get; init; }
}