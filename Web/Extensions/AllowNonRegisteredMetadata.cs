namespace Web.Extensions;

public class AllowNonRegisteredMetadata;

public static class EndpointRouteBuilderExtensions
{
    public static RouteHandlerBuilder AllowNonRegistered(this RouteHandlerBuilder builder)
    {
        return builder.WithMetadata(new AllowNonRegisteredMetadata());
    }
}