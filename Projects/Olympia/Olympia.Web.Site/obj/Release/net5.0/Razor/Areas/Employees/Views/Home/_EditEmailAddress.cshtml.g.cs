#pragma checksum "G:\Projects\Olympia\Olympia.Web.Site\Areas\Employees\Views\Home\_EditEmailAddress.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f48d995d2665dba42018278392880e1d69a83075"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Employees_Views_Home__EditEmailAddress), @"mvc.1.0.view", @"/Areas/Employees/Views/Home/_EditEmailAddress.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f48d995d2665dba42018278392880e1d69a83075", @"/Areas/Employees/Views/Home/_EditEmailAddress.cshtml")]
    public class Areas_Employees_Views_Home__EditEmailAddress : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Iqt.Base.Entities.EmailAddress<Employee>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/summernote/summernote.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/bs-filestyle.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral(@"
<div class=""modal-dialog"">
    <div class=""modal-content"">
        <div class=""modal-header"">
            <h4 class=""modal-title"">Edit Email Address</h4>
            <button type=""button"" class=""close"" data-dismiss=""modal"" aria-hidden=""true"">×</button>
        </div>
        <div class=""modal-body"">
            <form id=""CreateEmailAddressForm"">
                <input type=""hidden"" asp-for=""Id"" />
                <input type=""hidden"" asp-for=""EntityId"" />
                <div class=""form-group"">
                    <label asp-for=""Address"" class=""control-label""></label>
                    <input asp-for=""Address"" class=""form-control"" />
                    <span asp-validation-for=""Address"" class=""text-danger""></span>
                </div>
                <div class=""form-group"">
                    <div class=""checkbox"">
                        <label>
                            <input asp-for=""Default"" /> ");
#nullable restore
#line 21 "G:\Projects\Olympia\Olympia.Web.Site\Areas\Employees\Views\Home\_EditEmailAddress.cshtml"
                                                   Write(Html.DisplayNameFor(model => model.Default));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </label>
                    </div>
                </div>
            </form>
        </div>
        <div class=""modal-footer"">
            <a href=""javascript:;"" class=""btn btn-sm btn-white"" data-dismiss=""modal"">Close</a>
            <a href=""javascript:;"" onclick=""ConfirmContactNumber()"" class=""btn btn-sm btn-primary"">Submit & Add</a>
        </div>
    </div>
</div>

    <script>
        var loadFile = function (event) {
            var output = document.getElementById('preview');
            output.src = URL.createObjectURL(event.target.files[0]);
        };
    </script>

    <!-- Summer Note JS -->
    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f48d995d2665dba42018278392880e1d69a830755765", async() => {
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
            WriteLiteral("\r\n\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f48d995d2665dba42018278392880e1d69a830756812", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        \r\n    <script>\r\n\r\n        function ConfirmContactNumber() {\r\n\r\n            var myformdata = $(\"#CreateEmailAddressForm\").serialize();\r\n            var url = \"");
#nullable restore
#line 51 "G:\Projects\Olympia\Olympia.Web.Site\Areas\Employees\Views\Home\_EditEmailAddress.cshtml"
                  Write(Url.Action("EditEmailAddress", "Home", new {area="Employees"}));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""";

            $.ajax({
                type: ""POST"",
                data: myformdata,
                url: url,
                success: function (data) {

                    $(""#ModalPlaceHolder"").modal(""hide"");

                    $(""#emailAddress_"" + data.id).html(data.address);
                    if (data.defaultvalue) {
                        $(""#emailDefault_"" + data.id).html('<i class=""fa fa-check""></i>');
                    } else {
                        $(""#emailDefault_"" + data.id).html('<i class=""fa fa-close""></i>');
                    } 

                },
                error: function (xhr, textStatus, err) {
                    alert(""An error with the following detials occured : ""
                        + ""\r\n == readyState: "" + xhr.readyState
                        + ""\r\n == responseText: "" + xhr.responseText
                        + ""\r\n == status: "" + xhr.status
                        + ""\r\n == text status: "" + textStatus
                        ");
            WriteLiteral("+ \"\\r\\n == error: \" + err);\r\n                }\r\n            });\r\n        }\r\n    </script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Iqt.Base.Entities.EmailAddress<Employee>> Html { get; private set; }
    }
}
#pragma warning restore 1591
