#pragma checksum "G:\IQTechSolutions\Julius\Olympia\Olympia.Web.Site\Areas\Employees\Views\Home\_CreateEmailAddress.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1950eaf578754c9023ec02990300c7c6286e6a4d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Employees_Views_Home__CreateEmailAddress), @"mvc.1.0.view", @"/Areas/Employees/Views/Home/_CreateEmailAddress.cshtml")]
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
#line 1 "G:\IQTechSolutions\Julius\Olympia\Olympia.Web.Site\Areas\Employees\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Html;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "G:\IQTechSolutions\Julius\Olympia\Olympia.Web.Site\Areas\Employees\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "G:\IQTechSolutions\Julius\Olympia\Olympia.Web.Site\Areas\Employees\Views\_ViewImports.cshtml"
using Iqt.Base.Interfaces;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "G:\IQTechSolutions\Julius\Olympia\Olympia.Web.Site\Areas\Employees\Views\_ViewImports.cshtml"
using Iqt.Base.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "G:\IQTechSolutions\Julius\Olympia\Olympia.Web.Site\Areas\Employees\Views\_ViewImports.cshtml"
using Filing.Base.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "G:\IQTechSolutions\Julius\Olympia\Olympia.Web.Site\Areas\Employees\Views\_ViewImports.cshtml"
using Filing.Base.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "G:\IQTechSolutions\Julius\Olympia\Olympia.Web.Site\Areas\Employees\Views\_ViewImports.cshtml"
using Employment.Base.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "G:\IQTechSolutions\Julius\Olympia\Olympia.Web.Site\Areas\Employees\Views\_ViewImports.cshtml"
using Employment.Core.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "G:\IQTechSolutions\Julius\Olympia\Olympia.Web.Site\Areas\Employees\Views\_ViewImports.cshtml"
using Iqt.Base.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1950eaf578754c9023ec02990300c7c6286e6a4d", @"/Areas/Employees/Views/Home/_CreateEmailAddress.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5567c7d8e262dcfaa28147fe687e6dc99cbeb6de", @"/Areas/Employees/Views/_ViewImports.cshtml")]
    public class Areas_Employees_Views_Home__CreateEmailAddress : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Iqt.Base.Entities.EmailAddress<Employee>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("control-label"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("CreateEmailAddressForm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div class=""modal-dialog"">
    <div class=""modal-content"">
        <div class=""modal-header"">
            <h4 class=""modal-title"">Add Email Address</h4>
            <button type=""button"" class=""close"" data-dismiss=""modal"" aria-hidden=""true"">×</button>
        </div>
        <div class=""modal-body"">
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1950eaf578754c9023ec02990300c7c6286e6a4d7332", async() => {
                WriteLiteral("\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1950eaf578754c9023ec02990300c7c6286e6a4d7606", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 11 "G:\IQTechSolutions\Julius\Olympia\Olympia.Web.Site\Areas\Employees\Views\Home\_CreateEmailAddress.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Id);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1950eaf578754c9023ec02990300c7c6286e6a4d9344", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 12 "G:\IQTechSolutions\Julius\Olympia\Olympia.Web.Site\Areas\Employees\Views\Home\_CreateEmailAddress.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.EntityId);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                <div class=\"form-group\">\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1950eaf578754c9023ec02990300c7c6286e6a4d11138", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#nullable restore
#line 14 "G:\IQTechSolutions\Julius\Olympia\Olympia.Web.Site\Areas\Employees\Views\Home\_CreateEmailAddress.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Address);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1950eaf578754c9023ec02990300c7c6286e6a4d12763", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 15 "G:\IQTechSolutions\Julius\Olympia\Olympia.Web.Site\Areas\Employees\Views\Home\_CreateEmailAddress.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Address);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1950eaf578754c9023ec02990300c7c6286e6a4d14382", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
#nullable restore
#line 16 "G:\IQTechSolutions\Julius\Olympia\Olympia.Web.Site\Areas\Employees\Views\Home\_CreateEmailAddress.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Address);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    <div class=\"checkbox\">\r\n                        <label>\r\n                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1950eaf578754c9023ec02990300c7c6286e6a4d16240", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 21 "G:\IQTechSolutions\Julius\Olympia\Olympia.Web.Site\Areas\Employees\Views\Home\_CreateEmailAddress.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Default);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(" ");
#nullable restore
#line 21 "G:\IQTechSolutions\Julius\Olympia\Olympia.Web.Site\Areas\Employees\Views\Home\_CreateEmailAddress.cshtml"
                                                   Write(Html.DisplayNameFor(model => model.Default));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </label>\r\n                    </div>\r\n                </div>\r\n            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
        </div>
        <div class=""modal-footer"">
            <a href=""javascript:;"" class=""btn btn-sm btn-white"" data-dismiss=""modal"">Close</a>
            <a href=""javascript:;"" onclick=""ConfirmEmailAddress()"" class=""btn btn-sm btn-primary"">Submit & Add</a>
        </div>
    </div>
</div>

<script>

    function ConfirmEmailAddress() {

        var myformdata = $(""#CreateEmailAddressForm"").serialize();
        var url = """);
#nullable restore
#line 39 "G:\IQTechSolutions\Julius\Olympia\Olympia.Web.Site\Areas\Employees\Views\Home\_CreateEmailAddress.cshtml"
              Write(Url.Action("CreateEmailAddress", "Home", new {area="Employees"}));

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

                var tableBody = document.getElementById(""emailAddressTableBody"");

                var tableRow = document.createElement(""tr"");

                var tableAddressColumn = document.createElement(""td"");
                var tableAddressDefaultColumn = document.createElement(""td"");
                var tableAddressButtonColumn = document.createElement(""td"");

                var defaultIcon = document.createElement(""i"");

                var tableAddressEditButton = document.createElement(""a"");
                var tableAddressDeleteButton = document.createElement(""a"");

                var tableAddressEditButtonIcon = document.createElement(""i"");
                var tableAddressDeleteButtonIcon = document.createElement(""i"");


                tableBody.append(tableRow);
           ");
            WriteLiteral(@"     tableRow.append(tableAddressColumn);
                tableRow.append(tableAddressDefaultColumn);
                tableRow.append(tableAddressDefaultColumn);
                tableRow.append(tableAddressButtonColumn);
                tableAddressDefaultColumn.append(defaultIcon);
                tableAddressButtonColumn.append(tableAddressEditButton);
                tableAddressEditButton.append(tableAddressEditButtonIcon);
                tableAddressButtonColumn.append(tableAddressDeleteButton);
                tableAddressDeleteButton.append(tableAddressDeleteButtonIcon);


                tableRow.id = ""row_"" + data.id;
                tableRow.classList.add(""row_"" + data.id);

                tableAddressColumn.id = ""emailAddress_"" + data.id;
                tableAddressColumn.innerHTML = data.address;


                tableAddressColumn.id = ""emailDefault_"" + data.id;

                defaultIcon.classList.add(""fa"");
                if (data.defaultEntry) {
                   ");
            WriteLiteral(@" defaultIcon.classList.add(""fa-check"");
                } else {
                    defaultIcon.classList.add(""fa-close"");
                }

                tableAddressEditButton.href = ""javascript:;"";
                tableAddressEditButton.onclick = function () { ShowEditEmailAddressModel(data.id) };

                tableAddressEditButtonIcon.classList.add(""fa"", ""fa-edit"");

                tableAddressDeleteButton.href = ""javascript:;"";
                tableAddressDeleteButton.onclick = function () { ShowDeleteEmailAddressModel(data.id) };


                tableAddressDeleteButtonIcon.classList.add(""fa"", ""fa-trash"");
                tableAddressDeleteButtonIcon.style.paddingLeft = ""5px"";

                //var markup = ""<tr id='row_"" + data.id + "" class='row_"" + data.id + ""'>"" +
                //    ""<td>"" + data.address + ""</td> "" +
                //    ""<td></td> "" +
                //    ""<td>"" +
                //    ""<a href=\""javascript:;\"" onclick=\""ShowEditContactModal('""");
            WriteLiteral(@" + data.id + "","" + data.parentId + ""')\""><i class=\""fa fa-edit\"" style=\""padding-right: 5px;\""></i></a>"" +
                //    ""<a href=\""javascript:;\"" onclick=\""ShowDeleteContactModal('"" + data.id + ""')\""><i class=\""fa fa-trash\""></i></a> "" +
                //    ""</td>"" +
                //    ""</tr>"";


                $(""#EmailAddressList"").append(markup);

            },
            error: function (xhr, textStatus, err) {
                alert(""An error with the following detials occured : ""
                    + ""\r\n == readyState: "" + xhr.readyState
                    + ""\r\n == responseText: "" + xhr.responseText
                    + ""\r\n == status: "" + xhr.status
                    + ""\r\n == text status: "" + textStatus
                    + ""\r\n == error: "" + err);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Iqt.Base.Entities.EmailAddress<Employee>> Html { get; private set; }
    }
}
#pragma warning restore 1591
