#pragma checksum "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Training\Views\Shared\Components\EmployeeSection\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dac83bef04169b60a097ee7d674eb430d741abad"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_EmployeeSection_Default), @"mvc.1.0.view", @"/Views/Shared/Components/EmployeeSection/Default.cshtml")]
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
#line 1 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Training\Views\_ViewImports.cshtml"
using Metsi.Web.Training;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Training\Views\_ViewImports.cshtml"
using Metsi.Web.Training.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Training\Views\Shared\Components\EmployeeSection\Default.cshtml"
using Iqt.Base.Interfaces;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dac83bef04169b60a097ee7d674eb430d741abad", @"/Views/Shared/Components/EmployeeSection/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ad6dc543a44e79ad70395dc064e5d3519aeba74", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_EmployeeSection_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Employment.Base.ApiModels.EmployeeModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<section id=""team"" class=""team"">
    <div class=""container"">
        <div class=""row m-b-lg"">
            <div class=""col-lg-12 text-center"">
                <div class=""navy-line""></div>
                <h1>Our Team</h1>
                <p>Meet our passionate industry experts.</p>
            </div>
        </div>
        <div class=""row"">
");
#nullable restore
#line 15 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Training\Views\Shared\Components\EmployeeSection\Default.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"col-sm-4 wow fadeInLeft\">\r\n                    <div class=\"team-member\">\r\n                        <img");
            BeginWriteAttribute("src", " src=\"", 680, "\"", 700, 1);
#nullable restore
#line 19 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Training\Views\Shared\Components\EmployeeSection\Default.cshtml"
WriteAttributeValue("", 686, item.ImageUrl, 686, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"img-responsive img-circle img-small\"");
            BeginWriteAttribute("alt", " alt=\"", 745, "\"", 795, 4);
#nullable restore
#line 19 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Training\Views\Shared\Components\EmployeeSection\Default.cshtml"
WriteAttributeValue("", 751, item.FirstName, 751, 15, false);

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Training\Views\Shared\Components\EmployeeSection\Default.cshtml"
WriteAttributeValue(" ", 766, item.LastName, 767, 14, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 781, "Profile", 782, 8, true);
            WriteAttributeValue(" ", 789, "Image", 790, 6, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <h4><span class=\"navy\">");
#nullable restore
#line 20 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Training\Views\Shared\Components\EmployeeSection\Default.cshtml"
                                          Write(item.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span> ");
#nullable restore
#line 20 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Training\Views\Shared\Components\EmployeeSection\Default.cshtml"
                                                                 Write(item.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                        <p>");
#nullable restore
#line 21 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Training\Views\Shared\Components\EmployeeSection\Default.cshtml"
                      Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\r\n                        <ul class=\"list-inline social-icon\">\r\n\r\n");
#nullable restore
#line 24 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Training\Views\Shared\Components\EmployeeSection\Default.cshtml"
                             if (!string.IsNullOrEmpty(item.TwitterUrl) && item.TwitterUrl != "#")
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <li>\r\n                                    <a");
            BeginWriteAttribute("href", " href=\"", 1212, "\"", 1235, 1);
#nullable restore
#line 27 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Training\Views\Shared\Components\EmployeeSection\Default.cshtml"
WriteAttributeValue("", 1219, item.TwitterUrl, 1219, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-twitter\"></i></a>\r\n                                </li>\r\n");
#nullable restore
#line 29 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Training\Views\Shared\Components\EmployeeSection\Default.cshtml"
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Training\Views\Shared\Components\EmployeeSection\Default.cshtml"
                             if (!string.IsNullOrEmpty(item.FacebookUrl) && item.FacebookUrl != "#")
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <li>\r\n                                    <a");
            BeginWriteAttribute("href", " href=\"", 1551, "\"", 1575, 1);
#nullable restore
#line 33 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Training\Views\Shared\Components\EmployeeSection\Default.cshtml"
WriteAttributeValue("", 1558, item.FacebookUrl, 1558, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-facebook\"></i></a>\r\n                                </li>\r\n");
#nullable restore
#line 35 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Training\Views\Shared\Components\EmployeeSection\Default.cshtml"
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Training\Views\Shared\Components\EmployeeSection\Default.cshtml"
                             if (!string.IsNullOrEmpty(item.LinkedInUrl) && item.LinkedInUrl != "#")
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <li>\r\n                                    <a");
            BeginWriteAttribute("href", " href=\"", 1892, "\"", 1916, 1);
#nullable restore
#line 39 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Training\Views\Shared\Components\EmployeeSection\Default.cshtml"
WriteAttributeValue("", 1899, item.LinkedInUrl, 1899, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-linkedin\"></i></a>\r\n                                </li>\r\n");
#nullable restore
#line 41 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Training\Views\Shared\Components\EmployeeSection\Default.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </ul>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 45 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Training\Views\Shared\Components\EmployeeSection\Default.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Employment.Base.ApiModels.EmployeeModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
