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

[RazorCompiledItemMetadata("Identifier", "/Views/Home/BlogPost.cshtml")]
[CreateNewOnMetadataUpdate]
internal sealed class Views_Home_BlogPost : RazorPage<HomeModel>
{
	private static readonly TagHelperAttribute __tagHelperAttribute_0 = new TagHelperAttribute("type", new HtmlString("video/mp4"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_1 = new TagHelperAttribute("src", new HtmlString("~/img/hero/ww-video.mp4"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_2 = new TagHelperAttribute("src", new HtmlString("~/img/misc/ww-blog.png"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_3 = new TagHelperAttribute("class", new HtmlString("hero-title-img"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_4 = new TagHelperAttribute("data-aos", new HtmlString("fade-up"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_5 = new TagHelperAttribute("data-aos-duration", new HtmlString("1000"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_6 = new TagHelperAttribute("data-aos-once", new HtmlString("true"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_7 = new TagHelperAttribute("id", new HtmlString("wave"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_8 = new TagHelperAttribute("src", new HtmlString("~/img/Hero/ww-half.png"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_9 = new TagHelperAttribute("data-aos", new HtmlString("slide-left"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_10 = new TagHelperAttribute("data-aos-duration", new HtmlString("2000"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_11 = new TagHelperAttribute("src", new HtmlString("~/img/misc/path-white.svg"), HtmlAttributeValueStyle.DoubleQuotes);

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
		ViewData["Title"] = "Blog";
		WriteLiteral("\r\n<div class=\"video-container\">\r\n    <video autoplay muted loop>\r\n        ");
		__tagHelperExecutionContext = __tagHelperScopeManager.Begin("source", TagMode.SelfClosing, "e8d9caf49fe6758f5a2f5893a0522d872d0b32872180a6d766ff0fdacd03e8818121", async () =>
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
		__tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", TagMode.SelfClosing, "e8d9caf49fe6758f5a2f5893a0522d872d0b32872180a6d766ff0fdacd03e8819323", async () =>
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
		__tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", TagMode.StartTagOnly, "e8d9caf49fe6758f5a2f5893a0522d872d0b32872180a6d766ff0fdacd03e88110766", async () =>
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
		__tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", TagMode.StartTagOnly, "e8d9caf49fe6758f5a2f5893a0522d872d0b32872180a6d766ff0fdacd03e88112210", async () =>
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
		WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n<section>\r\n    <div class=\"container-fluid py-3\" style=\"width: 70%;\">\r\n        <div class=\"row\">\r\n            <div class=\"col-md-8 col-xl-8\">\r\n\r\n                <div class=\"row mb-5\">\r\n                    <div class=\"col-sm-12 col-md-12 col-lg-12 col-xl-12 p-3\"><img");
		BeginWriteAttribute("src", " src=\"", 952, "\"", 983, 1);
		WriteAttributeValue("", 958, Model.blog.FeaturedImage, 958, 25, isLiteral: false);
		EndWriteAttribute();
		WriteLiteral(" width=\"100%\" style=\"box-shadow: -9px 9px var(--bs-orange);border-top-left-radius: 30px;border-top-right-radius: 30px;border-bottom-right-radius: 30px;border-bottom-left-radius: 30px;\" /></div>\r\n                    <div class=\"col-sm-12 col-md-12 col-lg-12 col-xl-12 align-items-xxl-center p-4\" style=\"background: var(--bs-body-bg);border-top-left-radius: 30px;border-top-right-radius: 30px;border-bottom-right-radius: 30px;border-bottom-left-radius: 30px;\">\r\n                        <div class=\"mb-4\">\r\n                            <h5 style=\"font-size: 18px;font-family: 'WWFont', serif;color: var(--bs-emphasis-color);\">Author : ");
		Write(Model.blog.AuthorName);
		WriteLiteral("</h5>\r\n                            <h5 style=\"font-size: 18px;font-family: 'WWFont', serif;color: var(--bs-emphasis-color);\">");
		Write(Model.blog.DateCreated.ToLongDateString());
		WriteLiteral(" </h5>\r\n                        </div>\r\n                        <h2 class=\"mb-4\" style=\"font-family: 'WWFont', serif;\"><strong><span style=\"color: #ef6c00;\">");
		Write(Model.blog.Title);
		WriteLiteral("</span></strong></h2>\r\n                        <span style=\"color: rgba(30, 28, 25, 0.75); font-size: 18px !important;font-family: 'WWFont', serif;\">");
		Write(Html.Raw(Model.blog.Description));
		WriteLiteral("</span>\r\n\r\n                    </div>\r\n                </div>\r\n\r\n            </div>\r\n            <div class=\"col-md-4 col-xl-4 mx-auto p-4\">\r\n                <div class=\"row mb-5\">\r\n\r\n                    <div class=\"col-12 align-items-xxl-center px-4 py-3 mb-2\" style=\"background: #ef6c00; border-top-left-radius: 30px;border-top-right-radius: 30px;border-bottom-right-radius: 30px;border-bottom-left-radius: 30px;\">\r\n                        <span style=\"font-family: 'WWFont', serif;color: #fff; font-size: 18px;\"><strong>Related Post : ");
		Write(ViewBag.BlogCategory);
		WriteLiteral("</strong></span>\r\n                    </div>\r\n");
		foreach (Blog item in Model.BlogPosts)
		{
			WriteLiteral("                        <div class=\"col-12 align-items-xxl-center p-4 mb-2\" style=\"background: #ef6c00 ;border-top-left-radius: 30px;border-top-right-radius: 30px;border-bottom-right-radius: 30px;border-bottom-left-radius: 30px;\">\r\n\r\n                            <span class=\"mb-2\" style=\"color: #fff; font-family: 'WWFont', serif; font-size: 18px; \"><strong>");
			Write(item.Title);
			WriteLiteral("</strong></span><br />\r\n                            <span style=\"font-size: 14px;font-family: 'WWFont', serif;color: var(--bs-emphasis-color);\">\r\n                                <strong><span style=\"color: rgba(30, 28, 25, 0.75);\">Author : ");
			Write(item.AuthorName);
			WriteLiteral("</span></strong><br />\r\n                                <strong><span style=\"color: rgba(30, 28, 25, 0.75);\">");
			Write(item.DateCreated.ToLongDateString());
			WriteLiteral("</span></strong>\r\n                            </span>\r\n                            <div style=\"margin-top:20px;\">\r\n                                ");
			Write(Html.ActionLink("Read More ", "BlogPost", "Home", new
			{
				id = item.Id,
				catname = item.CategoryName
			}, new
			{
				@class = "ww-btn-blogpost"
			}));
			WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n");
		}
		WriteLiteral("\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section> ");
	}
}
