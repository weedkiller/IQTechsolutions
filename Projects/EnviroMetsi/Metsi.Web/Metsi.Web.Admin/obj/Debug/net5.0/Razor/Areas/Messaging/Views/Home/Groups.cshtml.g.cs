#pragma checksum "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Messaging\Views\Home\Groups.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bba6c2e062edaa1cfbc46dfbb0cb53408c89ba1e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Messaging_Views_Home_Groups), @"mvc.1.0.view", @"/Areas/Messaging/Views/Home/Groups.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Messaging\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Messaging\Views\_ViewImports.cshtml"
using Iqt.Messaging.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Messaging\Views\Home\Groups.cshtml"
using Filing.Base.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Messaging\Views\Home\Groups.cshtml"
using Filing.Base.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Messaging\Views\Home\Groups.cshtml"
using Iqt.Base.Interfaces;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bba6c2e062edaa1cfbc46dfbb0cb53408c89ba1e", @"/Areas/Messaging/Views/Home/Groups.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e30ebfb7ea05562b8245fb8ebf4eefc8df9f10f1", @"/Areas/Messaging/Views/_ViewImports.cshtml")]
    public class Areas_Messaging_Views_Home_Groups : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Messaging.Base.Entities.Chat>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Profile", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("color: aliceblue"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Chats", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "JoinChat", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 8 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Messaging\Views\Home\Groups.cshtml"
  
    ViewData["Title"] = "Chat Groups";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <div id=\"page-content\">\r\n\r\n");
#nullable restore
#line 14 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Messaging\Views\Home\Groups.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div class=""row"">
                <div class=""col-lg-12"">
					
                    <!--Profile Heading-->
                    <!--===================================================-->
                    <div class=""panel"">
                        <div class=""panel-bg-cover"">
                            <img class=""img-responsive""");
            BeginWriteAttribute("src", " src=\"", 670, "\"", 690, 1);
#nullable restore
#line 23 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Messaging\Views\Home\Groups.cshtml"
WriteAttributeValue("", 676, item.ImageUrl, 676, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Image\">\r\n                        </div>\r\n                        <div class=\"panel-media\">\r\n                            <img");
            BeginWriteAttribute("src", " src=\"", 821, "\"", 841, 1);
#nullable restore
#line 26 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Messaging\Views\Home\Groups.cshtml"
WriteAttributeValue("", 827, item.ImageUrl, 827, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"panel-media-img img-circle img-border-light\" alt=\"Profile Picture\">\r\n                            <div class=\"row\">\r\n                                <div class=\"col-lg-7\">\r\n                                    <h3 class=\"panel-media-heading\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bba6c2e062edaa1cfbc46dfbb0cb53408c89ba1e9023", async() => {
#nullable restore
#line 29 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Messaging\Views\Home\Groups.cshtml"
                                                                                                                                                                                                Write(item.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 29 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Messaging\Views\Home\Groups.cshtml"
                                                                                                                                     WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</h3>\r\n                                    <p class=\"text-muted mar-btm\">");
#nullable restore
#line 30 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Messaging\Views\Home\Groups.cshtml"
                                                             Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                </div>\r\n                                <div class=\"col-lg-5 text-lg-right\">\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bba6c2e062edaa1cfbc46dfbb0cb53408c89ba1e12870", async() => {
                WriteLiteral("Join Chat Group");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Area = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 33 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Messaging\Views\Home\Groups.cshtml"
                                                                                                                                   WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                </div>
                            </div>
                        </div>
                        <div class=""panel-body"">
                            <h4>Users connected to this group</h4>
                            
                            <div class=""row"">
");
#nullable restore
#line 41 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Messaging\Views\Home\Groups.cshtml"
                                 foreach (var user in item.Users)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div class=\"col-sm-2\">\r\n                                    <img alt=\"Avatar\" style=\"width: 50px; height: 50px;\" class=\"img-lg img-circle img-border mar-btm\"");
            BeginWriteAttribute("src", " src=\"", 2213, "\"", 2298, 1);
#nullable restore
#line 44 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Messaging\Views\Home\Groups.cshtml"
WriteAttributeValue("", 2219, user.User.GetPath(Configuration.BaseImageUrl, ImageType.Cover, "/img/av1.png"), 2219, 79, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    <h5 class=\"mar-no\">");
#nullable restore
#line 45 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Messaging\Views\Home\Groups.cshtml"
                                                  Write(user.User.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 45 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Messaging\Views\Home\Groups.cshtml"
                                                                       Write(user.User.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                                    <p>");
#nullable restore
#line 46 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Messaging\Views\Home\Groups.cshtml"
                                  Write(user.User);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n                                    <p><small>");
#nullable restore
#line 47 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Messaging\Views\Home\Groups.cshtml"
                                         Write(user.User.EmailAddresses.FirstOrDefault(c => c.Default));

#line default
#line hidden
#nullable disable
            WriteLiteral("</small></p>\r\n                                </div>\r\n");
#nullable restore
#line 49 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Messaging\Views\Home\Groups.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </div>\r\n                        </div>\r\n                    </div>\r\n                    <!--===================================================-->\r\n\t\t\t\t\t\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 57 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Messaging\Views\Home\Groups.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IApplicationConfiguration Configuration { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Messaging.Base.Entities.Chat>> Html { get; private set; }
    }
}
#pragma warning restore 1591
