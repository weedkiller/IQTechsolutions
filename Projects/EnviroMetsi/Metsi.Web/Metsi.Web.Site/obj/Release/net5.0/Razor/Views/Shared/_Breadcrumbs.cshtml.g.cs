#pragma checksum "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Site\Views\Shared\_Breadcrumbs.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a7e22b5feb723931003a59221e45f298665ad3a3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Breadcrumbs), @"mvc.1.0.view", @"/Views/Shared/_Breadcrumbs.cshtml")]
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
#line 1 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Site\Views\_ViewImports.cshtml"
using Metsi.Web.Site;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Site\Views\_ViewImports.cshtml"
using Metsi.Web.Site.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a7e22b5feb723931003a59221e45f298665ad3a3", @"/Views/Shared/_Breadcrumbs.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b952b6b38781916602073809a0504fde726fe5b7", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Breadcrumbs : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<section id=\"breadcrumbs\"");
            BeginWriteAttribute("class", " class=\"", 25, "\"", 33, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n    <div class=\"container\">\r\n        <div class=\"row\">\r\n            <div class=\"col-sm-12\">\r\n                \r\n                <ol class=\"breadcrumb\" style=\"background-color: transparent;\">\r\n                    <li>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a7e22b5feb723931003a59221e45f298665ad3a34424", async() => {
                WriteLiteral("Home");
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
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </li>\r\n");
#nullable restore
#line 10 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Site\Views\Shared\_Breadcrumbs.cshtml"
                     if (ViewContext.RouteData.Values["area"] != null && ViewContext.RouteData.Values["area"].ToString().ToLower() != "")
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li class=\"active\">\r\n                            <a");
            BeginWriteAttribute("href", " href=\"", 608, "\"", 794, 1);
#nullable restore
#line 13 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Site\Views\Shared\_Breadcrumbs.cshtml"
WriteAttributeValue("", 615, Url.Action(ViewContext.RouteData.Values["action"].ToString(), ViewContext.RouteData.Values["controller"].ToString(), new {area = ViewContext.RouteData.Values["area"].ToString()}), 615, 179, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"color_grey_light_3 d_inline_m m_right_10\">");
#nullable restore
#line 13 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Site\Views\Shared\_Breadcrumbs.cshtml"
                                                                                                                                                                                                                                                                      Write(ViewContext.RouteData.Values["area"].ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                        </li>\r\n");
#nullable restore
#line 15 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Site\Views\Shared\_Breadcrumbs.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Site\Views\Shared\_Breadcrumbs.cshtml"
                     if (ViewContext.RouteData.Values["controller"].ToString().ToLower() != "home")
                    {
                        if (ViewContext.RouteData.Values["action"].ToString().ToLower() == "index")
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <li class=\"active\">\r\n                                <a");
            BeginWriteAttribute("href", " href=\"", 1288, "\"", 1370, 1);
#nullable restore
#line 21 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Site\Views\Shared\_Breadcrumbs.cshtml"
WriteAttributeValue("", 1295, Url.Action("Index", ViewContext.RouteData.Values["controller"].ToString()), 1295, 75, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"color_grey_light_3 d_inline_m m_right_10\">");
#nullable restore
#line 21 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Site\Views\Shared\_Breadcrumbs.cshtml"
                                                                                                                                                                  Write(ViewContext.RouteData.Values["controller"].ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                <i class=\"icon-angle-right d_inline_m color_grey_light_3 fs_small\"></i>\r\n                            </li>\r\n");
#nullable restore
#line 24 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Site\Views\Shared\_Breadcrumbs.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <li>\r\n                                <a");
            BeginWriteAttribute("href", " href=\"", 1773, "\"", 1855, 1);
#nullable restore
#line 28 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Site\Views\Shared\_Breadcrumbs.cshtml"
WriteAttributeValue("", 1780, Url.Action("Index", ViewContext.RouteData.Values["controller"].ToString()), 1780, 75, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"color_grey_light_3 d_inline_m m_right_10\">");
#nullable restore
#line 28 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Site\Views\Shared\_Breadcrumbs.cshtml"
                                                                                                                                                                  Write(ViewContext.RouteData.Values["controller"].ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                <i class=\"icon-angle-right d_inline_m color_grey_light_3 fs_small\"></i>\r\n                            </li>\r\n");
#nullable restore
#line 31 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Site\Views\Shared\_Breadcrumbs.cshtml"
                        }

                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li class=\"active\"><h1>");
#nullable restore
#line 34 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Site\Views\Shared\_Breadcrumbs.cshtml"
                                      Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1></li>\r\n                </ol>\r\n                \r\n                <img alt=\"Enviro Metsi Devider\" width: 100%; height: 100px; src=\"/images/content/Waveline.png\" />\r\n\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
