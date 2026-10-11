using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Microsoft.AspNetCore.Mvc.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Hosting;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using WallyWombatsPublic_MVC.Models;

namespace AspNetCoreGeneratedDocument;

[RazorCompiledItemMetadata("Identifier", "/Views/Home/FAQs.cshtml")]
[CreateNewOnMetadataUpdate]
internal sealed class Views_Home_FAQs : RazorPage<HomeModel>
{
	private static readonly TagHelperAttribute __tagHelperAttribute_0 = new TagHelperAttribute("type", new HtmlString("video/mp4"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_1 = new TagHelperAttribute("src", new HtmlString("~/img/hero/ww-video.mp4"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_2 = new TagHelperAttribute("src", new HtmlString("~/img/misc/ww-faqs.png"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_3 = new TagHelperAttribute("class", new HtmlString("hero-title-img"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_4 = new TagHelperAttribute("data-aos", new HtmlString("fade-up"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_5 = new TagHelperAttribute("data-aos-duration", new HtmlString("1000"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_6 = new TagHelperAttribute("data-aos-once", new HtmlString("true"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_7 = new TagHelperAttribute("id", new HtmlString("wave"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_8 = new TagHelperAttribute("src", new HtmlString("~/img/Hero/ww-half.png"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_9 = new TagHelperAttribute("data-aos", new HtmlString("slide-left"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_10 = new TagHelperAttribute("data-aos-duration", new HtmlString("2000"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_11 = new TagHelperAttribute("src", new HtmlString("~/img/misc/path-orange.svg"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_12 = new TagHelperAttribute("src", new HtmlString("~/img/misc/path-white.svg"), HtmlAttributeValueStyle.DoubleQuotes);

	private TagHelperExecutionContext __tagHelperExecutionContext;

	private TagHelperRunner __tagHelperRunner = new TagHelperRunner();

	private string __tagHelperStringValueBuffer;

	private TagHelperScopeManager __backed__tagHelperScopeManager;

	private UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;

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
		ViewData["Title"] = "FAQs";
		WriteLiteral("\r\n<div class=\"video-container\">\r\n    <video autoplay muted loop>\r\n        ");
		__tagHelperExecutionContext = __tagHelperScopeManager.Begin("source", TagMode.SelfClosing, "c6197bc9987152a2404e032a46af4c48847493e538486df9fb741f6cef82d8248458", async () =>
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
		__tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", TagMode.SelfClosing, "c6197bc9987152a2404e032a46af4c48847493e538486df9fb741f6cef82d8249660", async () =>
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
		__tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", TagMode.StartTagOnly, "c6197bc9987152a2404e032a46af4c48847493e538486df9fb741f6cef82d82411103", async () =>
		{
		});
		__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<UrlResolutionTagHelper>();
		__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
		await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
		if (!__tagHelperExecutionContext.Output.IsContentModified)
		{
			await __tagHelperExecutionContext.SetOutputContentAsync();
		}
		Write(__tagHelperExecutionContext.Output);
		__tagHelperExecutionContext = __tagHelperScopeManager.End();
		WriteLiteral("\r\n    </div>\r\n    <div class=\"hero-wavy\">\r\n        ");
		__tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", TagMode.StartTagOnly, "c6197bc9987152a2404e032a46af4c48847493e538486df9fb741f6cef82d82412547", async () =>
		{
		});
		__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<UrlResolutionTagHelper>();
		__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
		await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
		if (!__tagHelperExecutionContext.Output.IsContentModified)
		{
			await __tagHelperExecutionContext.SetOutputContentAsync();
		}
		Write(__tagHelperExecutionContext.Output);
		__tagHelperExecutionContext = __tagHelperScopeManager.End();
		WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n<section class=\"section-faq\">\r\n\r\n    <div class=\"container\">\r\n        <div class=\"row mb-5\">\r\n            <div class=\"col-md-8 col-xl-8 text-center mx-auto\">\r\n                <h1 class=\"fw-bold px-3 white-stroke\" style=\"font-family: 'WWFont', serif;color: #ef6c00;\">Frequently Ask Questions</h1>\r\n                <p class=\"px-3 fw-bold\" style=\"font-family: 'WWFont', serif;font-size: 18px;color: var(--bs-body-color);\">\r\n                    Curious about something? Our FAQ page has the answers\u00a0you\u00a0need.\r\n                </p>\r\n            </div>\r\n        </div>\r\n\r\n        <div class=\"row\">\r\n            <div class=\"col-md-8 col-xl-8 text-center mx-auto\">\r\n                <h3 class=\"fw-bold px-3 white-stroke\" style=\"font-family: 'WWFont', serif;color: #ef6c00;\">General Admission</h3>\r\n            </div>\r\n        </div>\r\n        <div class=\"mb-3 p-1\">\r\n            <div class=\"accordion\" role=\"tablist\" id=\"accordion-general\">\r\n");
		foreach (var item in Model.FAQViewModel.Select((FAQ value, int index) => new { value, index }))
		{
			if (item.value.Category == "GeneralAdmission")
			{
				string id = "general-item-" + item.index;
				WriteLiteral("                        <div class=\"accordion-item\" data-aos=\"flip-up\" data-aos-duration=\"1000\" data-aos-once=\"true\">\r\n                            <h2 class=\"accordion-header\" role=\"tab\">\r\n                                <button class=\"accordion-button collapsed\" type=\"button\"\r\n                                        data-bs-toggle=\"collapse\" data-bs-target=\"#");
				Write(id);
				WriteLiteral("\" aria-expanded=\"false\"");
				BeginWriteAttribute("aria-controls", "\r\n                                        aria-controls=\"", 2326, "\"", 2386, 1);
				WriteAttributeValue("", 2383, id, 2383, 3, isLiteral: false);
				EndWriteAttribute();
				WriteLiteral(" style=\"font-family: 'WWFont', serif;\">\r\n                                    ");
				Write(item.value.Question);
				WriteLiteral("\r\n                                </button>\r\n                            </h2>\r\n                            <div");
				BeginWriteAttribute("id", " id=\"", 2596, "\"", 2604, 1);
				WriteAttributeValue("", 2601, id, 2601, 3, isLiteral: false);
				EndWriteAttribute();
				WriteLiteral(" class=\"accordion-collapse collapse item-1\" role=\"tabpanel\" data-bs-parent=\"#accordion-general\">\r\n                                <div class=\"accordion-body\">\r\n                                    <p class=\"mb-0\" style=\"font-family: 'WWFont', serif;\">\r\n                                        ");
				Write(Html.Raw(item.value.Answer));
				WriteLiteral("\r\n                                    </p>\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n");
			}
		}
		WriteLiteral("            </div>\r\n        </div>\r\n\r\n        <div class=\"row\">\r\n            <div class=\"col-md-8 col-xl-8 text-center mx-auto\">\r\n                <h3 class=\"fw-bold px-3 white-stroke\" style=\"font-family: 'WWFont', serif;color: #ef6c00;\">Party And Events</h3>\r\n            </div>\r\n        </div>\r\n        <div class=\"mb-3 p-1\">\r\n            <div class=\"accordion\" role=\"tablist\" id=\"accordion-party\">\r\n");
		foreach (var item2 in Model.FAQViewModel.Select((FAQ value, int index) => new { value, index }))
		{
			if (item2.value.Category == "PartyAndEvents")
			{
				string id2 = "party-item-" + item2.index;
				WriteLiteral("                        <div class=\"accordion-item\" data-aos=\"flip-up\" data-aos-duration=\"1000\" data-aos-once=\"true\">\r\n                            <h2 class=\"accordion-header\" role=\"tab\">\r\n                                <button class=\"accordion-button collapsed\" type=\"button\"\r\n                                        data-bs-toggle=\"collapse\" data-bs-target=\"#");
				Write(id2);
				WriteLiteral("\" aria-expanded=\"false\"");
				BeginWriteAttribute("aria-controls", "\r\n                                        aria-controls=\"", 4223, "\"", 4283, 1);
				WriteAttributeValue("", 4280, id2, 4280, 3, isLiteral: false);
				EndWriteAttribute();
				WriteLiteral(" style=\"font-family: 'WWFont', serif;\">\r\n                                    ");
				Write(item2.value.Question);
				WriteLiteral("\r\n                                </button>\r\n                            </h2>\r\n                            <div");
				BeginWriteAttribute("id", " id=\"", 4493, "\"", 4501, 1);
				WriteAttributeValue("", 4498, id2, 4498, 3, isLiteral: false);
				EndWriteAttribute();
				WriteLiteral(" class=\"accordion-collapse collapse item-1\" role=\"tabpanel\" data-bs-parent=\"#accordion-party\">\r\n                                <div class=\"accordion-body\">\r\n                                    <p class=\"mb-0\" style=\"font-family: 'WWFont', serif;\">\r\n                                        ");
				Write(Html.Raw(item2.value.Answer));
				WriteLiteral("\r\n                                    </p>\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n");
			}
		}
		WriteLiteral("            </div>\r\n        </div>\r\n\r\n    </div>\r\n\r\n    <div class=\"footer-wavy\">\r\n        ");
		__tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", TagMode.StartTagOnly, "c6197bc9987152a2404e032a46af4c48847493e538486df9fb741f6cef82d82422446", async () =>
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
		WriteLiteral("\r\n    </div>\r\n</section>");
	}
}
