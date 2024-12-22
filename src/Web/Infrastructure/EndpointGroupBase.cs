using System.Security.Claims;

namespace demo_app.Web.Infrastructure;

public abstract class EndpointGroupBase
{
    public abstract void Map(WebApplication app);

    protected Guid? GetUserId(HttpContext httpContext)
    {
        if (httpContext.User.Identity?.IsAuthenticated ?? false)
        {
            return Guid.TryParse(httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var userId)
                ? userId
                : null;
        }

        return null;
    }
}
