namespace Meetline.Modules.Users.Application.Users.DTOs.UserResponse;

public record UserResponse(
    Guid Id,
    string Username,
    string Email,
    string? FirstName,
    string? LastName,
    DateTime CreatedAt,
    DateTime? UpdatedAt);