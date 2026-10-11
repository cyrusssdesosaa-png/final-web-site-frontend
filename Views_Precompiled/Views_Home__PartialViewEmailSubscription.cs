using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Hosting;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AspNetCoreGeneratedDocument;

[RazorCompiledItemMetadata("Identifier", "/Views/Home/_PartialViewEmailSubscription.cshtml")]
[CreateNewOnMetadataUpdate]
internal sealed class Views_Home__PartialViewEmailSubscription : RazorPage<dynamic>
{
	private static readonly TagHelperAttribute __tagHelperAttribute_0 = new TagHelperAttribute("method", "post", HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_1 = new TagHelperAttribute("action", new HtmlString("/subscribe"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_2 = new TagHelperAttribute("id", new HtmlString("FormSubscribe"), HtmlAttributeValueStyle.DoubleQuotes);

	private TagHelperExecutionContext __tagHelperExecutionContext;

	private TagHelperRunner __tagHelperRunner = new TagHelperRunner();

	private string __tagHelperStringValueBuffer;

	private TagHelperScopeManager __backed__tagHelperScopeManager;

	private FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;

	private RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;

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
		WriteLiteral("\r\n\r\n<div class=\"row g-0 d-xxl-flex justify-content-center justify-content-sm-center justify-content-md-center justify-content-lg-center justify-content-xl-center justify-content-xxl-center\">\r\n    <div class=\"col-12 col-lg-10 col-xl-9 col-xxl-8\" data-aos=\"zoom-in-up\" data-aos-duration=\"1000\" data-aos-once=\"true\">\r\n        <div class=\"mx-auto popup-div text-center mt-5 email-sub\" style=\"border-color:#fff\">\r\n            <h3 class=\"text-center mb-3 mt-0  white-stroke\" style=\"color: rgb(239, 108, 0);font-size: 35px;font-weight: bold;\">\r\n                Subscribe to our mailing list to keep informed on upcoming special events.\r\n            </h3>\r\n            ");
		__tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", TagMode.StartTagAndEndTag, "f4b8896390e5db8dc1529ee96a79de984d99dd68f4e54fe6bbab0820e54c42935177", async () =>
		{
			WriteLiteral("\r\n                <div class=\"row d-lg-flex d-xl-flex d-xxl-flex justify-content-lg-center justify-content-xl-center justify-content-xxl-center mb-1\">\r\n                    <div class=\"col-sm-12 col-md-12 col-lg-10 col-xl-10 col-xxl-8 text-start\">\r\n                        <label class=\"form-label text-start mb-0 email-sub-font\">\r\n                            Email Address*\r\n                        </label>\r\n                        <input class=\"form-control email-sub-font email\" type=\"email\" name=\"email\" required>\r\n                    </div>\r\n                </div>\r\n                <div class=\"row d-lg-flex d-xl-flex d-xxl-flex justify-content-lg-center justify-content-xl-center justify-content-xxl-center mb-1\">\r\n                    <div class=\"col-sm-6 col-md-6 col-lg-5 col-xl-5 col-xxl-4 text-start\">\r\n                        <label class=\"form-label mb-0 email-sub-font\">\r\n                            First Name *\r\n                        </label>\r\n                        <input class=\"form-control email-sub-fo");
			WriteLiteral("nt text\" type=\"text\" name=\"firstname\" required>\r\n                    </div>\r\n                    <div class=\"col-sm-6 col-md-6 col-lg-5 col-xl-5 col-xxl-4 text-start\">\r\n                        <label class=\"form-label mb-0 email-sub-font\">\r\n                            Last Name *\r\n                        </label><input class=\"form-control email-sub-font text\" type=\"text\" name=\"lastname\" required>\r\n                    </div>\r\n                </div>\r\n\r\n                <div class=\"row d-lg-flex d-xl-flex d-xxl-flex justify-content-lg-center justify-content-xl-center justify-content-xxl-center\">\r\n                    <div class=\"col-sm-12 col-md-12 col-lg-10 col-xl-10 col-xxl-8 col-8 mt-3\">\r\n                        <button class=\"btn border rounded-pill w-100 ww-btn-light\" type=\"submit\">Subscribe</button>\r\n                    </div>\r\n                </div>\r\n            ");
		});
		__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<FormTagHelper>();
		__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
		__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<RenderAtEndOfFormTagHelper>();
		__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
		__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
		__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
		await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
		if (!__tagHelperExecutionContext.Output.IsContentModified)
		{
			await __tagHelperExecutionContext.SetOutputContentAsync();
		}
		Write(__tagHelperExecutionContext.Output);
		__tagHelperExecutionContext = __tagHelperScopeManager.End();
		WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n<script>\r\n    document.getElementById('FormSubscribe').addEventListener('submit', function(e) {\r\n      e.preventDefault(); // Prevent default submission\r\n\r\n      Swal.fire({\r\n        title: 'Are you sure?',\r\n        text: \"Do you want to submit your subscription?\",\r\n        icon: 'question',\r\n        showCancelButton: true,\r\n        confirmButtonText: 'Yes, subscribe!',\r\n        cancelButtonText: 'Cancel'\r\n\r\n      }).then((result) => {\r\n        if (result.isConfirmed) {\r\n          // Submit the form manually if confirmed\r\n         \r\n           setTimeout(() => {\r\n          Swal.fire({\r\n            title: 'Success!',\r\n            text: 'Your subscription has been submitted.',\r\n            icon: 'success',\r\n            confirmButtonText: 'OK'\r\n          });\r\n\r\n          e.target.submit();\r\n          //Optionally reset form\r\n          //e.target.reset();\r\n        }, 500);\r\n        }\r\n      });\r\n    });\r\n</script>");
	}
}
