#pragma checksum "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\_Breadcrumbs.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a31bf2b2c0822349442912a16f2e1382292da008"
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
#line 1 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\_ViewImports.cshtml"
using Metsi.Web.Admin;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\_ViewImports.cshtml"
using Metsi.Web.Admin.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a31bf2b2c0822349442912a16f2e1382292da008", @"/Views/Shared/_Breadcrumbs.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"58acc36c7c6b2cabb3fe2c504456252e879f0d65", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Breadcrumbs : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<ol class=\"breadcrumb pull-right\">\r\n    <li><a");
            BeginWriteAttribute("href", " href=\"", 46, "\"", 81, 1);
#nullable restore
#line 2 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\_Breadcrumbs.cshtml"
WriteAttributeValue("", 53, Url.Action("Index", "Home"), 53, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Home</a></li>\r\n");
#nullable restore
#line 3 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\_Breadcrumbs.cshtml"
     if (ViewContext.RouteData.Values["area"] != null && ViewContext.RouteData.Values["area"].ToString().ToLower() != "")
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li>\r\n            <a");
            BeginWriteAttribute("href", " href=\"", 256, "\"", 442, 1);
#nullable restore
#line 6 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\_Breadcrumbs.cshtml"
WriteAttributeValue("", 263, Url.Action(ViewContext.RouteData.Values["action"].ToString(), ViewContext.RouteData.Values["controller"].ToString(), new {area = ViewContext.RouteData.Values["area"].ToString()}), 263, 179, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                ");
#nullable restore
#line 7 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\_Breadcrumbs.cshtml"
           Write(ViewContext.RouteData.Values["area"].ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </a>\r\n        </li>\r\n");
#nullable restore
#line 10 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\_Breadcrumbs.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\_Breadcrumbs.cshtml"
     if (ViewContext.RouteData.Values["controller"].ToString().ToLower() != "home")
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li class=\"active\">\r\n            <a");
            BeginWriteAttribute("href", " href=\"", 687, "\"", 769, 1);
#nullable restore
#line 14 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\_Breadcrumbs.cshtml"
WriteAttributeValue("", 694, Url.Action("Index", ViewContext.RouteData.Values["controller"].ToString()), 694, 75, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                ");
#nullable restore
#line 15 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\_Breadcrumbs.cshtml"
           Write(ViewContext.RouteData.Values["controller"].ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </a>\r\n        </li>\r\n");
#nullable restore
#line 18 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\_Breadcrumbs.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\_Breadcrumbs.cshtml"
     if (ViewContext.RouteData.Values["action"].ToString().ToLower() != "index")
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li class=\"active\">\r\n            <a");
            BeginWriteAttribute("href", " href=\"", 1017, "\"", 1141, 1);
#nullable restore
#line 22 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\_Breadcrumbs.cshtml"
WriteAttributeValue("", 1024, Url.Action(ViewContext.RouteData.Values["action"].ToString(), ViewContext.RouteData.Values["controller"].ToString()), 1024, 117, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                ");
#nullable restore
#line 23 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\_Breadcrumbs.cshtml"
           Write(ViewContext.RouteData.Values["action"].ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </a>\r\n        </li>\r\n");
#nullable restore
#line 26 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\_Breadcrumbs.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</ol>\r\n\r\n<h1 class=\"page-header\">");
#nullable restore
#line 29 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\_Breadcrumbs.cshtml"
                   Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <small>");
#nullable restore
#line 29 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\_Breadcrumbs.cshtml"
                                             Write(ViewData["SubTitle"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</small></h1>");
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
