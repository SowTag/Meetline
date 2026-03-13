using Asp.Versioning;
using Asp.Versioning.Conventions;
using Web.Endpoints.V1;
using Web.Endpoints.V2;

namespace Web.Endpoints;

public static class EndpointExtensions
{
    public static void MapEndpoints(this IEndpointRouteBuilder app)
    {
        var versionSet = app.NewApiVersionSet()
            .HasApiVersions([new ApiVersion(1), new ApiVersion(2)])
            .Build();

        var api = app.MapGroup("/api").WithApiVersionSet(versionSet);

        api.MapGroup("/debug").HasApiVersion(1).MapDebugV1Endpoints();
        api.MapGroup("/debug").HasApiVersion(2).MapDebugV2Endpoints();
    }
}