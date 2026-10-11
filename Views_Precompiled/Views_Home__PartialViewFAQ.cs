using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Hosting;
using WallyWombatsPublic_MVC.Models;

namespace AspNetCoreGeneratedDocument;

[RazorCompiledItemMetadata("Identifier", "/Views/Home/_PartialViewFAQ.cshtml")]
[CreateNewOnMetadataUpdate]
internal sealed class Views_Home__PartialViewFAQ : RazorPage<HomeModel>
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
	public IHtmlHelper<HomeModel> Html { get; private set; }

	public override async Task ExecuteAsync()
	{
		WriteLiteral("\r\n<div id=\"myFaq\" class=\"faq-popup pt-4 pb-3 pe-2 ps-2\" style=\"background: linear-gradient(rgb(159,221,246), rgb(137,214,240));\">\r\n    <div class=\"container\">\r\n        <div class=\"row mb-3\">\r\n            <h3 class=\"fw-bold px-3 white-stroke\" style=\"font-family: 'WWFont', serif;color: #ef6c00;\">Frequently Ask Questions</h3>\r\n            <p class=\"px-3 fw-bold\" style=\"font-family: 'WWFont', serif;font-size: 16px;color: var(--bs-body-color);\">\r\n                Curious about something? Our FAQ page has the answers\u00a0you\u00a0need.\r\n            </p>\r\n        </div>\r\n    </div>\r\n    <div class=\"mb-3 p-1\" style=\"overflow: auto;height: 300px;\">\r\n        <div class=\"mb-3 p-1\">\r\n            <div >\r\n                <h4 class=\"fw-bold px-3 white-stroke\" style=\"font-family: 'WWFont', serif;color: #ef6c00;\">General Admission</h4>\r\n            </div>\r\n            <div class=\"accordion\" role=\"tablist\" id=\"accordion-general\">\r\n");
		foreach (var item in Model.FAQViewModel.Select((FAQ value, int index) => new { value, index }))
		{
			if (item.value.Category == "GeneralAdmission")
			{
				string id = "general-item-" + item.index;
				WriteLiteral("                        <div class=\"accordion-item\" data-aos=\"flip-up\" data-aos-duration=\"1000\" data-aos-once=\"true\">\r\n                            <h4 class=\"accordion-header\" role=\"tab\">\r\n                                <button class=\"accordion-button collapsed\" type=\"button\"\r\n                                        data-bs-toggle=\"collapse\" data-bs-target=\"#");
				Write(id);
				WriteLiteral("\" aria-expanded=\"false\"");
				BeginWriteAttribute("aria-controls", "\r\n                                        aria-controls=\"", 1672, "\"", 1732, 1);
				WriteAttributeValue("", 1729, id, 1729, 3, isLiteral: false);
				EndWriteAttribute();
				WriteLiteral(" style=\"font-family: 'WWFont', serif;\">\r\n                                    ");
				Write(item.value.Question);
				WriteLiteral("\r\n                                </button>\r\n                            </h4>\r\n                            <div");
				BeginWriteAttribute("id", " id=\"", 1942, "\"", 1950, 1);
				WriteAttributeValue("", 1947, id, 1947, 3, isLiteral: false);
				EndWriteAttribute();
				WriteLiteral(" class=\"accordion-collapse collapse item-1\" role=\"tabpanel\" data-bs-parent=\"#accordion-general\">\r\n                                <div class=\"accordion-body\">\r\n                                    <p class=\"mb-0\" style=\"font-family: 'WWFont', serif;\">\r\n                                        ");
				Write(Html.Raw(item.value.Answer));
				WriteLiteral("\r\n                                    </p>\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n");
			}
		}
		WriteLiteral("            </div>\r\n        </div>\r\n        <div class=\"mb-3 p-1\">\r\n            <div >\r\n                <h4 class=\"fw-bold px-3 white-stroke\" style=\"font-family: 'WWFont', serif;color: #ef6c00;\">Party And Events</h4>\r\n            </div>\r\n            <div class=\"accordion\" role=\"tablist\" id=\"accordion-party\">\r\n");
		foreach (var item2 in Model.FAQViewModel.Select((FAQ value, int index) => new { value, index }))
		{
			if (item2.value.Category == "PartyAndEvents")
			{
				string id2 = "party-item-" + item2.index;
				WriteLiteral("                        <div class=\"accordion-item\" data-aos=\"flip-up\" data-aos-duration=\"1000\" data-aos-once=\"true\">\r\n                            <h4 class=\"accordion-header\" role=\"tab\">\r\n                                <button class=\"accordion-button collapsed\" type=\"button\"\r\n                                        data-bs-toggle=\"collapse\" data-bs-target=\"#");
				Write(id2);
				WriteLiteral("\" aria-expanded=\"false\"");
				BeginWriteAttribute("aria-controls", "\r\n                                        aria-controls=\"", 3479, "\"", 3539, 1);
				WriteAttributeValue("", 3536, id2, 3536, 3, isLiteral: false);
				EndWriteAttribute();
				WriteLiteral(" style=\"font-family: 'WWFont', serif;\">\r\n                                    ");
				Write(item2.value.Question);
				WriteLiteral("\r\n                                </button>\r\n                            </h4>\r\n                            <div");
				BeginWriteAttribute("id", " id=\"", 3749, "\"", 3757, 1);
				WriteAttributeValue("", 3754, id2, 3754, 3, isLiteral: false);
				EndWriteAttribute();
				WriteLiteral(" class=\"accordion-collapse collapse item-1\" role=\"tabpanel\" data-bs-parent=\"#accordion-party\">\r\n                                <div class=\"accordion-body\">\r\n                                    <p class=\"mb-0\" style=\"font-family: 'WWFont', serif;\">\r\n                                        ");
				Write(Html.Raw(item2.value.Answer));
				WriteLiteral("\r\n                                    </p>\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n");
			}
		}
		WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n    <div class=\"text-end w-100\">\r\n        <button class=\"btn btn-faq px-5\" type=\"button\" style=\"font-family: 'WWFont', serif;\" onclick=\"closeFaq()\">Close</button>\r\n    </div>\r\n</div>\r\n\r\n");
	}
}
