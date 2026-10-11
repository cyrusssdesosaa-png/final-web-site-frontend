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

[RazorCompiledItemMetadata("Identifier", "/Views/Home/Privacy.cshtml")]
[CreateNewOnMetadataUpdate]
internal sealed class Views_Home_Privacy : RazorPage<dynamic>
{
	private static readonly TagHelperAttribute __tagHelperAttribute_0 = new TagHelperAttribute("type", new HtmlString("video/mp4"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_1 = new TagHelperAttribute("src", new HtmlString("~/img/hero/ww-video.mp4"), HtmlAttributeValueStyle.DoubleQuotes);

	private static readonly TagHelperAttribute __tagHelperAttribute_2 = new TagHelperAttribute("src", new HtmlString("~/img/misc/ww-privacy.png"), HtmlAttributeValueStyle.DoubleQuotes);

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
	public IHtmlHelper<dynamic> Html { get; private set; }

	public override async Task ExecuteAsync()
	{
		ViewData["Title"] = "Privacy Policy";
		WriteLiteral("\r\n<div class=\"video-container\">\r\n    <video autoplay muted loop>\r\n        ");
		__tagHelperExecutionContext = __tagHelperScopeManager.Begin("source", TagMode.SelfClosing, "3516d8f99228c58ba2062e2ebd22ec6f3744bead9417fb5f15fdb2c94a36ceb97853", async () =>
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
		__tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", TagMode.SelfClosing, "3516d8f99228c58ba2062e2ebd22ec6f3744bead9417fb5f15fdb2c94a36ceb99055", async () =>
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
		__tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", TagMode.StartTagOnly, "3516d8f99228c58ba2062e2ebd22ec6f3744bead9417fb5f15fdb2c94a36ceb910498", async () =>
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
		__tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", TagMode.StartTagOnly, "3516d8f99228c58ba2062e2ebd22ec6f3744bead9417fb5f15fdb2c94a36ceb911942", async () =>
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
		WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n<div class=\"privacy-policy\">\r\n    <div class=\"container\" style=\"margin: 3rem auto;\">\r\n        <h1>Privacy Policy</h1>\r\n        <p>Last updated: February 15, 2023</p>\r\n        <p>This Privacy Policy describes Our policies and procedures on the collection, use and disclosure of Your information when You use the Service and tells You about Your privacy rights and how the law protects You.</p>\r\n        <p>\r\n            We use Your Personal data to provide and improve the Service. By using the Service, You agree to the collection and use of information in accordance with this Privacy Policy. This Privacy Policy has been created with the help of the\r\n            <a href=\"https://www.freeprivacypolicy.com/free-privacy-policy-generator/\" target=\"_blank\" rel=\"noreferrer\">Free Privacy Policy Generator</a>.\r\n        </p>\r\n        <h2>Interpretation and Definitions</h2>\r\n        <h3>Interpretation</h3>\r\n        <p>The words of which the initial letter is capitalized have meanings defined under the");
		WriteLiteral(" following conditions. The following definitions shall have the same meaning regardless of whether they appear in singular or in plural.</p>\r\n        <h2>Definitions</h2>\r\n        <p>For the purposes of this Privacy Policy:</p>\r\n        <ul>\r\n            <li>\r\n                <p><strong>Account</strong> means a unique account created for You to access our Service or parts of our Service.</p>\r\n            </li>\r\n            <li>\r\n                <p><strong>Affiliate</strong> means an entity that controls, is controlled by or is under common control with a party, where \"control\" means ownership of 50% or more of the shares, equity interest or other securities entitled to vote for election of directors or other managing authority.</p>\r\n            </li>\r\n            <li><p><strong>Company</strong> (referred to as either \"the Company\", \"We\", \"Us\" or \"Our\" in this Agreement) refers to Wally Wombats, 3165 N. Rainbow Boulevard Las Vegas, NV 89108.</p></li>\r\n            <li><p><strong>Cookies</strong> are small files");
		WriteLiteral(" that are placed on Your computer, mobile device or any other device by a website, containing the details of Your browsing history on that website among its many uses.</p></li>\r\n            <li><p><strong>Country</strong> refers to: Nevada, United States</p></li>\r\n            <li><p><strong>Device</strong> means any device that can access the Service such as a computer, a cellphone or a digital tablet.</p></li>\r\n            <li><p><strong>Personal Data</strong> is any information that relates to an identified or identifiable individual.</p></li>\r\n            <li><p><strong>Service</strong> refers to the Website.</p></li>\r\n            <li>\r\n                <p><strong>Service Provider</strong> means any natural or legal person who processes the data on behalf of the Company. It refers to third-party companies or individuals employed by the Company to facilitate the Service, to provide the Service on behalf of the Company, to perform services related to the Service or to assist the Company in analyzing how the S");
		WriteLiteral("ervice is used.</p>\r\n            </li>\r\n            <li><p><strong>Third-party Social Media Service</strong> refers to any website or any social network website through which a User can log in or create an account to use the Service.</p></li>\r\n            <li><p><strong>Usage Data</strong> refers to data collected automatically, either generated by the use of the Service or from the Service infrastructure itself (for example, the duration of a page visit).</p></li>\r\n            <li><p><strong>Website</strong> refers to Wally Wombats, accessible from <a href=\"http://www.wallywombats.com\" rel=\"external nofollow noopener noreferrer\" target=\"_blank\">http://www.wallywombats.com</a></p></li>\r\n            <li><p><strong>You</strong> means the individual accessing or using the Service, or the company, or other legal entity on behalf of which such individual is accessing or using the Service, as applicable.</p></li>\r\n        </ul>\r\n        <h2>Collecting and Using Your Personal Data</h2>\r\n        <h3>Types of Data Col");
		WriteLiteral("lected</h3>\r\n        <h4>Personal Data</h4>\r\n        <p>While using Our Service, We may ask You to provide Us with certain personally identifiable information that can be used to contact or identify You. Personally identifiable information may include, but is not limited to:</p>\r\n        <ul>\r\n            <li><p>Email address</p></li>\r\n            <li><p>First name and last name</p></li>\r\n            <li><p>Phone number</p></li>\r\n            <li><p>Address, State, Province, ZIP/Postal code, City</p></li>\r\n            <li><p>Usage Data</p></li>\r\n        </ul>\r\n        <h4>Usage Data</h4>\r\n        <p>Usage Data is collected automatically when using the Service.</p>\r\n        <p>Usage Data may include information such as Your Device's Internet Protocol address (e.g. IP address), browser type, browser version, the pages of our Service that You visit, the time and date of Your visit, the time spent on those pages, unique device identifiers and other diagnostic data.</p>\r\n        <p>When You access the Service by or");
		WriteLiteral(" through a mobile device, We may collect certain information automatically, including, but not limited to, the type of mobile device You use, Your mobile device unique ID, the IP address of Your mobile device, Your mobile operating system, the type of mobile Internet browser You use, unique device identifiers and other diagnostic data.</p>\r\n        <p>We may also collect information that Your browser sends whenever You visit our Service or when You access the Service by or through a mobile device.</p>\r\n        <h4>Information from Third-Party Social Media Services</h4>\r\n        <p>The Company allows You to create an account and log in to use the Service through the following Third-party Social Media Services:</p>\r\n        <ul>\r\n            <li><p>Google</p></li>\r\n            <li><p>Facebook</p></li>\r\n            <li><p>Twitter</p></li>\r\n            <li><p>LinkedIn</p></li>\r\n        </ul>\r\n        <p>If You decide to register through or otherwise grant us access to a Third-Party Social Media Service, We may co");
		WriteLiteral("llect Personal data that is already associated with Your Third-Party Social Media Service's account, such as Your name, Your email address, Your activities or Your contact list associated with that account.</p>\r\n        <p>You may also have the option of sharing additional information with the Company through Your Third-Party Social Media Service's account. If You choose to provide such information and Personal Data, during registration or otherwise, You are giving the Company permission to use, share, and store it in a manner consistent with this Privacy Policy.</p>\r\n        <h4>Tracking Technologies and Cookies</h4>\r\n        <p>We use Cookies and similar tracking technologies to track the activity on Our Service and store certain information. Tracking technologies used are beacons, tags, and scripts to collect and track information and to improve and analyze Our Service. The technologies We use may include:</p>\r\n        <ul>\r\n            <li><p><strong>Cookies or Browser Cookies.</strong> A cookie is a smal");
		WriteLiteral("l file placed on Your Device. You can instruct Your browser to refuse all Cookies or to indicate when a Cookie is being sent. However, if You do not accept Cookies, You may not be able to use some parts of our Service. Unless you have adjusted Your browser setting so that it will refuse Cookies, our Service may use Cookies.</p></li>\r\n            <li><p><strong>Web Beacons.</strong> Certain sections of our Service and our emails may contain small electronic files known as web beacons (also referred to as clear gifs, pixel tags, and single-pixel gifs) that permit the Company, for example, to count users who have visited those pages or opened an email and for other related website statistics (for example, recording the popularity of a certain section and verifying system and server integrity).</p></li>\r\n        </ul>\r\n        <p>Cookies can be \"Persistent\" or \"Session\" Cookies. Persistent Cookies remain on Your personal computer or mobile device when You go offline, while Session Cookies are deleted as soon as Y");
		WriteLiteral("ou close Your web browser. Learn more about cookies on the <a href=\"https://www.freeprivacypolicy.com/blog/sample-privacy-policy-template/#Use_Of_Cookies_And_Tracking\" target=\"_blank\" rel=\"noreferrer\">Free Privacy Policy website</a> article.</p>\r\n        <p>We use both Session and Persistent Cookies for the purposes set out below:</p>\r\n        <ul>\r\n            <li>\r\n                <p><strong>Necessary / Essential Cookies</strong></p>\r\n                <p>Type: Session Cookies</p><p>Administered by: Us</p>\r\n                <p>Purpose: These Cookies are essential to provide You with services available through the Website and to enable You to use some of its features. They help to authenticate users and prevent fraudulent use of user accounts. Without these Cookies, the services that You have asked for cannot be provided, and We only use these Cookies to provide You with those services.</p>\r\n            </li>\r\n            <li>\r\n                <p><strong>Cookies Policy / Notice Acceptance Cookies</strong></p><p");
		WriteLiteral(">Type: Persistent Cookies</p><p>Administered by: Us</p><p>Purpose: These Cookies identify if users have accepted the use of cookies on the Website.</p>\r\n            </li>\r\n            <li><p><strong>Functionality Cookies</strong></p><p>Type: Persistent Cookies</p><p>Administered by: Us</p><p>Purpose: These Cookies allow us to remember choices You make when You use the Website, such as remembering your login details or language preference. The purpose of these Cookies is to provide You with a more personal experience and to avoid You having to re-enter your preferences every time You use the Website.</p></li>\r\n        </ul>\r\n        <p>For more information about the cookies we use and your choices regarding cookies, please visit our Cookies Policy or the Cookies section of our Privacy Policy.</p>\r\n        <h2>Use of Your Personal Data</h2>\r\n        <p>The Company may use Personal Data for the following purposes:</p>\r\n        <ul>\r\n            <li><p><strong>To provide and maintain our Service</strong>, includi");
		WriteLiteral("ng to monitor the usage of our Service.</p></li>\r\n            <li><p><strong>To manage Your Account:</strong> to manage Your registration as a user of the Service. The Personal Data You provide can give You access to different functionalities of the Service that are available to You as a registered user.</p></li>\r\n            <li><p><strong>For the performance of a contract:</strong> the development, compliance and undertaking of the purchase contract for the products, items or services You have purchased or of any other contract with Us through the Service.</p></li>\r\n            <li><p><strong>To contact You:</strong> To contact You by email, telephone calls, SMS, or other equivalent forms of electronic communication, such as a mobile application's push notifications regarding updates or informative communications related to the functionalities, products or contracted services, including the security updates, when necessary or reasonable for their implementation.</p></li>\r\n            <li><p><strong>To provi");
		WriteLiteral("de You</strong> with news, special offers and general information about other goods, services and events which we offer that are similar to those that you have already purchased or enquired about unless You have opted not to receive such information.</p></li>\r\n            <li><p><strong>To manage Your requests:</strong> To attend and manage Your requests to Us.</p></li>\r\n            <li><p><strong>For business transfers:</strong> We may use Your information to evaluate or conduct a merger, divestiture, restructuring, reorganization, dissolution, or other sale or transfer of some or all of Our assets, whether as a going concern or as part of bankruptcy, liquidation, or similar proceeding, in which Personal Data held by Us about our Service users is among the assets transferred.</p></li>\r\n            <li><p><strong>For other purposes</strong>: We may use Your information for other purposes, such as data analysis, identifying usage trends, determining the effectiveness of our promotional campaigns and to evaluat");
		WriteLiteral("e and improve our Service, products, services, marketing and your experience.</p></li>\r\n        </ul>\r\n        <p>We may share Your personal information in the following situations:</p>\r\n        <ul>\r\n            <li><p><strong>With Service Providers:</strong> We may share Your personal information with Service Providers to monitor and analyze the use of our Service, to contact You.</p></li>\r\n            <li><p><strong>For business transfers:</strong> We may share or transfer Your personal information in connection with, or during negotiations of, any merger, sale of Company assets, financing, or acquisition of all or a portion of Our business to another company.</p></li>\r\n            <li><p><strong>With Affiliates:</strong> We may share Your information with Our affiliates, in which case we will require those affiliates to honor this Privacy Policy. Affiliates include Our parent company and any other subsidiaries, joint venture partners or other companies that We control or that are under common control with");
		WriteLiteral(" Us.</p></li>\r\n            <li><p><strong>With business partners:</strong> We may share Your information with Our business partners to offer You certain products, services or promotions.</p></li>\r\n            <li><p><strong>With other users:</strong> when You share personal information or otherwise interact in the public areas with other users, such information may be viewed by all users and may be publicly distributed outside. If You interact with other users or register through a Third-Party Social Media Service, Your contacts on the Third-Party Social Media Service may see Your name, profile, pictures and description of Your activity. Similarly, other users will be able to view descriptions of Your activity, communicate with You and view Your profile.</p></li>\r\n            <li><p><strong>With Your consent</strong>: We may disclose Your personal information for any other purpose with Your consent.</p></li>\r\n        </ul>\r\n        <h2>Retention of Your Personal Data</h2>\r\n        <p>The Company will retain Y");
		WriteLiteral("our Personal Data only for as long as is necessary for the purposes set out in this Privacy Policy. We will retain and use Your Personal Data to the extent necessary to comply with our legal obligations (for example, if we are required to retain your data to comply with applicable laws), resolve disputes, and enforce our legal agreements and policies.</p>\r\n        <p>The Company will also retain Usage Data for internal analysis purposes. Usage Data is generally retained for a shorter period of time, except when this data is used to strengthen the security or to improve the functionality of Our Service, or We are legally obligated to retain this data for longer time periods.</p>\r\n        <h2>Transfer of Your Personal Data</h2>\r\n        <p>Your information, including Personal Data, is processed at the Company's operating offices and in any other places where the parties involved in the processing are located. It means that this information may be transferred to — and maintained on — computers located outside of");
		WriteLiteral(" Your state, province, country or other governmental jurisdiction where the data protection laws may differ than those from Your jurisdiction.</p>\r\n        <p>Your consent to this Privacy Policy followed by Your submission of such information represents Your agreement to that transfer.</p>\r\n        <p>The Company will take all steps reasonably necessary to ensure that Your data is treated securely and in accordance with this Privacy Policy and no transfer of Your Personal Data will take place to an organization or a country unless there are adequate controls in place including the security of Your data and other personal information.</p>\r\n        <h2>Delete Your Personal Data</h2>\r\n        <p>You have the right to delete or request that We assist in deleting the Personal Data that We have collected about You.</p>\r\n        <p>Our Service may give You the ability to delete certain information about You from within the Service.</p>\r\n        <p>You may update, amend, or delete Your information at any time by sign");
		WriteLiteral("ing in to Your Account, if you have one, and visiting the account settings section that allows you to manage Your personal information. You may also contact Us to request access to, correct, or delete any personal information that You have provided to Us.</p>\r\n        <p>Please note, however, that We may need to retain certain information when we have a legal obligation or lawful basis to do so.</p>\r\n        <h2>Disclosure of Your Personal Data</h2>\r\n        <h3>Business Transactions</h3>\r\n        <p>If the Company is involved in a merger, acquisition or asset sale, Your Personal Data may be transferred. We will provide notice before Your Personal Data is transferred and becomes subject to a different Privacy Policy.</p>\r\n        <h3>Law enforcement</h3>\r\n        <p>Under certain circumstances, the Company may be required to disclose Your Personal Data if required to do so by law or in response to valid requests by public authorities (e.g. a court or a government agency).</p>\r\n        <h3>Other legal requirem");
		WriteLiteral("ents</h3>\r\n        <p>The Company may disclose Your Personal Data in the good faith belief that such action is necessary to:</p>\r\n        <ul>\r\n            <li><p>Comply with a legal obligation</p></li>\r\n            <li><p>Protect and defend the rights or property of the Company</p></li>\r\n            <li><p>Prevent or investigate possible wrongdoing in connection with the Service</p></li>\r\n            <li><p>Protect the personal safety of Users of the Service or the public</p></li>\r\n            <li><p>Protect against legal liability</p></li>\r\n        </ul>\r\n        <h2>Security of Your Personal Data</h2>\r\n        <p>The security of Your Personal Data is important to Us, but remember that no method of transmission over the Internet, or method of electronic storage is 100% secure. While We strive to use commercially acceptable means to protect Your Personal Data, We cannot guarantee its absolute security.</p>\r\n        <h2>Children's Privacy</h2>\r\n        <p>Our Service does not address anyone under the age of 1");
		WriteLiteral("3. We do not knowingly collect personally identifiable information from anyone under the age of 13. If You are a parent or guardian and You are aware that Your child has provided Us with Personal Data, please contact Us. If We become aware that We have collected Personal Data from anyone under the age of 13 without verification of parental consent, We take steps to remove that information from Our servers.</p>\r\n        <p>If We need to rely on consent as a legal basis for processing Your information and Your country requires consent from a parent, We may require Your parent's consent before We collect and use that information.</p>\r\n        <h2>Links to Other Websites</h2>\r\n        <p>Our Service may contain links to other websites that are not operated by Us. If You click on a third party link, You will be directed to that third party's site. We strongly advise You to review the Privacy Policy of every site You visit.</p>\r\n        <p>We have no control over and assume no responsibility for the content, privac");
		WriteLiteral("y policies or practices of any third party sites or services.</p>\r\n        <h2>Changes to this Privacy Policy</h2>\r\n        <p>We may update Our Privacy Policy from time to time. We will notify You of any changes by posting the new Privacy Policy on this page.</p>\r\n        <p>We will let You know via email and/or a prominent notice on Our Service, prior to the change becoming effective and update the \"Last updated\" date at the top of this Privacy Policy.</p>\r\n        <p>You are advised to review this Privacy Policy periodically for any changes. Changes to this Privacy Policy are effective when they are posted on this page.</p>\r\n        <h1>Contact Us</h1>\r\n        <p>If you have any questions about this Privacy Policy, You can contact us:</p>\r\n        <ul>\r\n            <li><p>By phone number: 702-996-5422</p></li>\r\n        </ul>\r\n    </div>\r\n</div>\r\n");
	}
}
