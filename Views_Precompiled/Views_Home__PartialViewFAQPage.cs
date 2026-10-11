using System.Collections.Generic;
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

[RazorCompiledItemMetadata("Identifier", "/Views/Home/_PartialViewFAQPage.cshtml")]
[CreateNewOnMetadataUpdate]
internal sealed class Views_Home__PartialViewFAQPage : RazorPage<IEnumerable<FAQ>>
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
	public IHtmlHelper<IEnumerable<FAQ>> Html { get; private set; }

	public override async Task ExecuteAsync()
	{
		WriteLiteral("\r\n<div class=\"container\">\r\n    <div class=\"row mb-5\">\r\n        <div class=\"col-md-8 col-xl-8 text-center mx-auto\">\r\n            <h1 class=\"fw-bold px-3 white-stroke\" style=\"font-family: 'WWFont', serif;color: #ef6c00;\">Frequently Ask Questions</h1>\r\n            <p class=\"px-3 fw-bold\" style=\"font-family: 'WWFont', serif;font-size: 18px;color: var(--bs-body-color);\">\r\n                Curious about something? Our FAQ page has the answers\u00a0you\u00a0need.\r\n            </p>\r\n        </div>\r\n    </div>\r\n\r\n    <div class=\"row\">\r\n        <div class=\"col-md-8 col-xl-8 text-center mx-auto\">\r\n            <h3 class=\"fw-bold px-3 white-stroke\" style=\"font-family: 'WWFont', serif;color: #ef6c00;\">General Admission</h3>\r\n        </div>\r\n    </div>\r\n    <div class=\"mb-3 p-1\">\r\n        <div class=\"accordion\" role=\"tablist\" id=\"accordion-general\">\r\n");
		foreach (var item in Model.Select((FAQ value, int index) => new { value, index }))
		{
			if (item.value.Category == "GeneralAdmission")
			{
				string id = "general-item-" + item.index;
				WriteLiteral("                    <div class=\"accordion-item\" data-aos=\"flip-up\" data-aos-duration=\"1000\" data-aos-once=\"true\">\r\n                        <h2 class=\"accordion-header\" role=\"tab\">\r\n                            <button class=\"accordion-button collapsed\" type=\"button\"\r\n                                    data-bs-toggle=\"collapse\" data-bs-target=\"#");
				Write(id);
				WriteLiteral("\" aria-expanded=\"false\"");
				BeginWriteAttribute("aria-controls", "\r\n                                    aria-controls=\"", 1551, "\"", 1607, 1);
				WriteAttributeValue("", 1604, id, 1604, 3, isLiteral: false);
				EndWriteAttribute();
				WriteLiteral(" style=\"font-family: 'WWFont', serif;\">\r\n                                ");
				Write(item.value.Question);
				WriteLiteral("\r\n                            </button>\r\n                        </h2>\r\n                        <div");
				BeginWriteAttribute("id", " id=\"", 1801, "\"", 1809, 1);
				WriteAttributeValue("", 1806, id, 1806, 3, isLiteral: false);
				EndWriteAttribute();
				WriteLiteral(" class=\"accordion-collapse collapse item-1\" role=\"tabpanel\" data-bs-parent=\"#accordion-general\">\r\n                            <div class=\"accordion-body\">\r\n                                <p class=\"mb-0\" style=\"font-family: 'WWFont', serif;\">\r\n                                   ");
				Write(Html.Raw(item.value.Answer));
				WriteLiteral("\r\n                                </p>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n");
			}
		}
		WriteLiteral("        </div>\r\n    </div>\r\n\r\n    <div class=\"row\">\r\n        <div class=\"col-md-8 col-xl-8 text-center mx-auto\">\r\n            <h3 class=\"fw-bold px-3 white-stroke\" style=\"font-family: 'WWFont', serif;color: #ef6c00;\">Party And Events</h3>\r\n        </div>\r\n    </div>\r\n    <div class=\"mb-3 p-1\">\r\n        <div class=\"accordion\" role=\"tablist\" id=\"accordion-party\">\r\n");
		foreach (var item2 in Model.Select((FAQ value, int index) => new { value, index }))
		{
			if (item2.value.Category == "PartyAndEvents")
			{
				string id2 = "party-item-" + item2.index;
				WriteLiteral("                    <div class=\"accordion-item\" data-aos=\"flip-up\" data-aos-duration=\"1000\" data-aos-once=\"true\">\r\n                        <h2 class=\"accordion-header\" role=\"tab\">\r\n                            <button class=\"accordion-button collapsed\" type=\"button\"\r\n                                    data-bs-toggle=\"collapse\" data-bs-target=\"#");
				Write(id2);
				WriteLiteral("\" aria-expanded=\"false\"");
				BeginWriteAttribute("aria-controls", "\r\n                                    aria-controls=\"", 3306, "\"", 3362, 1);
				WriteAttributeValue("", 3359, id2, 3359, 3, isLiteral: false);
				EndWriteAttribute();
				WriteLiteral(" style=\"font-family: 'WWFont', serif;\">\r\n                                ");
				Write(item2.value.Question);
				WriteLiteral("\r\n                            </button>\r\n                        </h2>\r\n                        <div");
				BeginWriteAttribute("id", " id=\"", 3556, "\"", 3564, 1);
				WriteAttributeValue("", 3561, id2, 3561, 3, isLiteral: false);
				EndWriteAttribute();
				WriteLiteral(" class=\"accordion-collapse collapse item-1\" role=\"tabpanel\" data-bs-parent=\"#accordion-party\">\r\n                            <div class=\"accordion-body\">\r\n                                <p class=\"mb-0\" style=\"font-family: 'WWFont', serif;\">\r\n                                    ");
				Write(Html.Raw(item2.value.Answer));
				WriteLiteral("\r\n                                </p>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n");
			}
		}
		WriteLiteral("        </div>\r\n    </div>\r\n\r\n</div>\r\n\r\n");
		WriteLiteral("\r\n");
	}
}
