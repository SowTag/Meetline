namespace Web.Endpoints.V1;

public static class DebugEndpoints
{
    public static void MapDebugV1Endpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("time", () => TypedResults.Ok(DateTime.Now));
    }
}