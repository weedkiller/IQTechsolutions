#pragma checksum "C:\Users\Admin\Desktop\New\IQTechsolutions\Julius\Olympia\Olympia.Web.Site\Views\Shared\Modals\_DeleteObjectModal.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2c666e4b59d55d5354b1a739d2cf3390991f2d9b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Modals__DeleteObjectModal), @"mvc.1.0.view", @"/Views/Shared/Modals/_DeleteObjectModal.cshtml")]
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
#line 1 "C:\Users\Admin\Desktop\New\IQTechsolutions\Julius\Olympia\Olympia.Web.Site\Views\_ViewImports.cshtml"
using Olympia.Web.Site;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Admin\Desktop\New\IQTechsolutions\Julius\Olympia\Olympia.Web.Site\Views\_ViewImports.cshtml"
using Olympia.Web.Site.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2c666e4b59d55d5354b1a739d2cf3390991f2d9b", @"/Views/Shared/Modals/_DeleteObjectModal.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3e3f5e902106facae93394b50c812629d9967e46", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Modals__DeleteObjectModal : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Iqt.Base.Models.ModalModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/loader2.gif"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<!-- Modal -->

<div class=""modal-dialog"">
    <div class=""modal-content"">
        <div class=""modal-header"">
            <button type=""button"" class=""close"" data-dismiss=""modal"" aria-hidden=""true"">×</button>
            <h4 class=""modal-title"">Delete Contact Nr</h4>
        </div>
        <div class=""modal-body"">
            <h4> ");
#nullable restore
#line 11 "C:\Users\Admin\Desktop\New\IQTechsolutions\Julius\Olympia\Olympia.Web.Site\Views\Shared\Modals\_DeleteObjectModal.cshtml"
            Write(Model.HeaderString);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h4>\r\n\r\n            <div style=\"text-align: center; display: none\" id=\"loaderDiv\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "2c666e4b59d55d5354b1a739d2cf3390991f2d9b4391", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            </div>

        </div>
        <div class=""modal-footer"">
            <a href=""javascript:;"" class=""btn btn-sm btn-white"" data-dismiss=""modal"">Close</a>
            <a href=""javascript:;"" onclick=""ConfirmDelete()"" class=""btn btn-sm btn-primary"">Delete</a>
        </div>
    </div>
</div>

<script>
    function ConfirmDelete() {

        $(""#loaderDiv"").show();

        var param = JSON.stringify('");
#nullable restore
#line 30 "C:\Users\Admin\Desktop\New\IQTechsolutions\Julius\Olympia\Olympia.Web.Site\Views\Shared\Modals\_DeleteObjectModal.cshtml"
                               Write(Model.Parameters);

#line default
#line hidden
#nullable disable
            WriteLiteral("\');\r\n        var url = \'");
#nullable restore
#line 31 "C:\Users\Admin\Desktop\New\IQTechsolutions\Julius\Olympia\Olympia.Web.Site\Views\Shared\Modals\_DeleteObjectModal.cshtml"
              Write(Model.ControllerUrl);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"';

        alert(param);

        $.ajax({
            type: ""POST"",
            data: param,
            contentType: ""application/x-www-form-urlencoded"",
            datatype:""text"",
            url: url,
            success: function (data) {

                $(""#ModalPlaceHolder"").modal(""hide"");
                $(""#loaderDiv"").hide();

                //$("".row_"" + categoryId).remove();
            },
            error: function (xhr, textStatus, err) {
                alert(""An error with the following detials occured : ""
                    + ""\r\n == readyState: "" + xhr.readyState
                    + ""\r\n == responseText: "" + xhr.responseText
                    + ""\r\n == status: "" + xhr.status
                    + ""\r\n == text status: "" + textStatus
                    + ""\r\n == error: "" + err);
                $(""#loaderDiv"").hide();
            }
        });
    }
</script>");
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
