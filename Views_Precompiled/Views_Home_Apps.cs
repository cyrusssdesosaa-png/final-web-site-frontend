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

[RazorCompiledItemMetadata("Identifier", "/Views/Home/Apps.cshtml")]
[CreateNewOnMetadataUpdate]
internal sealed class Views_Home_Apps : RazorPage<dynamic>
{
	private static readonly TagHelperAttribute __tagHelperAttribute_0 = new TagHelperAttribute("src", new HtmlString("~/img/app/ww-mobile-app.png"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_1 = new TagHelperAttribute("class", new HtmlString("mobile-header"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_2 = new TagHelperAttribute("src", new HtmlString("~/img/APP/app-ww-mobile.png"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_3 = new TagHelperAttribute("class", new HtmlString("mobile-phone"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_4 = new TagHelperAttribute("src", new HtmlString("~/img/APP/ww-download-our-new-app.png"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_5 = new TagHelperAttribute("class", new HtmlString("mobile-newapp"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_6 = new TagHelperAttribute("src", new HtmlString("~/img/APP/ww-app-bc-apple.svg"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_7 = new TagHelperAttribute("class", new HtmlString("mobile-link"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_8 = new TagHelperAttribute("style", new HtmlString("background-color: #fff"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_9 = new TagHelperAttribute("src", new HtmlString("~/img/APP/ww-app-apple.png"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_10 = new TagHelperAttribute("src", new HtmlString("~/img/APP/ww-app-bc-google.svg"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_11 = new TagHelperAttribute("src", new HtmlString("~/img/APP/ww-app-google.png"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_12 = new TagHelperAttribute("src", new HtmlString("~/img/app/ww-mobile-games.png"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_13 = new TagHelperAttribute("src", new HtmlString("~/img/APP/app-ww-adventure.png"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_14 = new TagHelperAttribute("src", new HtmlString("~/img/APP/app-ww-world.png"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_15 = new TagHelperAttribute("src", new HtmlString("~/img/APP/app-ww-coloring.png"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_16 = new TagHelperAttribute("id", new HtmlString("wave"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_17 = new TagHelperAttribute("src", new HtmlString("~/img/misc/path-white.svg"), HtmlAttributeValueStyle.DoubleQuotes);

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
		ViewData["Title"] = "Apps";
		WriteLiteral("\r\n<div class=\"app-container text-center\"> \r\n   \r\n\r\n    <div class=\"container\">\r\n        <div class=\"row mb-5\">\r\n            <div class=\"col-12\">\r\n                <div class=\"row\">\r\n                    <div class=\"col-md-10 mx-auto\">");
		__tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", TagMode.SelfClosing, "54ea3cfa4e08baf54c967147d003a1402dea316b2672973bfd0fce1d02b09c9910262", async () =>
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
		WriteLiteral("</div>\r\n                </div>\r\n            </div>\r\n            <div class=\"col-sm-12 col-md-12 col-lg-10 col-xl-9 mx-auto\">\r\n                <div class=\"row\">\r\n                    <div class=\"col-md-6\">");
		__tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", TagMode.SelfClosing, "54ea3cfa4e08baf54c967147d003a1402dea316b2672973bfd0fce1d02b09c9911615", async () =>
		{
		});
		__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<UrlResolutionTagHelper>();
		__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
		await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
		if (!__tagHelperExecutionContext.Output.IsContentModified)
		{
			await __tagHelperExecutionContext.SetOutputContentAsync();
		}
		Write(__tagHelperExecutionContext.Output);
		__tagHelperExecutionContext = __tagHelperScopeManager.End();
		WriteLiteral("</div>\r\n                    <div class=\"col-md-6 my-auto\">\r\n                        <div class=\"row mb-4\">\r\n                            <div class=\"col\">");
		__tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", TagMode.SelfClosing, "54ea3cfa4e08baf54c967147d003a1402dea316b2672973bfd0fce1d02b09c9912914", async () =>
		{
		});
		__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<UrlResolutionTagHelper>();
		__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
		await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
		if (!__tagHelperExecutionContext.Output.IsContentModified)
		{
			await __tagHelperExecutionContext.SetOutputContentAsync();
		}
		Write(__tagHelperExecutionContext.Output);
		__tagHelperExecutionContext = __tagHelperScopeManager.End();
		WriteLiteral("</div>\r\n                        </div>\r\n                        <div class=\"row\">\r\n                            <div class=\"col text-end\">\r\n                                ");
		__tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", TagMode.SelfClosing, "54ea3cfa4e08baf54c967147d003a1402dea316b2672973bfd0fce1d02b09c9914231", async () =>
		{
		});
		__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<UrlResolutionTagHelper>();
		__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
		await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
		if (!__tagHelperExecutionContext.Output.IsContentModified)
		{
			await __tagHelperExecutionContext.SetOutputContentAsync();
		}
		Write(__tagHelperExecutionContext.Output);
		__tagHelperExecutionContext = __tagHelperScopeManager.End();
		WriteLiteral("\r\n                                <a href=\"https://apps.apple.com/ph/app/wally-wombats/id6550894231\" target=\"_blank\">\r\n                                    ");
		__tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", TagMode.SelfClosing, "54ea3cfa4e08baf54c967147d003a1402dea316b2672973bfd0fce1d02b09c9915611", async () =>
		{
		});
		__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<UrlResolutionTagHelper>();
		__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
		await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
		if (!__tagHelperExecutionContext.Output.IsContentModified)
		{
			await __tagHelperExecutionContext.SetOutputContentAsync();
		}
		Write(__tagHelperExecutionContext.Output);
		__tagHelperExecutionContext = __tagHelperScopeManager.End();
		WriteLiteral("</a>\r\n                            </div>\r\n                            <div class=\"col text-start\">\r\n                                ");
		__tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", TagMode.SelfClosing, "54ea3cfa4e08baf54c967147d003a1402dea316b2672973bfd0fce1d02b09c9916885", async () =>
		{
		});
		__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<UrlResolutionTagHelper>();
		__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
		await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
		if (!__tagHelperExecutionContext.Output.IsContentModified)
		{
			await __tagHelperExecutionContext.SetOutputContentAsync();
		}
		Write(__tagHelperExecutionContext.Output);
		__tagHelperExecutionContext = __tagHelperScopeManager.End();
		WriteLiteral("\r\n                                <a href=\"https://play.google.com/store/apps/details?id=com.wallywombatsapp.wallywombats&pcampaignid=web_share\" target=\"_blank\">\r\n                                    ");
		__tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", TagMode.SelfClosing, "54ea3cfa4e08baf54c967147d003a1402dea316b2672973bfd0fce1d02b09c9918310", async () =>
		{
		});
		__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<UrlResolutionTagHelper>();
		__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
		await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
		if (!__tagHelperExecutionContext.Output.IsContentModified)
		{
			await __tagHelperExecutionContext.SetOutputContentAsync();
		}
		Write(__tagHelperExecutionContext.Output);
		__tagHelperExecutionContext = __tagHelperScopeManager.End();
		WriteLiteral("</a>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <div class=\"row mb-5\">\r\n            <div class=\"col-12\">\r\n                <div class=\"row\">\r\n                    <div class=\"col-md-10 mx-auto\">");
		__tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", TagMode.SelfClosing, "54ea3cfa4e08baf54c967147d003a1402dea316b2672973bfd0fce1d02b09c9919768", async () =>
		{
		});
		__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<UrlResolutionTagHelper>();
		__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_12);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
		await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
		if (!__tagHelperExecutionContext.Output.IsContentModified)
		{
			await __tagHelperExecutionContext.SetOutputContentAsync();
		}
		Write(__tagHelperExecutionContext.Output);
		__tagHelperExecutionContext = __tagHelperScopeManager.End();
		WriteLiteral("</div>\r\n                </div>\r\n            </div>\r\n            <div class=\"col-md-5 col-lg-5 col-xl-4 mx-auto mb-5\">\r\n                <div class=\"row\">\r\n                    <div class=\"col px-0\">");
		__tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", TagMode.SelfClosing, "54ea3cfa4e08baf54c967147d003a1402dea316b2672973bfd0fce1d02b09c9921115", async () =>
		{
		});
		__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<UrlResolutionTagHelper>();
		__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_13);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
		await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
		if (!__tagHelperExecutionContext.Output.IsContentModified)
		{
			await __tagHelperExecutionContext.SetOutputContentAsync();
		}
		Write(__tagHelperExecutionContext.Output);
		__tagHelperExecutionContext = __tagHelperScopeManager.End();
		WriteLiteral("</div>\r\n                </div>\r\n                <div class=\"row\">\r\n                    <div class=\"col px-0\">\r\n                        <h3 class=\"text-center white-stroke\" style=\"color: #7c00fe;\">\r\n                            Get it here\r\n                        </h3>\r\n                    </div>\r\n                </div>\r\n                <div class=\"row\">\r\n                    <div class=\"col-6 text-end\">\r\n                        <a href=\" https://apps.apple.com/ph/app/wally-wombats-adventure/id6560111416\" target=\"_blank\">");
		__tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", TagMode.SelfClosing, "54ea3cfa4e08baf54c967147d003a1402dea316b2672973bfd0fce1d02b09c9922792", async () =>
		{
		});
		__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<UrlResolutionTagHelper>();
		__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
		await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
		if (!__tagHelperExecutionContext.Output.IsContentModified)
		{
			await __tagHelperExecutionContext.SetOutputContentAsync();
		}
		Write(__tagHelperExecutionContext.Output);
		__tagHelperExecutionContext = __tagHelperScopeManager.End();
		WriteLiteral("</a>\r\n                    </div>\r\n                    <div class=\"col-6 text-start\">\r\n                        <a href=\"https://play.google.com/store/apps/details?id=com.WallyWombats.WallyWombatsAdventure\" target=\"_blank\">");
		__tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", TagMode.SelfClosing, "54ea3cfa4e08baf54c967147d003a1402dea316b2672973bfd0fce1d02b09c9924159", async () =>
		{
		});
		__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<UrlResolutionTagHelper>();
		__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
		await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
		if (!__tagHelperExecutionContext.Output.IsContentModified)
		{
			await __tagHelperExecutionContext.SetOutputContentAsync();
		}
		Write(__tagHelperExecutionContext.Output);
		__tagHelperExecutionContext = __tagHelperScopeManager.End();
		WriteLiteral("</a>\r\n                    </div>\r\n                    \r\n                </div>\r\n            </div>\r\n            <div class=\"col-md-5 col-lg-5 col-xl-4 mx-auto mb-5\">\r\n                <div class=\"row\">\r\n                    <div class=\"col px-0\">");
		__tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", TagMode.SelfClosing, "54ea3cfa4e08baf54c967147d003a1402dea316b2672973bfd0fce1d02b09c9925558", async () =>
		{
		});
		__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<UrlResolutionTagHelper>();
		__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_14);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
		await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
		if (!__tagHelperExecutionContext.Output.IsContentModified)
		{
			await __tagHelperExecutionContext.SetOutputContentAsync();
		}
		Write(__tagHelperExecutionContext.Output);
		__tagHelperExecutionContext = __tagHelperScopeManager.End();
		WriteLiteral("</div>\r\n                </div>\r\n                <div class=\"row\">\r\n                    <div class=\"col px-0\">\r\n                        <h3 class=\"text-center white-stroke\" style=\"color: #7c00fe;\">\r\n                            Get it here\r\n                        </h3>\r\n                    </div>\r\n                </div>\r\n                <div class=\"row\">\r\n                    <div class=\"col-6 text-end\">\r\n                        <a href=\"https://apps.apple.com/ph/app/wally-wombats-world/id6557056782\" target=\"_blank\">");
		__tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", TagMode.SelfClosing, "54ea3cfa4e08baf54c967147d003a1402dea316b2672973bfd0fce1d02b09c9927230", async () =>
		{
		});
		__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<UrlResolutionTagHelper>();
		__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
		await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
		if (!__tagHelperExecutionContext.Output.IsContentModified)
		{
			await __tagHelperExecutionContext.SetOutputContentAsync();
		}
		Write(__tagHelperExecutionContext.Output);
		__tagHelperExecutionContext = __tagHelperScopeManager.End();
		WriteLiteral("</a>\r\n                    </div>\r\n                    <div class=\"col-6 text-start\">\r\n                        <a href=\" https://play.google.com/store/apps/details?id=com.wallywombats.wallywombatsworld\" target=\"_blank\">");
		__tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", TagMode.SelfClosing, "54ea3cfa4e08baf54c967147d003a1402dea316b2672973bfd0fce1d02b09c9928594", async () =>
		{
		});
		__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<UrlResolutionTagHelper>();
		__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
		await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
		if (!__tagHelperExecutionContext.Output.IsContentModified)
		{
			await __tagHelperExecutionContext.SetOutputContentAsync();
		}
		Write(__tagHelperExecutionContext.Output);
		__tagHelperExecutionContext = __tagHelperScopeManager.End();
		WriteLiteral("</a>\r\n                        </div>\r\n                </div>\r\n            </div>\r\n            <div class=\"col-md-5 col-lg-5 col-xl-4 mx-auto mb-5\">\r\n                <div class=\"row\">\r\n                    <div class=\"col px-0\">");
		__tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", TagMode.SelfClosing, "54ea3cfa4e08baf54c967147d003a1402dea316b2672973bfd0fce1d02b09c9929973", async () =>
		{
		});
		__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<UrlResolutionTagHelper>();
		__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_15);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
		await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
		if (!__tagHelperExecutionContext.Output.IsContentModified)
		{
			await __tagHelperExecutionContext.SetOutputContentAsync();
		}
		Write(__tagHelperExecutionContext.Output);
		__tagHelperExecutionContext = __tagHelperScopeManager.End();
		WriteLiteral("</div>\r\n                </div>\r\n                <div class=\"row\">\r\n                    <div class=\"col px-0\">\r\n                        <h3 class=\"text-center white-stroke\" style=\"color: #7c00fe;\">\r\n                            Get it here\r\n                        </h3>\r\n                    </div>\r\n                </div>\r\n                <div class=\"row\">\r\n                    <div class=\"col-6 text-end\">\r\n                        <a href=\"https://apps.apple.com/ph/app/coloring-wally-wombats/id6587559491\" target=\"_blank\">");
		__tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", TagMode.SelfClosing, "54ea3cfa4e08baf54c967147d003a1402dea316b2672973bfd0fce1d02b09c9931648", async () =>
		{
		});
		__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<UrlResolutionTagHelper>();
		__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
		await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
		if (!__tagHelperExecutionContext.Output.IsContentModified)
		{
			await __tagHelperExecutionContext.SetOutputContentAsync();
		}
		Write(__tagHelperExecutionContext.Output);
		__tagHelperExecutionContext = __tagHelperScopeManager.End();
		WriteLiteral("</a>\r\n                    </div>\r\n                    <div class=\"col-6 text-start\">\r\n                        <a href=\"https://play.google.com/store/apps/details?id=com.wallywombats.coloring\" target=\"_blank\">");
		__tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", TagMode.SelfClosing, "54ea3cfa4e08baf54c967147d003a1402dea316b2672973bfd0fce1d02b09c9933002", async () =>
		{
		});
		__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<UrlResolutionTagHelper>();
		__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
		await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
		if (!__tagHelperExecutionContext.Output.IsContentModified)
		{
			await __tagHelperExecutionContext.SetOutputContentAsync();
		}
		Write(__tagHelperExecutionContext.Output);
		__tagHelperExecutionContext = __tagHelperScopeManager.End();
		WriteLiteral("</a>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n\r\n\r\n    <div class=\"app-wavy\">\r\n        ");
		__tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", TagMode.StartTagOnly, "54ea3cfa4e08baf54c967147d003a1402dea316b2672973bfd0fce1d02b09c9934303", async () =>
		{
		});
		__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<UrlResolutionTagHelper>();
		__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_16);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_17);
		await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
		if (!__tagHelperExecutionContext.Output.IsContentModified)
		{
			await __tagHelperExecutionContext.SetOutputContentAsync();
		}
		Write(__tagHelperExecutionContext.Output);
		__tagHelperExecutionContext = __tagHelperScopeManager.End();
		WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n");
	}
}
