using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Microsoft.AspNetCore.Mvc.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Hosting;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using WallyWombatsPublic_MVC.Models;

namespace AspNetCoreGeneratedDocument;

[RazorCompiledItemMetadata("Identifier", "/Views/Home/Pricing.cshtml")]
[CreateNewOnMetadataUpdate]
internal sealed class Views_Home_Pricing : RazorPage<HomeModel>
{
	private static readonly TagHelperAttribute __tagHelperAttribute_0 = new TagHelperAttribute("type", new HtmlString("video/mp4"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_1 = new TagHelperAttribute("src", new HtmlString("~/img/hero/ww-video.mp4"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_2 = new TagHelperAttribute("src", new HtmlString("~/img/misc/ww-pricing.png"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_3 = new TagHelperAttribute("class", new HtmlString("hero-title-img"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_4 = new TagHelperAttribute("data-aos", new HtmlString("fade-up"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_5 = new TagHelperAttribute("data-aos-duration", new HtmlString("1000"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_6 = new TagHelperAttribute("data-aos-once", new HtmlString("true"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_7 = new TagHelperAttribute("id", new HtmlString("wave"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_8 = new TagHelperAttribute("src", new HtmlString("~/img/Hero/ww-half.png"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_9 = new TagHelperAttribute("data-aos", new HtmlString("slide-left"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_10 = new TagHelperAttribute("src", new HtmlString("~/img/misc/path-yellow.svg"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_11 = new TagHelperAttribute("name", "_PartialViewPricing", HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_12 = new TagHelperAttribute("src", new HtmlString("~/img/misc/path-white.svg"), HtmlAttributeValueStyle.DoubleQuotes);

	private TagHelperExecutionContext __tagHelperExecutionContext;

	private TagHelperRunner __tagHelperRunner = new TagHelperRunner();

	private string __tagHelperStringValueBuffer;

	private TagHelperScopeManager __backed__tagHelperScopeManager;

	private UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;

	private PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;

	private TagHelperScopeManager __tagHelperScopeManager
	{
		get
		{
			if (__backed__tagHelperScopeManager == null)
			{
				__backed__tagHelperScopeManager = new TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
			}
			return __backed__tagHelperScopeManager;
		}
	}

	[RazorInject]
	public IModelExpressionProvider ModelExpressionProvider { get; private set; }

	[RazorInject]
	public IUrlHelper Url { get; private set; }

	[RazorInject]
	public IViewComponentHelper Component { get; private set; }

	[RazorInject]
	public IJsonHelper Json { get; private set; }

	[RazorInject]
	public IHtmlHelper<HomeModel> Html { get; private set; }

	public override async Task ExecuteAsync()
	{
		WriteLiteral("\r\n");
		ViewData["Title"] = "Pricing";
		WriteLiteral("\r\n<div class=\"video-container\">\r\n    <video autoplay muted loop>\r\n        ");
		__tagHelperExecutionContext = __tagHelperScopeManager.Begin("source", TagMode.SelfClosing, "de30649d1656d2a9552cd6f66fc29b193e061661b85d7790c4f7ca4c8fde08d28571", async () =>
		{
		});
		__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<UrlResolutionTagHelper>();
		__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
		await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
		if (!__tagHelperExecutionContext.Output.IsContentModified)
		{
			await __tagHelperExecutionContext.SetOutputContentAsync();
		}
		Write(__tagHelperExecutionContext.Output);
		__tagHelperExecutionContext = __tagHelperScopeManager.End();
		WriteLiteral("\r\n    </video>\r\n\r\n    <div class=\"hero-title\">\r\n        ");
		__tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", TagMode.SelfClosing, "de30649d1656d2a9552cd6f66fc29b193e061661b85d7790c4f7ca4c8fde08d29773", async () =>
		{
		});
		__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<UrlResolutionTagHelper>();
		__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
		await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
		if (!__tagHelperExecutionContext.Output.IsContentModified)
		{
			await __tagHelperExecutionContext.SetOutputContentAsync();
		}
		Write(__tagHelperExecutionContext.Output);
		__tagHelperExecutionContext = __tagHelperScopeManager.End();
		WriteLiteral("\r\n    </div>\r\n\r\n    <div class=\"hero-ww\">\r\n        ");
		__tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", TagMode.StartTagOnly, "de30649d1656d2a9552cd6f66fc29b193e061661b85d7790c4f7ca4c8fde08d211216", async () =>
		{
		});
		__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<UrlResolutionTagHelper>();
		__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
		await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
		if (!__tagHelperExecutionContext.Output.IsContentModified)
		{
			await __tagHelperExecutionContext.SetOutputContentAsync();
		}
		Write(__tagHelperExecutionContext.Output);
		__tagHelperExecutionContext = __tagHelperScopeManager.End();
		WriteLiteral("\r\n    </div>\r\n    <div class=\"pricing-wavy\">\r\n        ");
		__tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", TagMode.StartTagOnly, "de30649d1656d2a9552cd6f66fc29b193e061661b85d7790c4f7ca4c8fde08d212662", async () =>
		{
		});
		__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<UrlResolutionTagHelper>();
		__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
		await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
		if (!__tagHelperExecutionContext.Output.IsContentModified)
		{
			await __tagHelperExecutionContext.SetOutputContentAsync();
		}
		Write(__tagHelperExecutionContext.Output);
		__tagHelperExecutionContext = __tagHelperScopeManager.End();
		WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n<section id=\"Pricing\" class=\"section-pricing \">\r\n    ");
		__tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", TagMode.SelfClosing, "de30649d1656d2a9552cd6f66fc29b193e061661b85d7790c4f7ca4c8fde08d213889", async () =>
		{
		});
		__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<PartialTagHelper>();
		__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
		__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_11.Value;
		__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_11);
		await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
		if (!__tagHelperExecutionContext.Output.IsContentModified)
		{
			await __tagHelperExecutionContext.SetOutputContentAsync();
		}
		Write(__tagHelperExecutionContext.Output);
		__tagHelperExecutionContext = __tagHelperScopeManager.End();
		WriteLiteral("\r\n\r\n    <div class=\"pricing-wavy\">\r\n        ");
		__tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", TagMode.StartTagOnly, "de30649d1656d2a9552cd6f66fc29b193e061661b85d7790c4f7ca4c8fde08d215080", async () =>
		{
		});
		__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<UrlResolutionTagHelper>();
		__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_12);
		await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
		if (!__tagHelperExecutionContext.Output.IsContentModified)
		{
			await __tagHelperExecutionContext.SetOutputContentAsync();
		}
		Write(__tagHelperExecutionContext.Output);
		__tagHelperExecutionContext = __tagHelperScopeManager.End();
		WriteLiteral("\r\n    </div>\r\n</section>\r\n");
	}
}
