#pragma checksum "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Views\Shared\Modals\_CropModal.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "98b2a8b6f42913cdef64d5f98aac7317c08a1d3e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Modals__CropModal), @"mvc.1.0.view", @"/Views/Shared/Modals/_CropModal.cshtml")]
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
#line 1 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Views\_ViewImports.cshtml"
using Olympia.Web.Site;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Views\_ViewImports.cshtml"
using Olympia.Web.Site.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"98b2a8b6f42913cdef64d5f98aac7317c08a1d3e", @"/Views/Shared/Modals/_CropModal.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ae93721a468c7c27a84c309b942fba5fba6da670", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Modals__CropModal : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Iqt.Base.Models.CropModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/cropper-master/dist/cropper.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("<!-- Modal -->\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "98b2a8b6f42913cdef64d5f98aac7317c08a1d3e3991", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<script type=""text/javascript"" src=""/js/cropper-master/dist/cropper.js""></script>

<style>
    img {
        display: block;
        /* This rule is very important, please don't ignore this */
        max-width: 100%;
    }
</style>

<div class=""modal-dialog modal-dialog-centered modal-lg"">
    <div class=""modal-content"">
        <div class=""modal-header"">
            <h4 class=""modal-title"">Please confirm this action!</h4>
            <button type=""button"" class=""close"" data-dismiss=""modal"">
                <span aria-hidden=""true"">??</span>
                <span class=""sr-only"">close</span>
            </button>
        </div>
        <div class=""modal-body"">
            <div class=""row"">

                <div class=""col-xs-12"">

                    <div>
                        <img id=""image"" alt=""Image To Crop""");
            BeginWriteAttribute("src", " src=\"", 974, "\"", 999, 1);
#nullable restore
#line 30 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Views\Shared\Modals\_CropModal.cshtml"
WriteAttributeValue("", 980, Model.CropImageUrl, 980, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
                    </div>
                    <div style=""text-align: center"">
                    </div>
                </div>
            </div>

        </div>
        <div class=""modal-footer"">
            <a href=""javascript:;"" class=""btn btn-sm btn-white"" onclick=""ConfirmDelete()"">Cancel</a>
            <a href=""javascript:;"" data-dismiss=""modal"" class=""btn btn-sm btn-primary"">Accept</a>
        </div>
    </div>
</div>

<script type=""text/javascript"">
    $(function () {
        var $image = $('#image');
        $image.cropper({
            viewMode: 0,
            aspectRatio:parseInt(");
#nullable restore
#line 50 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Views\Shared\Modals\_CropModal.cshtml"
                            Write(Model.MinWidth);

#line default
#line hidden
#nullable disable
            WriteLiteral(")/parseInt(");
#nullable restore
#line 50 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Views\Shared\Modals\_CropModal.cshtml"
                                                      Write(Model.MinHeight);

#line default
#line hidden
#nullable disable
            WriteLiteral("),\r\n            dragMode: \'move\',\r\n            responsive: true,\r\n            center: true,\r\n            preview:\'.");
#nullable restore
#line 54 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Views\Shared\Modals\_CropModal.cshtml"
                 Write(Model.PreviewClass);

#line default
#line hidden
#nullable disable
            WriteLiteral("\',\r\n            background: true,\r\n            minContainerWidth: parseInt(");
#nullable restore
#line 56 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Views\Shared\Modals\_CropModal.cshtml"
                                   Write(Model.MinWidth);

#line default
#line hidden
#nullable disable
            WriteLiteral("),\r\n                minContainerHeight: parseInt(");
#nullable restore
#line 57 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Views\Shared\Modals\_CropModal.cshtml"
                                        Write(Model.MinHeight);

#line default
#line hidden
#nullable disable
            WriteLiteral("),\r\n            crop: function (event) {\r\n\r\n                document.getElementById(\'");
#nullable restore
#line 60 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Views\Shared\Modals\_CropModal.cshtml"
                                    Write(Model.XTag);

#line default
#line hidden
#nullable disable
            WriteLiteral("\').value = Math.round(event.detail.x);\r\n                document.getElementById(\'");
#nullable restore
#line 61 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Views\Shared\Modals\_CropModal.cshtml"
                                    Write(Model.YTag);

#line default
#line hidden
#nullable disable
            WriteLiteral("\').value = Math.round(event.detail.y);\r\n                document.getElementById(\'");
#nullable restore
#line 62 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Views\Shared\Modals\_CropModal.cshtml"
                                    Write(Model.WidthTag);

#line default
#line hidden
#nullable disable
            WriteLiteral("\').value = Math.round(event.detail.width);\r\n                document.getElementById(\'");
#nullable restore
#line 63 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Views\Shared\Modals\_CropModal.cshtml"
                                    Write(Model.HeightTag);

#line default
#line hidden
#nullable disable
            WriteLiteral("\').value = Math.round(event.detail.height);\r\n                document.getElementById(\'");
#nullable restore
#line 64 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Views\Shared\Modals\_CropModal.cshtml"
                                    Write(Model.RotateTag);

#line default
#line hidden
#nullable disable
            WriteLiteral("\').value = Math.round(event.detail.rotate);\r\n                document.getElementById(\'");
#nullable restore
#line 65 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Views\Shared\Modals\_CropModal.cshtml"
                                    Write(Model.ScaleXTag);

#line default
#line hidden
#nullable disable
            WriteLiteral("\').value = Math.round(event.detail.scaleX);\r\n                document.getElementById(\'");
#nullable restore
#line 66 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Views\Shared\Modals\_CropModal.cshtml"
                                    Write(Model.ScaleYTag);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"').value = Math.round(event.detail.scaleY);

                console.log(Math.round(event.detail.x));
                console.log(Math.round(event.detail.y));
                console.log(Math.round(event.detail.width));
                console.log(Math.round(event.detail.height));
                console.log(Math.round(event.detail.rotate));
                console.log(Math.round(event.detail.scaleX));
                console.log(Math.round(event.detail.scaleY));
            }
        });
    });

    function ConfirmDelete() {

        var output = $('.");
#nullable restore
#line 81 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Views\Shared\Modals\_CropModal.cshtml"
                    Write(Model.PreviewClass);

#line default
#line hidden
#nullable disable
            WriteLiteral("\');\r\n        output.html(\'<img id=\"preview\" style=\"width: 100%\" src=\"");
#nullable restore
#line 82 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Views\Shared\Modals\_CropModal.cshtml"
                                                           Write(Model.OriginalImageUrl);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" alt=\"\" />\');\r\n\r\n        document.getElementById(\'CoverUpload\').value = \'\';\r\n\r\n        $(\"#CropModal\").modal(\"hide\");\r\n    }\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Iqt.Base.Models.CropModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
