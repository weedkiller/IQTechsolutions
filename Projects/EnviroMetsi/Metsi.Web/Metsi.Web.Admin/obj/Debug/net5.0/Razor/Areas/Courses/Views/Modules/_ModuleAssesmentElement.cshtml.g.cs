#pragma checksum "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Courses\Views\Modules\_ModuleAssesmentElement.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "313095ff02e79aa79fb411f496cec522c2e62184"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Courses_Views_Modules__ModuleAssesmentElement), @"mvc.1.0.view", @"/Areas/Courses/Views/Modules/_ModuleAssesmentElement.cshtml")]
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
#line 1 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Courses\Views\_ViewImports.cshtml"
using Iqt.Base.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Courses\Views\_ViewImports.cshtml"
using Iqt.Base.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Courses\Views\_ViewImports.cshtml"
using Education.Base.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Courses\Views\_ViewImports.cshtml"
using Grouping.Core.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Courses\Views\_ViewImports.cshtml"
using Education.Core.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Courses\Views\_ViewImports.cshtml"
using Grouping.Base.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Courses\Views\_ViewImports.cshtml"
using Filing.Base.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Courses\Views\_ViewImports.cshtml"
using Filing.Base.Extensions;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"313095ff02e79aa79fb411f496cec522c2e62184", @"/Areas/Courses/Views/Modules/_ModuleAssesmentElement.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23f27f861f79c5293781ad11ed0e01a4ad343231", @"/Areas/Courses/Views/_ViewImports.cshtml")]
    public class Areas_Courses_Views_Modules__ModuleAssesmentElement : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FormElement<Module>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<div class=\"col-md-10\">\r\n    <div class=\"form-group\">\r\n        ");
#nullable restore
#line 6 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Courses\Views\Modules\_ModuleAssesmentElement.cshtml"
   Write(Model.ElementName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>\r\n<div class=\"col-md-2\">\r\n    <a href=\"javascript:;\"");
            BeginWriteAttribute("onclick", " onclick=\"", 185, "\"", 238, 3);
            WriteAttributeValue("", 195, "ShowEditAssessmentElementModel(\'", 195, 32, true);
#nullable restore
#line 10 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Courses\Views\Modules\_ModuleAssesmentElement.cshtml"
WriteAttributeValue("", 227, Model.Id, 227, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 236, "\')", 236, 2, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary btn-xs btn-circle\"><i class=\"fa fa-edit\"></i></a>\r\n    <a href=\"javascript:;\"");
            BeginWriteAttribute("onclick", " onclick=\"", 340, "\"", 388, 3);
            WriteAttributeValue("", 350, "ShowDeleteAssessmentModal(\'", 350, 27, true);
#nullable restore
#line 11 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Courses\Views\Modules\_ModuleAssesmentElement.cshtml"
WriteAttributeValue("", 377, Model.Id, 377, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 386, "\')", 386, 2, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger btn-xs btn-circle\"><i class=\"fa fa-trash\"></i></a> \r\n    <a href=\"javascript:;\"");
            BeginWriteAttribute("onclick", " onclick=\"", 491, "\"", 545, 3);
            WriteAttributeValue("", 501, "ShowViewAssessmentElementsModal(\'", 501, 33, true);
#nullable restore
#line 12 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Courses\Views\Modules\_ModuleAssesmentElement.cshtml"
WriteAttributeValue("", 534, Model.Id, 534, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 543, "\')", 543, 2, true);
            EndWriteAttribute();
            WriteLiteral(@" class=""btn btn-info btn-xs"">View Answers </a>
</div>

<script>
    function ShowEditAssessmentElementModel(ff) {

        var url = ""/Courses/Modules/EditAssessmentElement?id="" + ff;

        $(""#ModalPlaceHolder"").load(url,
            function () {
                $(""#ModalPlaceHolder"").modal(""show"");
            });
    }

    function ShowDeleteAssessmentModal(id) {

        var url = ""/Courses/Modules/DeleteAssessmentElement?id="" + studentId;

        $(""#ModalPlaceHolder"").load(url,
            function () {
                $(""#ModalPlaceHolder"").modal(""show"");
            });
    }

    function ShowViewAssessmentElementsModal(id) {

        var url = ""/Courses/Modules/ViewModuleAssessmentElementAnswers?parentId="" + id;

        $(""#ModalPlaceHolder"").load(url,
            function () {
                $(""#ModalPlaceHolder"").modal(""show"");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FormElement<Module>> Html { get; private set; }
    }
}
#pragma warning restore 1591
