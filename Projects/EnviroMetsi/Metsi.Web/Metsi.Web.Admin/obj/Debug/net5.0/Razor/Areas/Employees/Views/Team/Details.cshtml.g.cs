#pragma checksum "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Employees\Views\Team\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b73d059ec4df8aaf9f72c2762718fd84a4bd5d2f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Employees_Views_Team_Details), @"mvc.1.0.view", @"/Areas/Employees/Views/Team/Details.cshtml")]
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
#line 1 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Employees\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Html;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Employees\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Employees\Views\_ViewImports.cshtml"
using Iqt.Base.Interfaces;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Employees\Views\_ViewImports.cshtml"
using Iqt.Base.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Employees\Views\_ViewImports.cshtml"
using Filing.Base.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Employees\Views\_ViewImports.cshtml"
using Filing.Base.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Employees\Views\_ViewImports.cshtml"
using Employment.Base.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Employees\Views\_ViewImports.cshtml"
using Employment.Core.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Employees\Views\_ViewImports.cshtml"
using Iqt.Base.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b73d059ec4df8aaf9f72c2762718fd84a4bd5d2f", @"/Areas/Employees/Views/Team/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5567c7d8e262dcfaa28147fe687e6dc99cbeb6de", @"/Areas/Employees/Views/_ViewImports.cshtml")]
    public class Areas_Employees_Views_Team_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Employee>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Employees\Views\Team\Details.cshtml"
  
    ViewData["Title"] = "Employee Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<section class=\"page-section-ptb\">\r\n    <div class=\"container\">\r\n        <div class=\"row\">\r\n            <div class=\"col-md-4\">\r\n                <img class=\"img-fluid center-block bottom-m3\"");
            BeginWriteAttribute("src", " src=\"", 262, "\"", 312, 1);
#nullable restore
#line 11 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Employees\Views\Team\Details.cshtml"
WriteAttributeValue("", 268, Model.GetImage(ImageType.Profile).GetPath(), 268, 44, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 313, "\"", 319, 0);
            EndWriteAttribute();
            WriteLiteral(@">
            </div>
            <div class=""col-md-8"">
                <div class=""custom-content"">
                    <div class=""clearfix"">
                        <div class=""title pull-left mb-2"">
                            <h4 class=""text-text"">");
#nullable restore
#line 17 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Employees\Views\Team\Details.cshtml"
                                             Write(Model.Names.GetFullNames());

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                            <span class=\"text-blue\">");
#nullable restore
#line 18 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Employees\Views\Team\Details.cshtml"
                                               Write(Model.WorkTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span>
                        </div>
                        <div class=""social pull-right"">
                            <ul class=""list-inline social-icon"">
                                <li><a href=""#""><i class=""fa fa-facebook""></i> </a></li>
                                <li><a href=""#""><i class=""fa fa-twitter""></i> </a></li>
                                <li><a href=""#""><i class=""fa fa-dribbble""></i> </a></li>
                                <li><a href=""#""><i class=""fa fa-pinterest-p""></i> </a></li>
                            </ul>
                        </div>
                    </div>
                    <div class=""clearfix mb-2"">
                        <p>");
#nullable restore
#line 30 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Employees\Views\Team\Details.cshtml"
                      Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 35 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Employees\Views\Team\Details.cshtml"
         if (Model.Skills.Any())
        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div class=""row top-m3 mt-5"">
                <div class=""col-md-6"">
                    <h4 class=""mb-2"">Powerful Skills</h4>
                    <b>Habit is the intersection of knowledge (what to do), skill (how to do), and desire (want to do).</b>
");
#nullable restore
#line 41 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Employees\Views\Team\Details.cshtml"
                     if (Model.Bio != Model.Description)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"clearfix pt-2\">\r\n                            <p>\r\n                                ");
#nullable restore
#line 45 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Employees\Views\Team\Details.cshtml"
                           Write(Model.Bio);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </p>\r\n                        </div>\r\n");
#nullable restore
#line 48 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Employees\Views\Team\Details.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n                <div class=\"col-md-6\">\r\n");
#nullable restore
#line 51 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Employees\Views\Team\Details.cshtml"
                     foreach (var item in Model.Skills)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"skill\">\r\n                            <div class=\"skill-bar\" data-percent=\"");
#nullable restore
#line 54 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Employees\Views\Team\Details.cshtml"
                                                            Write(item.Rating);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-delay=\"0\" data-type=\"%\">\r\n                                <div class=\"progress-title\">");
#nullable restore
#line 55 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Employees\Views\Team\Details.cshtml"
                                                       Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                            </div>\r\n                        </div>\r\n");
#nullable restore
#line 58 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Employees\Views\Team\Details.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n");
#nullable restore
#line 61 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Employees\Views\Team\Details.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Employee> Html { get; private set; }
    }
}
#pragma warning restore 1591