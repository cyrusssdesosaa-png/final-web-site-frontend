using Microsoft.AspNetCore.Http;

namespace WallyWombatsPublic_MVC.Seo;

public sealed class SeoRedirectMiddleware
{
    private readonly RequestDelegate _next;
    private readonly SeoRedirector _seo;

    public SeoRedirectMiddleware(RequestDelegate next, SeoRedirector seo)
    {
        _next = next;
        _seo = seo;
    }

    public Task Invoke(HttpContext context)
    {
        var target = _seo.GetRedirectTarget(context.Request);
        if (target is null)
            return _next(context);

        context.Response.StatusCode = StatusCodes.Status301MovedPermanently;
        context.Response.Headers.Location = target;
        return Task.CompletedTask;
    }
}
