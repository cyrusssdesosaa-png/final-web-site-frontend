using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Hosting;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using WallyWombatsPublic_MVC.Models;

namespace AspNetCoreGeneratedDocument;

[RazorCompiledItemMetadata("Identifier", "/Views/Home/_PartialViewBlog.cshtml")]
[CreateNewOnMetadataUpdate]
internal sealed class Views_Home__PartialViewBlog : RazorPage<HomeModel>
{
	private static readonly TagHelperAttribute __tagHelperAttribute_0 = new TagHelperAttribute("type", "hidden", HtmlAttributeValueStyle.DoubleQuotes);

	private TagHelperExecutionContext __tagHelperExecutionContext;

	private TagHelperRunner __tagHelperRunner = new TagHelperRunner();

	private string __tagHelperStringValueBuffer;

	private TagHelperScopeManager __backed__tagHelperScopeManager;

	private InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;

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
		int x = 0;
		foreach (Blog item in Model.BlogViewModel)
		{
			if (x % 2 == 0)
			{
				WriteLiteral("        <div class=\"mx-auto p-2 blogposts\">\r\n            <div class=\"row\" data-aos=\"flip-up\" data-aos-duration=\"1300\" data-aos-once=\"true\">\r\n                <div class=\"col-sm-12 col-md-12 col-lg-5 col-xl-5 p-3\">\r\n                    <img");
				BeginWriteAttribute("src", " src=\"", 448, "\"", 486, 1);
				WriteAttributeValue("", 454, Url.Content(item.FeaturedImage), 454, 32, isLiteral: false);
				EndWriteAttribute();
				WriteLiteral(" width=\"100%\" style=\"box-shadow: -9px 9px var(--bs-orange);border-radius:30px;\">\r\n                </div>\r\n                <div class=\"col-sm-12 col-md-12 col-lg-7 col-xl-7 align-items-xxl-center px-2 py-5\">\r\n                    <h2 class=\"mb-4\" style=\"font-family: 'WWFont', serif;\">\r\n                        <strong>\r\n                            <span style=\"color: rgb(239, 108, 0);\">");
				Write(item.Title);
				WriteLiteral("</span>\r\n                        </strong>\r\n                    </h2>\r\n                    <p class=\"mb-4\" style=\"font-size: 18px;font-family: 'WWFont', serif;\">\r\n                        ");
				Write(item.Summary);
				WriteLiteral("\r\n                    </p>\r\n                    ");
				__tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", TagMode.SelfClosing, "f300c92495164fe128f97c0884a7f32193d6d2f51b5be23d8ba295ecafe913fc6318", async () =>
				{
				});
				__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<InputTagHelper>();
				__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
				__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
				__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
				__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, (HomeModel __model) => item.Id);
				__tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, HtmlAttributeValueStyle.DoubleQuotes);
				await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
				if (!__tagHelperExecutionContext.Output.IsContentModified)
				{
					await __tagHelperExecutionContext.SetOutputContentAsync();
				}
				Write(__tagHelperExecutionContext.Output);
				__tagHelperExecutionContext = __tagHelperScopeManager.End();
				WriteLiteral("\r\n                    ");
				__tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", TagMode.SelfClosing, "f300c92495164fe128f97c0884a7f32193d6d2f51b5be23d8ba295ecafe913fc8070", async () =>
				{
				});
				__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<InputTagHelper>();
				__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
				__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
				__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
				__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, (HomeModel __model) => item.CategoryName);
				__tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, HtmlAttributeValueStyle.DoubleQuotes);
				await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
				if (!__tagHelperExecutionContext.Output.IsContentModified)
				{
					await __tagHelperExecutionContext.SetOutputContentAsync();
				}
				Write(__tagHelperExecutionContext.Output);
				__tagHelperExecutionContext = __tagHelperScopeManager.End();
				WriteLiteral("\r\n                    <a class=\"ww-btn-light text-white py-3 px-5 text-decoration-none\"");
				BeginWriteAttribute("href", " href=\"", 1335, "\"", 1424, 1);
				WriteAttributeValue("", 1342, Url.Action("BlogPost", "Home", new
				{
					id = item.Id,
					catname = item.CategoryName
				}), 1342, 82, isLiteral: false);
				EndWriteAttribute();
				WriteLiteral(" style=\"border-radius:30px;\">\r\n                        Read More &nbsp;\r\n                        <svg xmlns=\"http://www.w3.org/2000/svg\" width=\"1em\" height=\"1em\" fill=\"currentColor\" viewBox=\"0 0 16 16\" class=\"bi bi-arrow-right\" style=\"font-size: 25px;\">\r\n                            <path fill-rule=\"evenodd\" d=\"M1 8a.5.5 0 0 1 .5-.5h11.793l-3.147-3.146a.5.5 0 0 1 .708-.708l4 4a.5.5 0 0 1 0 .708l-4 4a.5.5 0 0 1-.708-.708L13.293 8.5H1.5A.5.5 0 0 1 1 8\"></path>\r\n                        </svg>\r\n                    </a>\r\n                </div>\r\n            </div>\r\n        </div>\r\n");
			}
			if (x % 2 != 0)
			{
				WriteLiteral("        <div class=\"mx-auto p-2 blogposts\">\r\n            <div class=\"row\" data-aos=\"flip-up\" data-aos-duration=\"1300\" data-aos-once=\"true\">\r\n\r\n                <div class=\"col-sm-12 col-md-12 col-lg-7 col-xl-7 align-items-xxl-center px-2 py-5\">\r\n                    <h2 class=\"mb-4\" style=\"font-family: 'WWFont', serif;\">\r\n                        <strong>\r\n                            <span style=\"color: rgb(239, 108, 0);\">");
				Write(item.Title);
				WriteLiteral("</span>\r\n                        </strong>\r\n                    </h2>\r\n                    <p class=\"mb-4\" style=\"font-size: 18px;font-family: 'WWFont', serif;\">\r\n                        ");
				Write(item.Summary);
				WriteLiteral("\r\n                    </p>\r\n                    <a class=\"ww-btn-light text-white py-3 px-5 text-decoration-none\"");
				BeginWriteAttribute("href", " href=\"", 2788, "\"", 2877, 1);
				WriteAttributeValue("", 2795, Url.Action("BlogPost", "Home", new
				{
					id = item.Id,
					catname = item.CategoryName
				}), 2795, 82, isLiteral: false);
				EndWriteAttribute();
				WriteLiteral(" style=\"border-radius:30px;\">\r\n                        Read More &nbsp;\r\n                        <svg xmlns=\"http://www.w3.org/2000/svg\" width=\"1em\" height=\"1em\" fill=\"currentColor\" viewBox=\"0 0 16 16\" class=\"bi bi-arrow-right\" style=\"font-size: 25px;\">\r\n                            <path fill-rule=\"evenodd\" d=\"M1 8a.5.5 0 0 1 .5-.5h11.793l-3.147-3.146a.5.5 0 0 1 .708-.708l4 4a.5.5 0 0 1 0 .708l-4 4a.5.5 0 0 1-.708-.708L13.293 8.5H1.5A.5.5 0 0 1 1 8\"></path>\r\n                        </svg>\r\n                    </a>\r\n                </div>\r\n                <div class=\"col-sm-12 col-md-12 col-lg-5 col-xl-5 p-3\">\r\n                    <img");
				BeginWriteAttribute("src", " src=\"", 3520, "\"", 3558, 1);
				WriteAttributeValue("", 3526, Url.Content(item.FeaturedImage), 3526, 32, isLiteral: false);
				EndWriteAttribute();
				WriteLiteral(" width=\"100%\" style=\"box-shadow: -9px 9px var(--bs-orange);border-top-left-radius: 30px;border-top-right-radius: 30px;border-bottom-right-radius: 30px;border-bottom-left-radius: 30px;\">\r\n                </div>\r\n            </div>\r\n        </div>\r\n");
			}
			x++;
		}
		WriteLiteral(" ");
	}
}
