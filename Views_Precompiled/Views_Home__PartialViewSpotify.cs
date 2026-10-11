using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Hosting;

namespace AspNetCoreGeneratedDocument;

[RazorCompiledItemMetadata("Identifier", "/Views/Home/_PartialViewSpotify.cshtml")]
[CreateNewOnMetadataUpdate]
internal sealed class Views_Home__PartialViewSpotify : RazorPage<dynamic>
{
	[RazorInject]
	public IModelExpressionProvider ModelExpressionProvider { get; private set; }

	[RazorInject]
	public IUrlHelper Url { get; private set; }

	[RazorInject]
	public IViewComponentHelper Component { get; private set; }

	[RazorInject]
	public IJsonHelper Json { get; private set; }

	[RazorInject]
	public IHtmlHelper<dynamic> Html { get; private set; }

	public override async Task ExecuteAsync()
	{
		WriteLiteral("\r\n<div class=\"modal fade\" id=\"modal-spotify\" data-bs-backdrop=\"static\" tabindex=\"-1\" role=\"dialog\" aria-hidden=\"true\">\r\n    <div class=\"modal-dialog\" role=\"document\">\r\n        <div class=\"modal-content\">\r\n            <div class=\"spotify-modal p-3\">\r\n                <iframe style=\"border-radius:12px\"\r\n                        src=\"https://open.spotify.com/embed/artist/0Af4H36JSiCOv5ljeuPg0S?utm_source=generator\" width=\"100%\"\r\n                        height=\"400\" frameBorder=\"0\"");
		BeginWriteAttribute("allowfullscreen", " allowfullscreen=\"", 610, "\"", 628, 0);
		EndWriteAttribute();
		WriteLiteral("\r\n                        allow=\"autoplay; clipboard-write; encrypted-media; fullscreen; picture-in-picture\"\r\n                        loading=\"lazy\">\r\n                </iframe>\r\n                <button class=\"btn btn-spotify px-5\" type=\"button\" data-bs-dismiss=\"modal\">Close</button>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
	}
}
