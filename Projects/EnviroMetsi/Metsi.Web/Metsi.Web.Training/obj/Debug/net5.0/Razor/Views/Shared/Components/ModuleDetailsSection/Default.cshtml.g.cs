#pragma checksum "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Training\Views\Shared\Components\ModuleDetailsSection\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "52ceb53044dbe52c924115609f30407a979f8d72"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_ModuleDetailsSection_Default), @"mvc.1.0.view", @"/Views/Shared/Components/ModuleDetailsSection/Default.cshtml")]
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
#line 1 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Training\Views\Shared\Components\ModuleDetailsSection\Default.cshtml"
using Identity.Base.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"52ceb53044dbe52c924115609f30407a979f8d72", @"/Views/Shared/Components/ModuleDetailsSection/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ad6dc543a44e79ad70395dc064e5d3519aeba74", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_ModuleDetailsSection_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Education.Base.ApiModels.ModuleApiModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"wrapper wrapper-content project-manager\">\r\n    <h4>Project description</h4>\r\n    <img");
            BeginWriteAttribute("src", " src=\"", 178, "\"", 199, 1);
#nullable restore
#line 6 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Training\Views\Shared\Components\ModuleDetailsSection\Default.cshtml"
WriteAttributeValue("", 184, Model.ImageUrl, 184, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 200, "\"", 217, 1);
#nullable restore
#line 6 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Training\Views\Shared\Components\ModuleDetailsSection\Default.cshtml"
WriteAttributeValue("", 206, Model.Name, 206, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"img-responsive\">\r\n    <p class=\"small\">\r\n        ");
#nullable restore
#line 8 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Training\Views\Shared\Components\ModuleDetailsSection\Default.cshtml"
   Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </p>\r\n    <p class=\"small font-bold\">\r\n        <span><i class=\"fa fa-circle text-warning\"></i> High priority</span>\r\n    </p>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Education.Base.ApiModels.ModuleApiModel> Html { get; private set; }
    }
}
#pragma warning restore 1591