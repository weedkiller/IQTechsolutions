#pragma checksum "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\Modals\_PleaeSaveFirstModal.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a9dd03805a387b0854b75b67f5fbc1554ff915fa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Modals__PleaeSaveFirstModal), @"mvc.1.0.view", @"/Views/Shared/Modals/_PleaeSaveFirstModal.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a9dd03805a387b0854b75b67f5fbc1554ff915fa", @"/Views/Shared/Modals/_PleaeSaveFirstModal.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"58acc36c7c6b2cabb3fe2c504456252e879f0d65", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Modals__PleaeSaveFirstModal : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Iqt.Base.Models.ModalModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<!-- Modal -->

<div class=""modal-dialog"">
    <div class=""modal-content"">
        <div class=""modal-header"">
            <h4 class=""modal-title"">Please Save First</h4>
            <button type=""button"" class=""close"" data-dismiss=""modal"" aria-hidden=""true"">×</button>
        </div>
        <div class=""modal-body"">
            <h4> ");
#nullable restore
#line 11 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\Modals\_PleaeSaveFirstModal.cshtml"
            Write(Model.HeaderString);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h4>\r\n        </div>\r\n        <div class=\"modal-footer\">\r\n            <a href=\"javascript:;\" class=\"btn btn-sm btn-white\" data-dismiss=\"modal\">Close</a>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Iqt.Base.Models.ModalModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
