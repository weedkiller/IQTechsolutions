#pragma checksum "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Faqs\Views\Categories\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cce8d64b2ad500f48efa52f6be6d0f7fe5761181"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Faqs_Views_Categories_List), @"mvc.1.0.view", @"/Areas/Faqs/Views/Categories/List.cshtml")]
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
#line 1 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Faqs\Views\_ViewImports.cshtml"
using Troubleshooting.Core.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Faqs\Views\_ViewImports.cshtml"
using Filing.Base.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Faqs\Views\_ViewImports.cshtml"
using Filing.Base.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Faqs\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Html;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Faqs\Views\_ViewImports.cshtml"
using Grouping.Base.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Faqs\Views\_ViewImports.cshtml"
using Troubleshooting.Base.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Faqs\Views\_ViewImports.cshtml"
using Iqt.Base.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Faqs\Views\_ViewImports.cshtml"
using Grouping.Core.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Faqs\Views\Categories\List.cshtml"
using Troubleshooting.Core.ViewComponents;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cce8d64b2ad500f48efa52f6be6d0f7fe5761181", @"/Areas/Faqs/Views/Categories/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"76bb46a86354a45673c0b2db52f26633c552a25b", @"/Areas/Faqs/Views/_ViewImports.cshtml")]
    public class Areas_Faqs_Views_Categories_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Category<Question>>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Faqs\Views\Categories\List.cshtml"
  
    ViewData["Title"] = "FAQ Category List";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 8 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Faqs\Views\Categories\List.cshtml"
Write(await Component.InvokeAsync(nameof(FaqCategoryList)));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script type=""text/javascript"">

        function ShowDeleteModal(ff) {

            var url = ""/Faqs/Categories/Delete?id="" + ff;

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Category<Question>>> Html { get; private set; }
    }
}
#pragma warning restore 1591
