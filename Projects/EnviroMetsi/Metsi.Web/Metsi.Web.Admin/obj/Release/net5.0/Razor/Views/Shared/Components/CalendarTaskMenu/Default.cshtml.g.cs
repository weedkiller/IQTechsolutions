#pragma checksum "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\Components\CalendarTaskMenu\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8595dd2713cacee69a278e5e8385648f73f2258b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_CalendarTaskMenu_Default), @"mvc.1.0.view", @"/Views/Shared/Components/CalendarTaskMenu/Default.cshtml")]
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
#nullable restore
#line 1 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\Components\CalendarTaskMenu\Default.cshtml"
using Metsi.Web.Admin.ThemeSettings;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8595dd2713cacee69a278e5e8385648f73f2258b", @"/Views/Shared/Components/CalendarTaskMenu/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"58acc36c7c6b2cabb3fe2c504456252e879f0d65", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_CalendarTaskMenu_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CalendarTaskMenuModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<div id=\"external-events\" class=\"calendar-event\">\r\n    <div id=\'external-events-list\'>\r\n        <h4 class=\" m-b-20\">Task to Complete</h4>\r\n");
#nullable restore
#line 8 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\Components\CalendarTaskMenu\Default.cshtml"
         foreach (var item in Model.RecurringTasks)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div");
            BeginWriteAttribute("class", " class=\'", 291, "\'", 426, 6);
            WriteAttributeValue("", 299, "fc-event", 299, 8, true);
            WriteAttributeValue(" ", 307, "fc-h-event", 308, 11, true);
            WriteAttributeValue(" ", 318, "fc-daygrid-event", 319, 17, true);
            WriteAttributeValue(" ", 335, "fc-daygrid-block-event", 336, 23, true);
            WriteAttributeValue(" ", 358, "external-event", 359, 15, true);
#nullable restore
#line 10 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\Components\CalendarTaskMenu\Default.cshtml"
WriteAttributeValue(" ", 373, ThemeColors.GetDragableTaskColor(item.TaskPriority), 374, 52, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" \r\n                 data-title=\"");
#nullable restore
#line 11 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\Components\CalendarTaskMenu\Default.cshtml"
                        Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-description=\"");
#nullable restore
#line 11 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\Components\CalendarTaskMenu\Default.cshtml"
                                                      Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-taskId=\"");
#nullable restore
#line 11 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\Components\CalendarTaskMenu\Default.cshtml"
                                                                                      Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                <div class=\'fc-event-main\' >\r\n                    <h5 class=\"eventHeading\">");
#nullable restore
#line 13 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\Components\CalendarTaskMenu\Default.cshtml"
                                        Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                    <p style=\"white-space: pre-wrap; font-size: 11px;\">");
#nullable restore
#line 14 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\Components\CalendarTaskMenu\Default.cshtml"
                                                                  Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 17 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\Components\CalendarTaskMenu\Default.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <h4 class=\" m-b-20\">Draggable Routes</h4>\r\n");
#nullable restore
#line 19 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\Components\CalendarTaskMenu\Default.cshtml"
         foreach (var item in Model.Routes)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\'fc-event fc-h-event fc-daygrid-event fc-daygrid-block-event external-event bg-green\' \r\n                 data-title=\"");
#nullable restore
#line 22 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\Components\CalendarTaskMenu\Default.cshtml"
                        Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-description=\"");
#nullable restore
#line 22 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\Components\CalendarTaskMenu\Default.cshtml"
                                                      Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-routeId=\"");
#nullable restore
#line 22 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\Components\CalendarTaskMenu\Default.cshtml"
                                                                                       Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                <div class=\'fc-event-main\'>\r\n                    <h5>");
#nullable restore
#line 24 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\Components\CalendarTaskMenu\Default.cshtml"
                   Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                    <p style=\"white-space: pre-wrap; font-size: 11px;\">");
#nullable restore
#line 25 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\Components\CalendarTaskMenu\Default.cshtml"
                                                                  Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 28 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\Components\CalendarTaskMenu\Default.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n    <div class=\"checkbox\">\r\n        <label>\r\n            <input type=\"checkbox\" id=\"drop-remove\" />\r\n            remove after drop\r\n        </label>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CalendarTaskMenuModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
