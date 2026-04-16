namespace Infrastructure.Options;

public sealed class ClerkOptions
{
    public const string SectionName = "Clerk";

    public required string SecretKey { get; init; }
}