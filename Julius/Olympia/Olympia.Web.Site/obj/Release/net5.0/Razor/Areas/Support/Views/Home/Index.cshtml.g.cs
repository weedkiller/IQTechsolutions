#pragma checksum "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Support\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4ed194bcd3a48b2ba285808c6e965ead907656dc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Support_Views_Home_Index), @"mvc.1.0.view", @"/Areas/Support/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Support\Views\_ViewImports.cshtml"
using Feedback.Core.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Support\Views\_ViewImports.cshtml"
using Feedback.Base.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ed194bcd3a48b2ba285808c6e965ead907656dc", @"/Areas/Support/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4d06e4a5efe25d0a9142da7b070f06a2f98848e2", @"/Areas/Support/Views/_ViewImports.cshtml")]
    public class Areas_Support_Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SupportTicket>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("padding-right:10px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary btn-circle"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("padding-right: 10px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 1 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Support\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Get In-Touch";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Support\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Support Ticket List";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"


<div class=""row"">



    <table class=""table"">
        <thead style=""position: relative; text-align: center;align-content: center;justify-content: center;  padding-left:30px;"">
            Form Submission
        </thead>
        <thead>
            <tr>
                <th>
");
            WriteLiteral("                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 27 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Support\Views\Home\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 30 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Support\Views\Home\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                        ");
#nullable restore
#line 33 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Support\Views\Home\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.CellNr));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 36 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Support\Views\Home\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.Subject));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 39 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Support\Views\Home\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.Content));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                        ");
#nullable restore
#line 42 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Support\Views\Home\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.Priority));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
#nullable restore
#line 45 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Support\Views\Home\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.TicketStatus));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </th>\r\n                <th></th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 51 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Support\Views\Home\Index.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr");
            BeginWriteAttribute("id", " id=\"", 1503, "\"", 1520, 2);
            WriteAttributeValue("", 1508, "row_", 1508, 4, true);
#nullable restore
#line 53 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Support\Views\Home\Index.cshtml"
WriteAttributeValue("", 1512, item.Id, 1512, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("class", " class=\"", 1521, "\"", 1541, 2);
            WriteAttributeValue("", 1529, "row_", 1529, 4, true);
#nullable restore
#line 53 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Support\Views\Home\Index.cshtml"
WriteAttributeValue("", 1533, item.Id, 1533, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <td>\r\n");
            WriteLiteral("                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 58 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Support\Views\Home\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 61 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Support\Views\Home\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                            ");
#nullable restore
#line 64 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Support\Views\Home\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.CellNr));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 67 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Support\Views\Home\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Subject));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 70 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Support\Views\Home\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Content));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                            ");
#nullable restore
#line 73 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Support\Views\Home\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Priority));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 76 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Support\Views\Home\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.TicketStatus));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                    <td>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4ed194bcd3a48b2ba285808c6e965ead907656dc12303", async() => {
                WriteLiteral("Reply");
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
#line 79 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Support\Views\Home\Index.cshtml"
                                                  WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4ed194bcd3a48b2ba285808c6e965ead907656dc14686", async() => {
                WriteLiteral("<i class=\"fa fa-eye\"></i>");
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
#line 80 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Support\Views\Home\Index.cshtml"
                                                  WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        <a href=\"javascript:;\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2949, "\"", 2986, 3);
            WriteAttributeValue("", 2959, "ShowDeleteModal(\'", 2959, 17, true);
#nullable restore
#line 81 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Support\Views\Home\Index.cshtml"
WriteAttributeValue("", 2976, item.Id, 2976, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2984, "\')", 2984, 2, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger btn-circle\"><i class=\"fa fa-trash\"></i></a>\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 84 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Areas\Support\Views\Home\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SupportTicket>> Html { get; private set; }
    }
}
#pragma warning restore 1591