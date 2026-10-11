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

namespace AspNetCoreGeneratedDocument;

[RazorCompiledItemMetadata("Identifier", "/Views/Home/AboutUs.cshtml")]
[CreateNewOnMetadataUpdate]
internal sealed class Views_Home_AboutUs : RazorPage<dynamic>
{
	private static readonly TagHelperAttribute __tagHelperAttribute_0 = new TagHelperAttribute("type", new HtmlString("video/mp4"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_1 = new TagHelperAttribute("src", new HtmlString("~/img/hero/ww-video.mp4"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_2 = new TagHelperAttribute("src", new HtmlString("~/img/misc/ww-aboutus.png"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_3 = new TagHelperAttribute("class", new HtmlString("hero-title-img"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_4 = new TagHelperAttribute("data-aos", new HtmlString("fade-up"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_5 = new TagHelperAttribute("data-aos-duration", new HtmlString("1000"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_6 = new TagHelperAttribute("data-aos-once", new HtmlString("true"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_7 = new TagHelperAttribute("id", new HtmlString("wave"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_8 = new TagHelperAttribute("src", new HtmlString("~/img/Hero/ww-half.png"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_9 = new TagHelperAttribute("data-aos", new HtmlString("slide-left"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_10 = new TagHelperAttribute("data-aos-duration", new HtmlString("2000"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_11 = new TagHelperAttribute("src", new HtmlString("~/img/misc/path-blue.svg"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_12 = new TagHelperAttribute("src", new HtmlString("~/img/misc/aboutus-mission.png"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_13 = new TagHelperAttribute("alt", new HtmlString(""), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_14 = new TagHelperAttribute("width", new HtmlString("500"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_15 = new TagHelperAttribute("height", new HtmlString("auto"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_16 = new TagHelperAttribute("max-width", new HtmlString("376"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_17 = new TagHelperAttribute("style", new HtmlString("margin-top: -25px;"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_18 = new TagHelperAttribute("src", new HtmlString("~/img/misc/aboutus-vision.png"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_19 = new TagHelperAttribute("src", new HtmlString("~/img/misc/aboutus-history.png"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_20 = new TagHelperAttribute("src", new HtmlString("~/img/misc/path-white.svg"), HtmlAttributeValueStyle.DoubleQuotes);

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
	public IHtmlHelper<dynamic> Html { get; private set; }

	public override async Task ExecuteAsync()
	{
		ViewData["Title"] = "About Us";
		WriteLiteral("\r\n<div class=\"video-container\">\r\n    <video autoplay muted loop>\r\n        ");
		__tagHelperExecutionContext = __tagHelperScopeManager.Begin("source", TagMode.SelfClosing, "a00251d6dc5393eec617a4b2685a4c464779a954cc05663260b93fdcbe833e3311052", async () =>
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
		__tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", TagMode.SelfClosing, "a00251d6dc5393eec617a4b2685a4c464779a954cc05663260b93fdcbe833e3312255", async () =>
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
		__tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", TagMode.StartTagOnly, "a00251d6dc5393eec617a4b2685a4c464779a954cc05663260b93fdcbe833e3313699", async () =>
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
		__tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", TagMode.StartTagOnly, "a00251d6dc5393eec617a4b2685a4c464779a954cc05663260b93fdcbe833e3315143", async () =>
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
		WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n<section class=\"section-aboutus\">\r\n\r\n    <div class=\"container\">\r\n        <div class=\"col col-10 text-center mx-auto mb-5\" data-aos=\"fade-up\" data-aos-duration=\"1000\" data-aos-once=\"true\">\r\n            <h1 class=\"text-center white-stroke\" style=\"color: #ef6c00;\">\r\n                Wally Wombats Company Values\r\n            </h1>\r\n            <p class=\"w-lg-50\"\r\n               style=\"font-size: 18px;color: var(--bs-body-color);\">\r\n                Our Core Purpose, Aspirational Goal and History of our Indoor Playground that drive our organization.\r\n            </p>\r\n        </div>\r\n\r\n        <div class=\"ww_main\">\r\n            <ul class=\"ww_cards\">\r\n                <li class=\"ww_cards_item\">\r\n                    <div class=\"ww_card\">\r\n                        <div class=\"ww_card_image\">");
		__tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", TagMode.SelfClosing, "a00251d6dc5393eec617a4b2685a4c464779a954cc05663260b93fdcbe833e3317125", async () =>
		{
		});
		__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<UrlResolutionTagHelper>();
		__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_12);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_13);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_14);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_15);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_16);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_17);
		await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
		if (!__tagHelperExecutionContext.Output.IsContentModified)
		{
			await __tagHelperExecutionContext.SetOutputContentAsync();
		}
		Write(__tagHelperExecutionContext.Output);
		__tagHelperExecutionContext = __tagHelperScopeManager.End();
		WriteLiteral("</div>\r\n                        <div class=\"ww_card_content\">\r\n                            <h3 class=\"fw-bold white-stroke\" style=\"font-family: 'WWFont', serif;color: rgb(137, 214, 240);\">Core Purpose</h3>\r\n                            <div class=\"ww_card_text\">\r\n                                <p class=\"ww_text_boxes\">We are committed to providing a safe and engaging play space where children can explore their creativity, develop social skills, and build lasting memories with their loved ones.</p>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </li>\r\n                <li class=\"ww_cards_item \">\r\n                    <div class=\"ww_card\">\r\n                        <div class=\"ww_card_image\">");
		__tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", TagMode.SelfClosing, "a00251d6dc5393eec617a4b2685a4c464779a954cc05663260b93fdcbe833e3319376", async () =>
		{
		});
		__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<UrlResolutionTagHelper>();
		__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_18);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_13);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_14);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_15);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_16);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_17);
		await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
		if (!__tagHelperExecutionContext.Output.IsContentModified)
		{
			await __tagHelperExecutionContext.SetOutputContentAsync();
		}
		Write(__tagHelperExecutionContext.Output);
		__tagHelperExecutionContext = __tagHelperScopeManager.End();
		WriteLiteral("</div>\r\n                        <div class=\"ww_card_content\">\r\n                            <h3 class=\"fw-bold white-stroke\" style=\"font-family: 'WWFont', serif;color: rgb(137, 214, 240);\">Aspirational Goal</h3>\r\n                            <div class=\"ww_card_text\">\r\n                                <p class=\"ww_text_boxes\">To be the leading provider of indoor play experiences in our community, known for our commitment to safety, quality, and creating unforgettable memories for families.</p>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </li>\r\n                <li class=\"ww_cards_item\">\r\n                    <div class=\"ww_card\">\r\n                        <div class=\"ww_card_image\">\r\n                            ");
		__tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", TagMode.SelfClosing, "a00251d6dc5393eec617a4b2685a4c464779a954cc05663260b93fdcbe833e3321649", async () =>
		{
		});
		__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<UrlResolutionTagHelper>();
		__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_19);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_13);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_14);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_15);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_16);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_17);
		await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
		if (!__tagHelperExecutionContext.Output.IsContentModified)
		{
			await __tagHelperExecutionContext.SetOutputContentAsync();
		}
		Write(__tagHelperExecutionContext.Output);
		__tagHelperExecutionContext = __tagHelperScopeManager.End();
		WriteLiteral("\r\n                            </div>\r\n                        <div class=\"ww_card_content\">\r\n                            <h3 class=\"fw-bold white-stroke\" style=\"font-family: 'WWFont', serif;color: rgb(137, 214, 240);\">History of our Indoor Playground</h3>\r\n                            <div class=\"ww_card_text\">\r\n                                <p class=\"ww_text_boxes\">\r\n                                    Wally Wombats was founded in 2020 just in time for Australia Day celebration. Our goal was to create a place designed for children to develop social skills, fine and gross motor, balance, agility and problem-solving skills.</p>\r\n                                <p class=\"ww_text_boxes\">\r\n                                    Our indoor playground was initially conceptualized to entertain therapy patient's siblings and families while waiting at the reception of SPOT4Tots.\r\n                                    We have since become a beloved destination for families, offering a variety of exciting play areas and a c");
		WriteLiteral("ommitment to creating lasting memories. We are proud of our journey and excited to continue providing exceptional experiences for years to come.</p>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </li>\r\n            </ul>\r\n        </div>\r\n    </div>\r\n\r\n\r\n    <div class=\"footer-wavy\">\r\n        ");
		__tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", TagMode.StartTagOnly, "a00251d6dc5393eec617a4b2685a4c464779a954cc05663260b93fdcbe833e3324551", async () =>
		{
		});
		__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<UrlResolutionTagHelper>();
		__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_20);
		await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
		if (!__tagHelperExecutionContext.Output.IsContentModified)
		{
			await __tagHelperExecutionContext.SetOutputContentAsync();
		}
		Write(__tagHelperExecutionContext.Output);
		__tagHelperExecutionContext = __tagHelperScopeManager.End();
		WriteLiteral("\r\n    </div>\r\n</section>\r\n\r\n\r\n");
	}
}
