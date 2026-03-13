namespace Web.Endpoints.V2;

public static class DebugEndpoints
{
    public static void MapDebugV2Endpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("time", () => TypedResults.Ok(DateTime.UtcNow));
    }
}