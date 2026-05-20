using System.Security.Claims;
using Meetline.Modules.SharedKernel.Application.Context;
using Meetline.Modules.Users.Application.Users.Queries.GetInternalUserId;
using Web.Scopes;
using Wolverine;

namespace Web.Middlewares;

public class ClaimsPrincipalCallerContextProviderMiddleware
{
    public static async Task<ICallerContext> Before(IHttpContextAccessor accessor, IMessageBus bus)
    {
        var context = accessor.HttpContext;

        if (context is null) throw new UnauthorizedAccessException();

        var externalId = context.User.FindFirst(ClaimTypes.NameIdentifier);

        if (externalId is null) throw new UnauthorizedAccessException();

        var internalId = await bus.InvokeAsync<Guid>(new GetInternalUserIdQuery(externalId.Value));

        return new WebProvidedCallerContext(internalId, externalId.Value);
    }
}