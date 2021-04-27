#pragma checksum "G:\Projects\Olympia\Olympia.Web.Site\Areas\Customers\Views\Home\_EditContactNumber.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dc2072c057cbe386bd486dc7e94eb3bac5dfd871"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Customers_Views_Home__EditContactNumber), @"mvc.1.0.view", @"/Areas/Customers/Views/Home/_EditContactNumber.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dc2072c057cbe386bd486dc7e94eb3bac5dfd871", @"/Areas/Customers/Views/Home/_EditContactNumber.cshtml")]
    public class Areas_Customers_Views_Home__EditContactNumber : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ContactNumber<Customer>>
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
            WriteLiteral("\r\n<div class=\"modal-dialog\">\r\n    <div class=\"modal-content\">\r\n        <div class=\"modal-header\">\r\n            <h4 class=\"modal-title\">");
#nullable restore
#line 6 "G:\Projects\Olympia\Olympia.Web.Site\Areas\Customers\Views\Home\_EditContactNumber.cshtml"
                               Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h4>
            <button type=""button"" class=""close"" data-dismiss=""modal"" aria-hidden=""true"">×</button>
        </div>
        <div class=""modal-body"">
            <form id=""EditContactNrForm"">
                <input type=""hidden"" asp-for=""Id"" />
                <input type=""hidden"" asp-for=""EntityId"" />
                <div class=""form-group"">
                    <label asp-for=""Name"" class=""control-label""></label>
                    <input asp-for=""Name"" class=""form-control"" />
                    <span asp-validation-for=""Name"" class=""text-danger""></span>
                </div>
                <div class=""form-group"">
                    <label asp-for=""Number"" class=""control-label""></label>
                    <input asp-for=""Number"" class=""form-control"" />
                    <span asp-validation-for=""Number"" class=""text-danger""></span>
                </div>
                <div class=""form-group"">
                    <div class=""checkbox"">
                        <label>
         ");
            WriteLiteral("                   <input asp-for=\"Default\" /> ");
#nullable restore
#line 26 "G:\Projects\Olympia\Olympia.Web.Site\Areas\Customers\Views\Home\_EditContactNumber.cshtml"
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
            <a href=""javascript:;"" onclick=""ConfirmContactNumber55()"" class=""btn btn-sm btn-primary"">Submit</a>
        </div>
    </div>
</div>


    <script type=""text/javascript"">

        function ConfirmContactNumber55() {

            var myformdata = $(""#EditContactNrForm"").serialize();
            var url = """);
#nullable restore
#line 45 "G:\Projects\Olympia\Olympia.Web.Site\Areas\Customers\Views\Home\_EditContactNumber.cshtml"
                  Write(Url.Action("EditContactNumber", "Home", new { area= "Customers", personId = Model.EntityId}));

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

                    $(""#contactNr_"" + data.id).html(data.number);
                    if (data.defaultvalue) {
                        $(""#contactDefault_"" + data.id).html('<i class=""fa fa-check""></i>');
                    } else {
                        $(""#contactDefault_"" + data.id).html('<i class=""fa fa-close""></i>');
                    } 

                },
                error: function (xhr, textStatus, err) {
                    alert(""An error with the following detials occured : ""
                        + ""\r\n == readyState: "" + xhr.readyState
                        + ""\r\n == responseText: "" + xhr.responseText
                        + ""\r\n == status: "" + xhr.status
                        + ""\r\n == text status: "" + textStatus
                        ");
            WriteLiteral(@"+ ""\r\n == error: "" + err);
                }
            });
        }
    </script>

    <script>
        var loadFile = function (event) {
            var output = document.getElementById('preview');
            output.src = URL.createObjectURL(event.target.files[0]);
        };
    </script>

    <!-- Summer Note JS -->
    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dc2072c057cbe386bd486dc7e94eb3bac5dfd8718008", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dc2072c057cbe386bd486dc7e94eb3bac5dfd8719055", async() => {
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
            WriteLiteral("\r\n        \r\n    \r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ContactNumber<Customer>> Html { get; private set; }
    }
}
#pragma warning restore 1591
