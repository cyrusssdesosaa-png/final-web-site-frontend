using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Hosting;

namespace AspNetCoreGeneratedDocument;

[RazorCompiledItemMetadata("Identifier", "/Views/Home/_PartialViewSpotifyPopup.cshtml")]
[CreateNewOnMetadataUpdate]
internal sealed class Views_Home__PartialViewSpotifyPopup : RazorPage<dynamic>
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
		WriteLiteral("<div id=\"mySpotify\" class=\"spotify-popup p-3\" style=\"background: rgb(245,179,67);text-align: right;\">\r\n    <iframe style=\"border-radius:12px\"\r\n            src=\"https://open.spotify.com/embed/artist/0Af4H36JSiCOv5ljeuPg0S?utm_source=generator\" width=\"100%\"\r\n            height=\"352\" frameBorder=\"0\"");
		BeginWriteAttribute("allowfullscreen", " allowfullscreen=\"", 427, "\"", 445, 0);
		EndWriteAttribute();
		WriteLiteral("\r\n            allow=\"autoplay; clipboard-write; encrypted-media; fullscreen; picture-in-picture\"\r\n            loading=\"lazy\"></iframe>\r\n    <button class=\"btn btn-spotify px-5\" type=\"button\" onclick=\"closeSpotify()\">Close</button>\r\n</div>");
	}
}
