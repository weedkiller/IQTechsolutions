#pragma checksum "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\Components\TasksToComplete\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "19768e19547c5892b057a389a5f7e2ae080d385f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_TasksToComplete_Default), @"mvc.1.0.view", @"/Views/Shared/Components/TasksToComplete/Default.cshtml")]
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
#line 1 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\_ViewImports.cshtml"
using Metsi.Web.Admin;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\_ViewImports.cshtml"
using Metsi.Web.Admin.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"19768e19547c5892b057a389a5f7e2ae080d385f", @"/Views/Shared/Components/TasksToComplete/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"58acc36c7c6b2cabb3fe2c504456252e879f0d65", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_TasksToComplete_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ICollection<Calendar.Base.Entities.RecurringTask>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h4 class=\"title\">Tasks <small>");
#nullable restore
#line 3 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\Components\TasksToComplete\Default.cshtml"
                          Write(Model.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral(" pending tasks</small></h4>\r\n<!-- begin scrollbar -->\r\n<div data-scrollbar=\"true\" data-height=\"280px\" class=\"bg-silver\">\r\n    <!-- begin todolist -->\r\n    <ul class=\"todolist\">\r\n");
#nullable restore
#line 8 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\Components\TasksToComplete\Default.cshtml"
         if (Model.Any())
        {
            foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li");
            BeginWriteAttribute("id", " id=\"", 394, "\"", 420, 2);
            WriteAttributeValue("", 399, "toDoListItem_", 399, 13, true);
#nullable restore
#line 12 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\Components\TasksToComplete\Default.cshtml"
WriteAttributeValue("", 412, item.Id, 412, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"active\">\r\n                    <a");
            BeginWriteAttribute("id", " id=\"", 461, "\"", 493, 2);
            WriteAttributeValue("", 466, "toDoListStatusLink_", 466, 19, true);
#nullable restore
#line 13 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\Components\TasksToComplete\Default.cshtml"
WriteAttributeValue("", 485, item.Id, 485, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("onclick", " onclick=\"", 494, "\"", 532, 3);
            WriteAttributeValue("", 504, "changeToDoStatus(\'", 504, 18, true);
#nullable restore
#line 13 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\Components\TasksToComplete\Default.cshtml"
WriteAttributeValue("", 522, item.Id, 522, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 530, "\')", 530, 2, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"todolist-container active\">\r\n                        <div class=\"todolist-input\"><i class=\"fa fa-square-o\"></i></div>\r\n                        <div class=\"todolist-title\">");
#nullable restore
#line 15 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\Components\TasksToComplete\Default.cshtml"
                                               Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                    </a>\r\n                </li>\r\n");
#nullable restore
#line 18 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\Components\TasksToComplete\Default.cshtml"
            }
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li class=\"active\">\r\n                <div class=\"todolist-title\">No tasks available</div>\r\n            </li>\r\n");
#nullable restore
#line 25 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\Components\TasksToComplete\Default.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </ul>\r\n    <!-- end todolist -->\r\n</div>\r\n<!-- end scrollbar -->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ICollection<Calendar.Base.Entities.RecurringTask>> Html { get; private set; }
    }
}
#pragma warning restore 1591
