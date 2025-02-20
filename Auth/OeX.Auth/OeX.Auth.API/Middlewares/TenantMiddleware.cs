using OeX.Auth.API.Interfaces;
using OeX.Auth.Application.Tenants;

namespace OeX.Auth.API.Middlewares;
public class TenantMiddleware
{
    private readonly RequestDelegate _next;

    public TenantMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context,
        ITenantService tenantService,
        IHttpContextAccessor _accessor)
    {
        var s = _accessor.HttpContext.User.Identity.IsAuthenticated;
        if (context.User.Identity?.IsAuthenticated == true)
        {
            var tenantId = context.User.Claims.FirstOrDefault(c => c.Type == "tenantId")?.Value;

            if (!string.IsNullOrEmpty(tenantId))
            {
                tenantService.SetTenant(tenantId);
            }
            else
            {
                tenantService.SetTenant("");
            }
        }
        else
        {
            tenantService.SetTenant("");
        }

        await _next(context);
    }
}
