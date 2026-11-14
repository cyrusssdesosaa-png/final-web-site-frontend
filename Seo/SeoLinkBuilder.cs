using Microsoft.AspNetCore.Http;

namespace WallyWombatsPublic_MVC.Seo;

public sealed class SeoLinkBuilder
{
    private readonly SeoRedirector _seo;

    public SeoLinkBuilder(SeoRedirector seo) => _seo = seo;

    public string Origin => _seo.Origin;

    public string CanonicalHref(HttpRequest request) => _seo.CanonicalHref(request.Path.Value);
}
