#pragma checksum "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Training\Views\Shared\Components\CourseModuleSections\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d75c71b2471ce8404749bcfd47884bcc8090cbfd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_CourseModuleSections_Default), @"mvc.1.0.view", @"/Views/Shared/Components/CourseModuleSections/Default.cshtml")]
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
#line 1 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Training\Views\Shared\Components\CourseModuleSections\Default.cshtml"
using Iqt.Base.Extensions;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d75c71b2471ce8404749bcfd47884bcc8090cbfd", @"/Views/Shared/Components/CourseModuleSections/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ad6dc543a44e79ad70395dc064e5d3519aeba74", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_CourseModuleSections_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Education.Base.ApiModels.SectionApiModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""ibox float-e-margins"">
    <div class=""ibox-title"">
        <h5>Training Sections</h5>
        <div class=""ibox-tools"">
            <a class=""collapse-link"">
                <i class=""fa fa-chevron-up""></i>
            </a>
            <a class=""close-link"">
                <i class=""fa fa-times""></i>
            </a>
        </div>
    </div>
    <div class=""ibox-content"">
        <p>
            This is basic example of Step
        </p>
        <div id=""wizard"">
            
");
#nullable restore
#line 22 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Training\Views\Shared\Components\CourseModuleSections\Default.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <h1>");
#nullable restore
#line 24 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Training\Views\Shared\Components\CourseModuleSections\Default.cshtml"
               Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n                <div class=\"step-content\">\r\n                    <div class=\"text-center m-t-md\">\r\n                        <h2>");
#nullable restore
#line 27 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Training\Views\Shared\Components\CourseModuleSections\Default.cshtml"
                       Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n                        <p>\r\n                            ");
#nullable restore
#line 29 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Training\Views\Shared\Components\CourseModuleSections\Default.cshtml"
                       Write(item.Description.HtmlToPlainText());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </p>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 33 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Training\Views\Shared\Components\CourseModuleSections\Default.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Education.Base.ApiModels.SectionApiModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591