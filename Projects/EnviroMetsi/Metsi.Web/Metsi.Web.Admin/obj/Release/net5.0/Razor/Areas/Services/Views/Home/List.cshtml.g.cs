#pragma checksum "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Services\Views\Home\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "506c53ccea5b732c26cf716cb2b182a153fd8377"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Services_Views_Home_List), @"mvc.1.0.view", @"/Areas/Services/Views/Home/List.cshtml")]
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
#line 1 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Services\Views\_ViewImports.cshtml"
using Filing.Base.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Services\Views\_ViewImports.cshtml"
using Filing.Base.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Services\Views\_ViewImports.cshtml"
using Iqt.Base.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Services\Views\_ViewImports.cshtml"
using Services.Core.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"506c53ccea5b732c26cf716cb2b182a153fd8377", @"/Areas/Services/Views/Home/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3e5c7628a1cbcd6f6651d0c1ebf24967b3aad9e5", @"/Areas/Services/Views/_ViewImports.cshtml")]
    public class Areas_Services_Views_Home_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ServiceIndexModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success btn-icon btn-circle"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Services", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "List", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info btn-block"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 4 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Services\Views\Home\List.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<table class=""table"">
    <thead>
        <tr>
            <th style=""width: 15%"">
                Cover Image
            </th>
            <th>
                Name
            </th>
            <th>
                Short Description
            </th>
            <th>
                Active
            </th>
            <th>
                Featured
            </th>
            <th></th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 30 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Services\Views\Home\List.cshtml"
         if (Model.All.Any())
        {
            foreach (var item in Model.AllPaged.Results)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr");
            BeginWriteAttribute("id", " id=\"", 662, "\"", 679, 2);
            WriteAttributeValue("", 667, "row_", 667, 4, true);
#nullable restore
#line 34 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Services\Views\Home\List.cshtml"
WriteAttributeValue("", 671, item.Id, 671, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("class", " class=\"", 680, "\"", 700, 2);
            WriteAttributeValue("", 688, "row_", 688, 4, true);
#nullable restore
#line 34 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Services\Views\Home\List.cshtml"
WriteAttributeValue("", 692, item.Id, 692, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <td>\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 756, "\"", 813, 1);
#nullable restore
#line 36 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Services\Views\Home\List.cshtml"
WriteAttributeValue("", 763, Url.Action("Details", "Home", new {id = item.Id}), 763, 50, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                            <img id=\"preview\" style=\"height: auto;\" class=\"img-thumbnail\"");
            BeginWriteAttribute("title", " title=\"", 906, "\"", 924, 1);
#nullable restore
#line 37 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Services\Views\Home\List.cshtml"
WriteAttributeValue("", 914, item.Name, 914, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 925, "\"", 941, 1);
#nullable restore
#line 37 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Services\Views\Home\List.cshtml"
WriteAttributeValue("", 931, item.Name, 931, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("src", " src=\"", 942, "\"", 1058, 1);
#nullable restore
#line 37 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Services\Views\Home\List.cshtml"
WriteAttributeValue("", 948, item.GetPath("http://admin.metsi.co.za", ImageType.Cover,"/images/placeholders/MetsiPlaceholder-800x533.jpg"), 948, 110, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        </a>\r\n                    </td>\r\n                    <td width=\"auto\">\r\n                        <strong>");
#nullable restore
#line 41 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Services\Views\Home\List.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 44 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Services\Views\Home\List.cshtml"
                   Write(item.AdditionalInfo.TruncateLongString(360));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 47 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Services\Views\Home\List.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Active));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 50 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Services\Views\Home\List.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Featured));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td width=\"100px\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "506c53ccea5b732c26cf716cb2b182a153fd837711007", async() => {
                WriteLiteral("<i class=\"fa fa-edit\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 53 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Services\Views\Home\List.cshtml"
                                               WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        <a href=\"javascript:;\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1866, "\"", 1915, 3);
            WriteAttributeValue("", 1876, "ShowDeleteBlogCategoryModal(\'", 1876, 29, true);
#nullable restore
#line 54 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Services\Views\Home\List.cshtml"
WriteAttributeValue("", 1905, item.Id, 1905, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1913, "\')", 1913, 2, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-warning btn-icon btn-circle\"><i class=\"fa fa-trash\"></i></a>\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 57 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Services\Views\Home\List.cshtml"
            }
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr id=\"row_nodata\" class=\"row_nodata\">\r\n                <td colspan=\"9\">\r\n                    <h4>No Services currently available, please check back later or <strong>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "506c53ccea5b732c26cf716cb2b182a153fd837714436", async() => {
                WriteLiteral(" create a new service now");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</strong></h4>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 66 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Services\Views\Home\List.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </tbody>\r\n</table>\r\n\r\n");
#nullable restore
#line 71 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Services\Views\Home\List.cshtml"
 if (Model.AllPaged.PageCount > 1)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"pagination-nav text-center\">\r\n        <ul class=\"pagination\">\r\n");
#nullable restore
#line 75 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Services\Views\Home\List.cshtml"
             if (Model.CurrentPage != 1)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li><a ");
#nullable restore
#line 77 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Services\Views\Home\List.cshtml"
                  Write(Url.Action("List", new { page = 1 }));

#line default
#line hidden
#nullable disable
            WriteLiteral(">«</a></li>\r\n");
#nullable restore
#line 78 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Services\Views\Home\List.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 79 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Services\Views\Home\List.cshtml"
             for (int p = 1; p <= Model.AllPaged.PageCount; p++)
            {
                if (p == Model.AllPaged.CurrentPage)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li class=\"active\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "506c53ccea5b732c26cf716cb2b182a153fd837717788", async() => {
#nullable restore
#line 83 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Services\Views\Home\List.cshtml"
                                                                                                                      Write(p);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-pagel", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 83 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Services\Views\Home\List.cshtml"
                                                                                                           WriteLiteral(p);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pagel"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-pagel", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pagel"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n");
#nullable restore
#line 84 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Services\Views\Home\List.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "506c53ccea5b732c26cf716cb2b182a153fd837720972", async() => {
#nullable restore
#line 87 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Services\Views\Home\List.cshtml"
                                                                                                       Write(p);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-pagel", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 87 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Services\Views\Home\List.cshtml"
                                                                                            WriteLiteral(p);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pagel"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-pagel", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pagel"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n");
#nullable restore
#line 88 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Services\Views\Home\List.cshtml"
                }
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 90 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Services\Views\Home\List.cshtml"
             if (Model.CurrentPage != Model.AllPaged.PageCount)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li><a ");
#nullable restore
#line 92 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Services\Views\Home\List.cshtml"
                  Write(Url.Action("List", new { page = Model.AllPaged.PageCount }));

#line default
#line hidden
#nullable disable
            WriteLiteral(">»</a></li>\r\n");
#nullable restore
#line 93 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Services\Views\Home\List.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </ul>\r\n    </div>\r\n");
#nullable restore
#line 96 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Services\Views\Home\List.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<p class=\"text-right\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "506c53ccea5b732c26cf716cb2b182a153fd837725135", async() => {
                WriteLiteral("Create New Service");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</p>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        function ShowDeleteBlogCategoryModal(numberId) {

            var url = ""/Services/Home/Delete?id="" + numberId;

            $(""#ModalPlaceHolder"").load(url,
                function () {
                    $(""#ModalPlaceHolder"").modal(""show"");
                });
        }
    </script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ServiceIndexModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
