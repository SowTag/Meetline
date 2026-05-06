namespace Meetline.Modules.Users.Application.Users.DTOs.UserPublicResponse;

public record UserPublicResponse(Guid Id, string Username, string Email, string? FirstName, string? LastName);