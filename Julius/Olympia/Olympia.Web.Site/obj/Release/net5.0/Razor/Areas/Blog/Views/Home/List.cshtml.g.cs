#pragma checksum "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Blog\Views\Home\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ebd3a25b42d32bddf2baee8520eec0349c50ab9d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Blog_Views_Home_List), @"mvc.1.0.view", @"/Areas/Blog/Views/Home/List.cshtml")]
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
#line 1 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Blog\Views\_ViewImports.cshtml"
using Filing.Base.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Blog\Views\_ViewImports.cshtml"
using Filing.Base.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Blog\Views\_ViewImports.cshtml"
using Grouping.Base.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Blog\Views\_ViewImports.cshtml"
using Blogging.Base.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Blog\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Blog\Views\_ViewImports.cshtml"
using Grouping.Core.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Blog\Views\_ViewImports.cshtml"
using Blogging.Core.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Blog\Views\_ViewImports.cshtml"
using Iqt.Base.Extensions;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ebd3a25b42d32bddf2baee8520eec0349c50ab9d", @"/Areas/Blog/Views/Home/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d68d9c0a01924fc96bffb67fb7f7f00e6c73009d", @"/Areas/Blog/Views/_ViewImports.cshtml")]
    public class Areas_Blog_Views_Home_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BlogIndexPageModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success btn-icon btn-circle"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Blog", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Services", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "List", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info btn-block"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 3 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Blog\Views\Home\List.cshtml"
  
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
                        Title
                    </th>
                    <th>
                        Description
                    </th>
                    <th></th>
                </tr>
            </thead>
            <tbody>

");
#nullable restore
#line 25 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Blog\Views\Home\List.cshtml"
                 if (Model.All.Any())
                {
                    foreach (var item in Model.AllPaged.Results.OrderByDescending(c => c.Created))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr");
            BeginWriteAttribute("id", " id=\"", 738, "\"", 755, 2);
            WriteAttributeValue("", 743, "row_", 743, 4, true);
#nullable restore
#line 29 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Blog\Views\Home\List.cshtml"
WriteAttributeValue("", 747, item.Id, 747, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("class", " class=\"", 756, "\"", 776, 2);
            WriteAttributeValue("", 764, "row_", 764, 4, true);
#nullable restore
#line 29 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Blog\Views\Home\List.cshtml"
WriteAttributeValue("", 768, item.Id, 768, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                            <td>\r\n                                <a");
            BeginWriteAttribute("href", " href=\"", 848, "\"", 917, 1);
#nullable restore
#line 31 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Blog\Views\Home\List.cshtml"
WriteAttributeValue("", 855, Url.Action("Edit", "Home", new {area = "Blog", id = item.Id}), 855, 62, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    <img id=\"preview\" style=\"height: auto;\" class=\"img-thumbnail\"");
            BeginWriteAttribute("title", " title=\"", 1018, "\"", 1037, 1);
#nullable restore
#line 32 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Blog\Views\Home\List.cshtml"
WriteAttributeValue("", 1026, item.Title, 1026, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 1038, "\"", 1070, 1);
#nullable restore
#line 32 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Blog\Views\Home\List.cshtml"
WriteAttributeValue("", 1044, item.GetImage()?.FileName, 1044, 26, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("src", " src=\"", 1071, "\"", 1187, 1);
#nullable restore
#line 32 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Blog\Views\Home\List.cshtml"
WriteAttributeValue("", 1077, item.GetPath("http://admin.metsi.co.za",ImageType.Cover,"/images/placeholders/MetsiPlaceholder-370x352.jpg" ), 1077, 110, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                </a>\r\n                            </td>\r\n                            <td style=\"width:15%;\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ebd3a25b42d32bddf2baee8520eec0349c50ab9d11438", async() => {
                WriteLiteral("<strong>");
#nullable restore
#line 36 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Blog\Views\Home\List.cshtml"
                                                                                   Write(Html.DisplayFor(modelItem => item.Title));

#line default
#line hidden
#nullable disable
                WriteLiteral("</strong>");
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
#line 36 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Blog\Views\Home\List.cshtml"
                                                          WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 39 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Blog\Views\Home\List.cshtml"
                           Write(item.Description.HtmlToPlainText().TruncateLongString(150));

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n                            </td>\r\n                            <td style=\"width: 150px\" class=\"text-right\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ebd3a25b42d32bddf2baee8520eec0349c50ab9d14580", async() => {
                WriteLiteral("<i class=\"fa fa-edit\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 42 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Blog\Views\Home\List.cshtml"
                                                       WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                <a href=\"javascript:;\" class=\"btn btn-warning btn-icon btn-circle\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1984, "\"", 2021, 3);
            WriteAttributeValue("", 1994, "ShowDeleteModal(\'", 1994, 17, true);
#nullable restore
#line 43 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Blog\Views\Home\List.cshtml"
WriteAttributeValue("", 2011, item.Id, 2011, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2019, "\')", 2019, 2, true);
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-trash\"></i></a>\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 46 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Blog\Views\Home\List.cshtml"
                    }
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td colspan=\"3\">\r\n                            <h4>\r\n                                No blog entries available, please check back later or ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ebd3a25b42d32bddf2baee8520eec0349c50ab9d18131", async() => {
                WriteLiteral("Create a new Blog Entry");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" !!!\r\n                            </h4>\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 57 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Blog\Views\Home\List.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n\r\n");
#nullable restore
#line 61 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Blog\Views\Home\List.cshtml"
         if (Model.AllPaged.PageCount > 1)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"pagination-nav text-center\">\r\n                <ul class=\"pagination\">\r\n");
#nullable restore
#line 65 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Blog\Views\Home\List.cshtml"
                     if (Model.CurrentPage != 1)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li><a ");
#nullable restore
#line 67 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Blog\Views\Home\List.cshtml"
                          Write(Url.Action("List", new { page = 1 }));

#line default
#line hidden
#nullable disable
            WriteLiteral(">«</a></li>\r\n");
#nullable restore
#line 68 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Blog\Views\Home\List.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 69 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Blog\Views\Home\List.cshtml"
                     for (int p = 1; p <= Model.AllPaged.PageCount; p++)
                    {
                        if (p == Model.AllPaged.CurrentPage)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <li class=\"active\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ebd3a25b42d32bddf2baee8520eec0349c50ab9d21782", async() => {
#nullable restore
#line 73 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Blog\Views\Home\List.cshtml"
                                                                                                                              Write(p);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-pagel", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 73 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Blog\Views\Home\List.cshtml"
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
#line 74 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Blog\Views\Home\List.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <li>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ebd3a25b42d32bddf2baee8520eec0349c50ab9d25077", async() => {
#nullable restore
#line 77 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Blog\Views\Home\List.cshtml"
                                                                                                               Write(p);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-pagel", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 77 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Blog\Views\Home\List.cshtml"
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
#line 78 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Blog\Views\Home\List.cshtml"
                        }
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 80 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Blog\Views\Home\List.cshtml"
                     if (Model.CurrentPage != Model.AllPaged.PageCount)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li><a ");
#nullable restore
#line 82 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Blog\Views\Home\List.cshtml"
                          Write(Url.Action("List", new { page = Model.AllPaged.PageCount }));

#line default
#line hidden
#nullable disable
            WriteLiteral(">»</a></li>\r\n");
#nullable restore
#line 83 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Blog\Views\Home\List.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </ul>\r\n            </div>\r\n");
#nullable restore
#line 86 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Blog\Views\Home\List.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<p class=\"text-right\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ebd3a25b42d32bddf2baee8520eec0349c50ab9d29483", async() => {
                WriteLiteral("Create New Blog Entry");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</p>\r\n\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
#nullable restore
#line 96 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Blog\Views\Home\List.cshtml"
Write(await Html.PartialAsync("_ValidationScriptsPartial"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"

    <script>
        function ShowDeleteModal(ff) {

            var url = ""/Blog/Home/Delete?id="" + ff;

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BlogIndexPageModel> Html { get; private set; }
    }
}
#pragma warning restore 1591