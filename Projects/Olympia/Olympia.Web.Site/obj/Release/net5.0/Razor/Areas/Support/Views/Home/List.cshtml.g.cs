#pragma checksum "G:\Projects\Olympia\Olympia.Web.Site\Areas\Support\Views\Home\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "14dd6e5a432ff5096257b569936f6a092d329ba0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Support_Views_Home_List), @"mvc.1.0.view", @"/Areas/Support/Views/Home/List.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"14dd6e5a432ff5096257b569936f6a092d329ba0", @"/Areas/Support/Views/Home/List.cshtml")]
    public class Areas_Support_Views_Home_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SupportTicket>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "G:\Projects\Olympia\Olympia.Web.Site\Areas\Support\Views\Home\List.cshtml"
  
    ViewData["Title"] = "Support Ticket List";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 29 "G:\Projects\Olympia\Olympia.Web.Site\Areas\Support\Views\Home\List.cshtml"
           Write(Html.DisplayNameFor(model => model.EmailAddress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 32 "G:\Projects\Olympia\Olympia.Web.Site\Areas\Support\Views\Home\List.cshtml"
           Write(Html.DisplayNameFor(model => model.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 35 "G:\Projects\Olympia\Olympia.Web.Site\Areas\Support\Views\Home\List.cshtml"
           Write(Html.DisplayNameFor(model => model.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 38 "G:\Projects\Olympia\Olympia.Web.Site\Areas\Support\Views\Home\List.cshtml"
           Write(Html.DisplayNameFor(model => model.CellNr));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 41 "G:\Projects\Olympia\Olympia.Web.Site\Areas\Support\Views\Home\List.cshtml"
           Write(Html.DisplayNameFor(model => model.Subject));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 44 "G:\Projects\Olympia\Olympia.Web.Site\Areas\Support\Views\Home\List.cshtml"
           Write(Html.DisplayNameFor(model => model.Content));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 47 "G:\Projects\Olympia\Olympia.Web.Site\Areas\Support\Views\Home\List.cshtml"
           Write(Html.DisplayNameFor(model => model.Priority));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 50 "G:\Projects\Olympia\Olympia.Web.Site\Areas\Support\Views\Home\List.cshtml"
           Write(Html.DisplayNameFor(model => model.TicketStatus));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 56 "G:\Projects\Olympia\Olympia.Web.Site\Areas\Support\Views\Home\List.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr");
            BeginWriteAttribute("id", "  id=\"", 1805, "\"", 1823, 2);
            WriteAttributeValue("", 1811, "row_", 1811, 4, true);
#nullable restore
#line 58 "G:\Projects\Olympia\Olympia.Web.Site\Areas\Support\Views\Home\List.cshtml"
WriteAttributeValue("", 1815, item.Id, 1815, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("class", " class=\"", 1824, "\"", 1844, 2);
            WriteAttributeValue("", 1832, "row_", 1832, 4, true);
#nullable restore
#line 58 "G:\Projects\Olympia\Olympia.Web.Site\Areas\Support\Views\Home\List.cshtml"
WriteAttributeValue("", 1836, item.Id, 1836, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                <td>\r\n                    ");
#nullable restore
#line 60 "G:\Projects\Olympia\Olympia.Web.Site\Areas\Support\Views\Home\List.cshtml"
               Write(Html.DisplayFor(modelItem => item.EmailAddress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 63 "G:\Projects\Olympia\Olympia.Web.Site\Areas\Support\Views\Home\List.cshtml"
               Write(Html.DisplayFor(modelItem => item.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 66 "G:\Projects\Olympia\Olympia.Web.Site\Areas\Support\Views\Home\List.cshtml"
               Write(Html.DisplayFor(modelItem => item.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 69 "G:\Projects\Olympia\Olympia.Web.Site\Areas\Support\Views\Home\List.cshtml"
               Write(Html.DisplayFor(modelItem => item.CellNr));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 72 "G:\Projects\Olympia\Olympia.Web.Site\Areas\Support\Views\Home\List.cshtml"
               Write(Html.DisplayFor(modelItem => item.Subject));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 75 "G:\Projects\Olympia\Olympia.Web.Site\Areas\Support\Views\Home\List.cshtml"
               Write(Html.DisplayFor(modelItem => item.Content));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 78 "G:\Projects\Olympia\Olympia.Web.Site\Areas\Support\Views\Home\List.cshtml"
               Write(Html.DisplayFor(modelItem => item.Priority));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 81 "G:\Projects\Olympia\Olympia.Web.Site\Areas\Support\Views\Home\List.cshtml"
               Write(Html.DisplayFor(modelItem => item.TicketStatus));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    <a asp-action=\"Details\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 2806, "\"", 2829, 1);
#nullable restore
#line 84 "G:\Projects\Olympia\Olympia.Web.Site\Areas\Support\Views\Home\List.cshtml"
WriteAttributeValue("", 2821, item.Id, 2821, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"padding-right:10px\" class=\"btn btn-primary btn-circle\">Reply</a>\r\n                    <a asp-action=\"Details\"");
            BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 2947, "\"", 2970, 1);
#nullable restore
#line 85 "G:\Projects\Olympia\Olympia.Web.Site\Areas\Support\Views\Home\List.cshtml"
WriteAttributeValue("", 2962, item.Id, 2962, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"padding-right: 10px\" class=\"btn btn-primary btn-circle\"><i class=\"fa fa-eye\"></i></a>\r\n                    <a href=\"javascript:;\"");
            BeginWriteAttribute("onclick", " onclick=\"", 3108, "\"", 3145, 3);
            WriteAttributeValue("", 3118, "ShowDeleteModal(\'", 3118, 17, true);
#nullable restore
#line 86 "G:\Projects\Olympia\Olympia.Web.Site\Areas\Support\Views\Home\List.cshtml"
WriteAttributeValue("", 3135, item.Id, 3135, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3143, "\')", 3143, 2, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger btn-circle\"><i class=\"fa fa-trash\"></i></a>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 89 "G:\Projects\Olympia\Olympia.Web.Site\Areas\Support\Views\Home\List.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script type=""text/javascript"">

        function ShowDeleteModal(ff) {

            var url = ""/Support/Home/Delete?id="" + ff;

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SupportTicket>> Html { get; private set; }
    }
}
#pragma warning restore 1591
