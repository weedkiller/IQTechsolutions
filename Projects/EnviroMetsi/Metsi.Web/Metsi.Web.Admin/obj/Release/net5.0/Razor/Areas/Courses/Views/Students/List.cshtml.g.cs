#pragma checksum "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Courses\Views\Students\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6916436d0c2b9e9eed89593c57de673aef96df4b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Courses_Views_Students_List), @"mvc.1.0.view", @"/Areas/Courses/Views/Students/List.cshtml")]
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
#line 1 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Courses\Views\_ViewImports.cshtml"
using Iqt.Base.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Courses\Views\_ViewImports.cshtml"
using Iqt.Base.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Courses\Views\_ViewImports.cshtml"
using Education.Base.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Courses\Views\_ViewImports.cshtml"
using Grouping.Core.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Courses\Views\_ViewImports.cshtml"
using Education.Core.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Courses\Views\_ViewImports.cshtml"
using Grouping.Base.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Courses\Views\_ViewImports.cshtml"
using Filing.Base.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Courses\Views\Students\List.cshtml"
using Filing.Base.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Courses\Views\Students\List.cshtml"
using Iqt.Base.Interfaces;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6916436d0c2b9e9eed89593c57de673aef96df4b", @"/Areas/Courses/Views/Students/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23f27f861f79c5293781ad11ed0e01a4ad343231", @"/Areas/Courses/Views/_ViewImports.cshtml")]
    public class Areas_Courses_Views_Students_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Education.Base.Entities.Student>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary btn-circle btn-xs"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Courses", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Students", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger btn-block"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 8 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Courses\Views\Students\List.cshtml"
  
    ViewData["Title"] = "Student List";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""profile-container"">
    <div class=""profile-section"">
        <table class=""table"">
            <thead>
                <tr>
                    <th>
                        Image
                    </th>
                    <th>
                        Names
                    </th>
                    <th>
                        Phone Number
                    </th>
                    <th>
                        Email Address
                    </th>
                    <th>
                        ");
#nullable restore
#line 29 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Courses\Views\Students\List.cshtml"
                   Write(Html.DisplayNameFor(model => model.Active));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th></th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 35 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Courses\Views\Students\List.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr");
            BeginWriteAttribute("id", " id=\"", 1015, "\"", 1032, 2);
            WriteAttributeValue("", 1020, "row_", 1020, 4, true);
#nullable restore
#line 37 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Courses\Views\Students\List.cshtml"
WriteAttributeValue("", 1024, item.Id, 1024, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("class", " class=\"", 1033, "\"", 1053, 2);
            WriteAttributeValue("", 1041, "row_", 1041, 4, true);
#nullable restore
#line 37 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Courses\Views\Students\List.cshtml"
WriteAttributeValue("", 1045, item.Id, 1045, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <td>\r\n");
#nullable restore
#line 39 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Courses\Views\Students\List.cshtml"
                          
                            var source = "";
                            if(item.UserInfo != null)
                            {
                                source = @item.UserInfo.GetPath(Configuration.BaseImageUrl, ImageType.Cover, Configuration.ImageProfilePlaceholder);
                            }
                            else
                            {
                                source = Configuration.ImageProfilePlaceholder;
                            }
                        

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        <img style=\"width:100px\" id=\"preview\" class=\"img-thumbnail\"");
            BeginWriteAttribute("title", " title=\"", 1717, "\"", 1751, 1);
#nullable restore
#line 51 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Courses\Views\Students\List.cshtml"
WriteAttributeValue("", 1725, item.Names.GetFullNames(), 1725, 26, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 1752, "\"", 1794, 1);
#nullable restore
#line 51 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Courses\Views\Students\List.cshtml"
WriteAttributeValue("", 1758, item.UserInfo?.GetImage()?.FileName, 1758, 36, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("src", " src=\"", 1795, "\"", 1808, 1);
#nullable restore
#line 51 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Courses\Views\Students\List.cshtml"
WriteAttributeValue("", 1801, source, 1801, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("/>\r\n                        <td>\r\n                            ");
#nullable restore
#line 53 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Courses\Views\Students\List.cshtml"
                       Write(item.DisplayName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 56 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Courses\Views\Students\List.cshtml"
                       Write(item.ContactNumbers.FirstOrDefault(c => c.Default)?.Number);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 59 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Courses\Views\Students\List.cshtml"
                       Write(item.EmailAddresses.FirstOrDefault(c => c.Default)?.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 62 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Courses\Views\Students\List.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Active));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td style=\"width: 100px\">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6916436d0c2b9e9eed89593c57de673aef96df4b12536", async() => {
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
#line 65 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Courses\Views\Students\List.cshtml"
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
            WriteLiteral("\r\n                            <a href=\"javascript:;\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2603, "\"", 2640, 3);
            WriteAttributeValue("", 2613, "ShowDeleteModal(\'", 2613, 17, true);
#nullable restore
#line 66 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Courses\Views\Students\List.cshtml"
WriteAttributeValue("", 2630, item.Id, 2630, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2638, "\')", 2638, 2, true);
            EndWriteAttribute();
            WriteLiteral(" style=\"padding-left: 5px\" class=\"btn btn-danger btn-circle btn-xs\"><i class=\"fa fa-trash\"></i></a>\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 69 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Courses\Views\Students\List.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n            <tfoot>\r\n                <tr>\r\n                    <td colspan=\"6\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6916436d0c2b9e9eed89593c57de673aef96df4b15919", async() => {
                WriteLiteral("Register New Student");
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
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n            </tfoot>\r\n        </table>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        function ShowDeleteModal(ff) {
            var url = ""/Courses/Students/Delete?id="" + ff;

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Education.Base.Entities.Student>> Html { get; private set; }
    }
}
#pragma warning restore 1591
