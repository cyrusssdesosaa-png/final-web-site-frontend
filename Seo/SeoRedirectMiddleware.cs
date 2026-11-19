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
        var request = context.Request;
        var method = request.Method;
        if ((HttpMethods.IsGet(method) || HttpMethods.IsHead(method))
            && SeoRedirector.IsGone(request.Path.Value))
        {
            context.Response.StatusCode = StatusCodes.Status410Gone;
            return Task.CompletedTask;
        }

        var target = _seo.GetRedirectTarget(request);
        if (target is null)
            return _next(context);

        context.Response.StatusCode = StatusCodes.Status301MovedPermanently;
        context.Response.Headers.Location = target;
        return Task.CompletedTask;
    }
}
