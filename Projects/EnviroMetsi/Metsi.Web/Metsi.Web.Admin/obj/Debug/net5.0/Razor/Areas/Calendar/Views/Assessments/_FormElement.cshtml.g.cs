#pragma checksum "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Calendar\Views\Assessments\_FormElement.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "56cb464a7ef26ab37ae62689fb0b956e6e168e10"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Calendar_Views_Assessments__FormElement), @"mvc.1.0.view", @"/Areas/Calendar/Views/Assessments/_FormElement.cshtml")]
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
#line 1 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Calendar\Views\_ViewImports.cshtml"
using Microsoft.Extensions.Options;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Calendar\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Calendar\Views\_ViewImports.cshtml"
using Iqt.Base.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Calendar\Views\_ViewImports.cshtml"
using Iqt.Base.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Calendar\Views\_ViewImports.cshtml"
using Metsi.Web.Site.Admin.Areas.Calendar.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Calendar\Views\_ViewImports.cshtml"
using Calendar.Base.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Calendar\Views\Assessments\_FormElement.cshtml"
using Iqt.Base.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"56cb464a7ef26ab37ae62689fb0b956e6e168e10", @"/Areas/Calendar/Views/Assessments/_FormElement.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5bc8ca6e57172bfb492c00c9e385d4872810396b", @"/Areas/Calendar/Views/_ViewImports.cshtml")]
    public class Areas_Calendar_Views_Assessments__FormElement : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Iqt.Base.Entities.FormElement<RecurringTask>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Calendar\Views\Assessments\_FormElement.cshtml"
 if (Model.ElementType == FormElementType.SingleLineText)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"form-group\">\r\n        <label class=\"col-md-3 control-label\">");
#nullable restore
#line 7 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Calendar\Views\Assessments\_FormElement.cshtml"
                                         Write(Model.ElementName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n        <div class=\"col-md-9\">\r\n            <input type=\"text\"");
            BeginWriteAttribute("id", " id=\"", 309, "\"", 323, 1);
#nullable restore
#line 9 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Calendar\Views\Assessments\_FormElement.cshtml"
WriteAttributeValue("", 314, Model.Id, 314, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"form-control\" readonly=\"readonly\" />\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 12 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Calendar\Views\Assessments\_FormElement.cshtml"
}
else if (Model.ElementType == FormElementType.MultiLineText)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"form-group\">\r\n        <label class=\"col-md-3 control-label\">");
#nullable restore
#line 16 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Calendar\Views\Assessments\_FormElement.cshtml"
                                         Write(Model.ElementName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n        <div class=\"col-md-9\">\r\n            <textarea type=\"text\"");
            BeginWriteAttribute("id", " id=\"", 635, "\"", 649, 1);
#nullable restore
#line 18 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Calendar\Views\Assessments\_FormElement.cshtml"
WriteAttributeValue("", 640, Model.Id, 640, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"form-control\" readonly=\"readonly\" style=\"height: 100px;\" ></textarea>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 21 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Calendar\Views\Assessments\_FormElement.cshtml"
}
else if (Model.ElementType == FormElementType.Decimal)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"form-group\">\r\n        <label class=\"col-md-3 control-label\">");
#nullable restore
#line 25 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Calendar\Views\Assessments\_FormElement.cshtml"
                                         Write(Model.ElementName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n        <div class=\"col-md-9\">\r\n            <input type=\"number\"");
            BeginWriteAttribute("id", " id=\"", 987, "\"", 1001, 1);
#nullable restore
#line 27 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Calendar\Views\Assessments\_FormElement.cshtml"
WriteAttributeValue("", 992, Model.Id, 992, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"form-control\" readonly=\"readonly\" />\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 30 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Calendar\Views\Assessments\_FormElement.cshtml"
}
else if (Model.ElementType == FormElementType.Number)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"form-group\">\r\n        <label class=\"col-md-3 control-label\">");
#nullable restore
#line 34 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Calendar\Views\Assessments\_FormElement.cshtml"
                                         Write(Model.ElementName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n        <div class=\"col-md-9\">\r\n            <input type=\"number\"");
            BeginWriteAttribute("id", " id=\"", 1305, "\"", 1319, 1);
#nullable restore
#line 36 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Calendar\Views\Assessments\_FormElement.cshtml"
WriteAttributeValue("", 1310, Model.Id, 1310, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"form-control\" readonly=\"readonly\" />\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 39 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Calendar\Views\Assessments\_FormElement.cshtml"
}
else if (Model.ElementType == FormElementType.Image)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"form-group\">\r\n        <label class=\"col-md-3 control-label\">");
#nullable restore
#line 43 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Calendar\Views\Assessments\_FormElement.cshtml"
                                         Write(Model.ElementName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n        <div class=\"col-md-9\">\r\n            <input type=\"file\"");
            BeginWriteAttribute("id", " id=\"", 1620, "\"", 1634, 1);
#nullable restore
#line 45 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Calendar\Views\Assessments\_FormElement.cshtml"
WriteAttributeValue("", 1625, Model.Id, 1625, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"form-control\" />\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 48 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Calendar\Views\Assessments\_FormElement.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Iqt.Base.Entities.FormElement<RecurringTask>> Html { get; private set; }
    }
}
#pragma warning restore 1591