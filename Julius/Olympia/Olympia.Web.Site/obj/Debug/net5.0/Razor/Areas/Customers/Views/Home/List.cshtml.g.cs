#pragma checksum "C:\Users\Admin\Desktop\New\IQTechsolutions\Julius\Olympia\Olympia.Web.Site\Areas\Customers\Views\Home\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cc6f2d95e8f9f3e47b8ce36d2a712e7bfc453114"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Customers_Views_Home_List), @"mvc.1.0.view", @"/Areas/Customers/Views/Home/List.cshtml")]
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
#line 1 "C:\Users\Admin\Desktop\New\IQTechsolutions\Julius\Olympia\Olympia.Web.Site\Areas\Customers\Views\_ViewImports.cshtml"
using Customers.Base.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Admin\Desktop\New\IQTechsolutions\Julius\Olympia\Olympia.Web.Site\Areas\Customers\Views\_ViewImports.cshtml"
using Filing.Base.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Admin\Desktop\New\IQTechsolutions\Julius\Olympia\Olympia.Web.Site\Areas\Customers\Views\_ViewImports.cshtml"
using Filing.Base.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Admin\Desktop\New\IQTechsolutions\Julius\Olympia\Olympia.Web.Site\Areas\Customers\Views\_ViewImports.cshtml"
using Microsoft.Extensions.Options;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Admin\Desktop\New\IQTechsolutions\Julius\Olympia\Olympia.Web.Site\Areas\Customers\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Admin\Desktop\New\IQTechsolutions\Julius\Olympia\Olympia.Web.Site\Areas\Customers\Views\_ViewImports.cshtml"
using Iqt.Base.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc6f2d95e8f9f3e47b8ce36d2a712e7bfc453114", @"/Areas/Customers/Views/Home/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5b4344ad37c60a309e9ab4ecd4b952f841d2fb10", @"/Areas/Customers/Views/_ViewImports.cshtml")]
    public class Areas_Customers_Views_Home_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Customer>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary btn-circle btn-xs"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Customers", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 3 "C:\Users\Admin\Desktop\New\IQTechsolutions\Julius\Olympia\Olympia.Web.Site\Areas\Customers\Views\Home\List.cshtml"
  
    ViewData["Title"] = "Customer List";

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
#line 24 "C:\Users\Admin\Desktop\New\IQTechsolutions\Julius\Olympia\Olympia.Web.Site\Areas\Customers\Views\Home\List.cshtml"
               Write(Html.DisplayNameFor(model => model.Featured));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th></th>\r\n            </tr>\r\n            </thead>\r\n            <tbody>\r\n");
#nullable restore
#line 30 "C:\Users\Admin\Desktop\New\IQTechsolutions\Julius\Olympia\Olympia.Web.Site\Areas\Customers\Views\Home\List.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr");
            BeginWriteAttribute("id", " id=\"", 799, "\"", 816, 2);
            WriteAttributeValue("", 804, "row_", 804, 4, true);
#nullable restore
#line 32 "C:\Users\Admin\Desktop\New\IQTechsolutions\Julius\Olympia\Olympia.Web.Site\Areas\Customers\Views\Home\List.cshtml"
WriteAttributeValue("", 808, item.Id, 808, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("class", " class=\"", 817, "\"", 837, 2);
            WriteAttributeValue("", 825, "row_", 825, 4, true);
#nullable restore
#line 32 "C:\Users\Admin\Desktop\New\IQTechsolutions\Julius\Olympia\Olympia.Web.Site\Areas\Customers\Views\Home\List.cshtml"
WriteAttributeValue("", 829, item.Id, 829, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <td>\r\n                        <img style=\"width:100px\" id=\"preview\" class=\"img-thumbnail\"");
            BeginWriteAttribute("title", " title=\"", 950, "\"", 968, 1);
#nullable restore
#line 34 "C:\Users\Admin\Desktop\New\IQTechsolutions\Julius\Olympia\Olympia.Web.Site\Areas\Customers\Views\Home\List.cshtml"
WriteAttributeValue("", 958, item.Name, 958, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 969, "\"", 1001, 1);
#nullable restore
#line 34 "C:\Users\Admin\Desktop\New\IQTechsolutions\Julius\Olympia\Olympia.Web.Site\Areas\Customers\Views\Home\List.cshtml"
WriteAttributeValue("", 975, item.GetImage()?.FileName, 975, 26, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("src", " src=\"", 1002, "\"", 1115, 1);
#nullable restore
#line 34 "C:\Users\Admin\Desktop\New\IQTechsolutions\Julius\Olympia\Olympia.Web.Site\Areas\Customers\Views\Home\List.cshtml"
WriteAttributeValue("", 1008, item.GetPath("http://admin.metsi.co.za", ImageType.Cover, "/images/placeholders/profileImage128x128.png" ), 1008, 107, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 37 "C:\Users\Admin\Desktop\New\IQTechsolutions\Julius\Olympia\Olympia.Web.Site\Areas\Customers\Views\Home\List.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 40 "C:\Users\Admin\Desktop\New\IQTechsolutions\Julius\Olympia\Olympia.Web.Site\Areas\Customers\Views\Home\List.cshtml"
                   Write(item.ContactNumbers.FirstOrDefault(c => c.Default)?.Number);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 43 "C:\Users\Admin\Desktop\New\IQTechsolutions\Julius\Olympia\Olympia.Web.Site\Areas\Customers\Views\Home\List.cshtml"
                   Write(item.EmailAddresses.FirstOrDefault(c => c.Default)?.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 46 "C:\Users\Admin\Desktop\New\IQTechsolutions\Julius\Olympia\Olympia.Web.Site\Areas\Customers\Views\Home\List.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Featured));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td style=\"width: 100px\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cc6f2d95e8f9f3e47b8ce36d2a712e7bfc45311411511", async() => {
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
#line 49 "C:\Users\Admin\Desktop\New\IQTechsolutions\Julius\Olympia\Olympia.Web.Site\Areas\Customers\Views\Home\List.cshtml"
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
            BeginWriteAttribute("onclick", " onclick=\"", 1901, "\"", 1938, 3);
            WriteAttributeValue("", 1911, "ShowDeleteModal(\'", 1911, 17, true);
#nullable restore
#line 50 "C:\Users\Admin\Desktop\New\IQTechsolutions\Julius\Olympia\Olympia.Web.Site\Areas\Customers\Views\Home\List.cshtml"
WriteAttributeValue("", 1928, item.Id, 1928, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1936, "\')", 1936, 2, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger btn-circle btn-xs\"><i class=\"fa fa-trash\"></i></a>\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 53 "C:\Users\Admin\Desktop\New\IQTechsolutions\Julius\Olympia\Olympia.Web.Site\Areas\Customers\Views\Home\List.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n            <tfoot>\r\n            <tr>\r\n                <td colspan=\"6\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cc6f2d95e8f9f3e47b8ce36d2a712e7bfc45311414903", async() => {
                WriteLiteral("Create New Customer");
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
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n            </tfoot>\r\n        </table>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        function ShowDeleteModal(ff) {
            var url = ""/Customers/Home/Delete?id="" + ff;

            $(""#ModalPlaceHolder"").load(url,
                function() {
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Customer>> Html { get; private set; }
    }
}
#pragma warning restore 1591
