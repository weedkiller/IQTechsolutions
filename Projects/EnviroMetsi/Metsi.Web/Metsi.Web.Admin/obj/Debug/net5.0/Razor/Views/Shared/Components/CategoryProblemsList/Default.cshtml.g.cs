#pragma checksum "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\Components\CategoryProblemsList\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7a6ede37b0b5f3b95cfeb52174073f3f22ef81c8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_CategoryProblemsList_Default), @"mvc.1.0.view", @"/Views/Shared/Components/CategoryProblemsList/Default.cshtml")]
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
#nullable restore
#line 1 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\Components\CategoryProblemsList\Default.cshtml"
using Iqt.Base.Extensions;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7a6ede37b0b5f3b95cfeb52174073f3f22ef81c8", @"/Views/Shared/Components/CategoryProblemsList/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"58acc36c7c6b2cabb3fe2c504456252e879f0d65", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_CategoryProblemsList_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Grouping.Base.Entities.EntityCategory<Troubleshooting.Base.Entities.Problem>>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Troubleshooting", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success btn-icon btn-circle"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral(" \r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                Heading\r\n            </th>\r\n            <th>\r\n                Description\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 17 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\Components\CategoryProblemsList\Default.cshtml"
         if (Model.Any())
        {
            foreach (var pack in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr");
            BeginWriteAttribute("id", " id=\"", 485, "\"", 508, 2);
            WriteAttributeValue("", 490, "row_", 490, 4, true);
#nullable restore
#line 21 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\Components\CategoryProblemsList\Default.cshtml"
WriteAttributeValue("", 494, pack.EntityId, 494, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("class", " class=\"", 509, "\"", 535, 2);
            WriteAttributeValue("", 517, "row_", 517, 4, true);
#nullable restore
#line 21 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\Components\CategoryProblemsList\Default.cshtml"
WriteAttributeValue("", 521, pack.EntityId, 521, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <td>\r\n                        ");
#nullable restore
#line 23 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\Components\CategoryProblemsList\Default.cshtml"
                   Write(pack.Entity.Heading);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 26 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\Components\CategoryProblemsList\Default.cshtml"
                   Write(pack.Entity.Description.HtmlToPlainText().TruncateLongString(150));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7a6ede37b0b5f3b95cfeb52174073f3f22ef81c87483", async() => {
                WriteLiteral("<i class=\"fa fa-edit\"></i>");
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
#line 29 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\Components\CategoryProblemsList\Default.cshtml"
                                                                                                WriteLiteral(pack.EntityId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        <a href=\"javascript:;\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1055, "\"", 1105, 3);
            WriteAttributeValue("", 1065, "ShowDeleteProblemModal(\'", 1065, 24, true);
#nullable restore
#line 30 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\Components\CategoryProblemsList\Default.cshtml"
WriteAttributeValue("", 1089, pack.EntityId, 1089, 14, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1103, "\')", 1103, 2, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-warning btn-icon btn-circle\"><i class=\"fa fa-trash\"></i></a>\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 33 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\Components\CategoryProblemsList\Default.cshtml"
            }
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td colspan=\"3\">\r\n                    <h4>\r\n                        There are currently problems available for this category.\r\n                    </h4>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 44 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\Components\CategoryProblemsList\Default.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n    <tfoot>\r\n        <tr>\r\n            <td colspan=\"3\">\r\n                <input name=\"prob\" type=\"submit\" value=\"Add New Problem\" class=\"btn btn-block btn-info\" />\r\n            </td>\r\n        </tr>\r\n    </tfoot>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Grouping.Base.Entities.EntityCategory<Troubleshooting.Base.Entities.Problem>>> Html { get; private set; }
    }
}
#pragma warning restore 1591
