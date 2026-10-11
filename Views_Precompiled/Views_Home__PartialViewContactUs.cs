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

[RazorCompiledItemMetadata("Identifier", "/Views/Home/_PartialViewContactUs.cshtml")]
[CreateNewOnMetadataUpdate]
internal sealed class Views_Home__PartialViewContactUs : RazorPage<dynamic>
{
	private static readonly TagHelperAttribute __tagHelperAttribute_0 = new TagHelperAttribute("method", "post", HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_1 = new TagHelperAttribute("asp-action", "SendEmail", HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_2 = new TagHelperAttribute("id", new HtmlString("FormSendEmail"), HtmlAttributeValueStyle.DoubleQuotes);

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
		WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-sm-12 col-lg-6 col-xl-6 col-xxl-6 my-auto p-4\" data-aos=\"zoom-in-right\" data-aos-duration=\"1000\" data-aos-once=\"true\">\r\n        <h1 class=\"fw-bold white-stroke\" style=\"color: #ef6c00; font-size: 45px;\">\r\n            Do you have a question?\r\n        </h1>\r\n        <p class=\"w-lg-50\"\r\n           style=\"font-size: 20px;font-weight: bold;color: var(--bs-body-bg);\">\r\n            <span style=\"color: rgba(30, 28, 25, 0.75);\">\r\n                Give us a call or email us using this form. We're\r\n                always eager to hear from our friends.\r\n            </span>\r\n        </p>\r\n    </div>\r\n    <div class=\"col-sm-12 col-lg-6 col-xl-6 col-xxl-6 \" data-aos=\"zoom-in-left\" data-aos-duration=\"1000\" data-aos-once=\"true\">\r\n        <div class=\"contactus-border popup-div\">\r\n            ");
		__tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", TagMode.StartTagAndEndTag, "a559c3284391545ef13194ec665e09ff45bad5275a552ec59b0e1dc36eaed4645266", async () =>
		{
			WriteLiteral("\r\n                <div class=\"mb-3\">\r\n                    <div class=\"row\">\r\n                        <div class=\"col-12 col-sm-6 mb-2 contactus\">\r\n                            <label class=\"form-label mb-0\" for=\"name\">\r\n                                First Name *\r\n                            </label>\r\n                            <input class=\"form-control\" type=\"text\" id=\"FirstName\"");
			BeginWriteAttribute("required", " required=\"", 1272, "\"", 1283, 0);
			EndWriteAttribute();
			WriteLiteral(" name=\"FirstName\">\r\n                        </div>\r\n                        <div class=\"col-12 col-sm-6 mb-2 contactus\">\r\n                            <label class=\"form-label mb-0\" for=\"name\">\r\n                                Last Name *\r\n                            </label>\r\n                            <input class=\"form-control\" type=\"text\" id=\"LastName\"");
			BeginWriteAttribute("required", " required=\"", 1642, "\"", 1653, 0);
			EndWriteAttribute();
			WriteLiteral(" name=\"LastName\">\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"row\">\r\n                        <div class=\"col-12 col-sm-6 mb-2 contactus\">\r\n                            <label class=\"form-label mb-0\" for=\"name\">\r\n                                Email Address *\r\n                            </label>\r\n                            <input class=\"form-control\" type=\"email\" id=\"EmailAddress\"");
			BeginWriteAttribute("required", " required=\"", 2087, "\"", 2098, 0);
			EndWriteAttribute();
			WriteLiteral(" name=\"EmailAddress\">\r\n                        </div>\r\n                        <div class=\"col-12 col-sm-6 mb-2 contactus\">\r\n                            <label class=\"form-label mb-0\" for=\"name\">\r\n                                Phone Number\r\n                            </label>\r\n                            <input class=\"form-control\" type=\"text\" id=\"PhoneNumber\" name=\"PhoneNumber\">\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"row\">\r\n                        <div class=\"col mb-2 contactus\">\r\n                            <label class=\"form-label mb-0\" for=\"message-2\">\r\n                                Message *\r\n                            </label>\r\n                            <textarea class=\"form-control\" id=\"Message\" name=\"Message\" rows=\"6\"></textarea>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n                <div class=\"mb-3 contactus\">\r\n                    <input type=\"submit\" value=\"Submit\" class=\"border rounded-pill ");
			WriteLiteral("ww-btn-light btn px-5\" />\r\n                </div>\r\n            ");
		});
		__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<FormTagHelper>();
		__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
		__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<RenderAtEndOfFormTagHelper>();
		__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
		__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
		__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
		__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
		__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
		__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
		await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
		if (!__tagHelperExecutionContext.Output.IsContentModified)
		{
			await __tagHelperExecutionContext.SetOutputContentAsync();
		}
		Write(__tagHelperExecutionContext.Output);
		__tagHelperExecutionContext = __tagHelperScopeManager.End();
		WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n");
		WriteLiteral("\r\n<script>\r\n    document.getElementById('FormSendEmail').addEventListener('submit', function(e) {\r\n      e.preventDefault(); // Prevent default submission\r\n\r\n      Swal.fire({\r\n        title: 'Are you sure?',\r\n        text: \"Do you want to submit your question?\",\r\n        icon: 'question',\r\n        showCancelButton: true,\r\n        confirmButtonText: 'Yes',\r\n        cancelButtonText: 'Cancel'\r\n\r\n      }).then((result) => {\r\n        if (result.isConfirmed) {\r\n          // Submit the form manually if confirmed\r\n\r\n           setTimeout(() => {\r\n          Swal.fire({\r\n            title: 'Success!',\r\n            text: 'Email sent successfully!',\r\n            icon: 'success',\r\n            confirmButtonText: 'OK'\r\n          });\r\n\r\n          e.target.submit();\r\n          //Optionally reset form\r\n          //e.target.reset();\r\n        }, 500);\r\n        }\r\n      });\r\n    });\r\n</script>");
	}
}
