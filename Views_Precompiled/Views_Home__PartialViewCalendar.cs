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

[RazorCompiledItemMetadata("Identifier", "/Views/Home/_PartialViewCalendar.cshtml")]
[CreateNewOnMetadataUpdate]
internal sealed class Views_Home__PartialViewCalendar : RazorPage<HomeModel>
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
		WriteLiteral("\r\n<div class=\"col col-12 mt-5\">\r\n    <div class=\"col col-12 mb-3 text-center\" data-aos=\"fade-up\" data-aos-duration=\"1000\" data-aos-once=\"true\">\r\n        <h4 style=\"color: var(--bs-body-color);\">");
		Write(ViewData["EventDate"]);
		WriteLiteral(" Schedule </h4>\r\n    </div>\r\n    <div class=\"row mt-3 justify-content-center\">\r\n        <div class=\"col col-12 mb-3 text-center\" data-aos=\"fade-up\" data-aos-duration=\"1000\" data-aos-once=\"true\">\r\n            <h4 style=\"color: var(--bs-body-color);\">");
		Write(ViewData["location"]);
		WriteLiteral("</h4>\r\n        </div>\r\n\r\n");
		if (Model.CalendarEventsViewModel.Count() != 0)
		{
			foreach (CalendarEvents item in Model.CalendarEventsViewModel)
			{
				WriteLiteral("                <div class=\"col col-sm-6 col-md-4 mb-3 \" data-aos=\"fade-up\" data-aos-duration=\"1000\" data-aos-once=\"true\">\r\n                    <div class=\"p-4 popup-div h-100\">\r\n                        <h3 class=\"fw-bold\" style=\"font-size: 22px;color: #ef6c00;\">");
				Write(item.EventTitle);
				WriteLiteral("</h3>\r\n                        <ul class=\"list-inline mb-2\">\r\n                            <li class=\"d-xxl-inline-flex align-items-xxl-center list-inline-item\" style=\"color: var(--bs-body-color);font-size: 18px;\">\r\n                                <svg xmlns=\"http://www.w3.org/2000/svg\" width=\"1em\" height=\"1em\" fill=\"currentColor\" viewBox=\"0 0 16 16\" class=\"bi bi-calendar me-2\">\r\n                                    <path d=\"M3.5 0a.5.5 0 0 1 .5.5V1h8V.5a.5.5 0 0 1 1 0V1h1a2 2 0 0 1 2 2v11a2 2 0 0 1-2 2H2a2 2 0 0 1-2-2V3a2 2 0 0 1 2-2h1V.5a.5.5 0 0 1 .5-.5M1 4v10a1 1 0 0 0 1 1h12a1 1 0 0 0 1-1V4z\"></path>\r\n                                </svg>");
				Write(item.EventDate.ToString("dddd"));
				WriteLiteral("\r\n                            </li>\r\n                            <li class=\"d-xxl-inline-flex align-items-xxl-center list-inline-item\" style=\"color: var(--bs-body-color);font-size: 18px;\">\r\n                                <svg xmlns=\"http://www.w3.org/2000/svg\" width=\"1em\" height=\"1em\" fill=\"currentColor\" viewBox=\"0 0 16 16\" class=\"bi bi-clock me-2\">\r\n                                    <path d=\"M8 3.5a.5.5 0 0 0-1 0V9a.5.5 0 0 0 .252.434l3.5 2a.5.5 0 0 0 .496-.868L8 8.71z\"></path>\r\n                                    <path d=\"M8 16A8 8 0 1 0 8 0a8 8 0 0 0 0 16m7-8A7 7 0 1 1 1 8a7 7 0 0 1 14 0\"></path>\r\n                                </svg>");
				Write(item.EventTimeStart);
				WriteLiteral(" - ");
				Write(item.EventTimeEnd);
				WriteLiteral("\r\n                            </li>\r\n                            <li class=\"d-xxl-inline-flex align-items-xxl-center list-inline-item\" style=\"color: var(--bs-body-color);font-size: 18px;\">\r\n                                <svg xmlns=\"http://www.w3.org/2000/svg\" width=\"1em\" height=\"1em\" fill=\"currentColor\" viewBox=\"0 0 16 16\" class=\"bi bi-geo-alt-fill me-2\">\r\n                                    <path d=\"M8 16s6-5.686 6-10A6 6 0 0 0 2 6c0 4.314 6 10 6 10m0-7a3 3 0 1 1 0-6 3 3 0 0 1 0 6\"></path>\r\n                                </svg>");
				Write(item.EventPlace);
				WriteLiteral("\r\n                            </li>\r\n                        </ul>\r\n                    </div>\r\n                </div>\r\n");
			}
		}
		else
		{
			WriteLiteral("            <div class=\"col col-12 mb-3 mx-auto d-block text-center\" data-aos=\"fade-up\" data-aos-duration=\"1000\" data-aos-once=\"true\">\r\n                <h4 style=\"color: var(--bs-body-color);\">No schedule on this date. </h4>\r\n            </div>\r\n");
		}
		WriteLiteral("\r\n\r\n    </div>\r\n</div>\r\n");
	}
}
