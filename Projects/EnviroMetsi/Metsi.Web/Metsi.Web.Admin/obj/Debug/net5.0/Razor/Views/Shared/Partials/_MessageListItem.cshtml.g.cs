#pragma checksum "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\Partials\_MessageListItem.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "80bbccb77eabcc67f74d1deb1527bb764f381986"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Partials__MessageListItem), @"mvc.1.0.view", @"/Views/Shared/Partials/_MessageListItem.cshtml")]
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
#nullable restore
#line 1 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\Partials\_MessageListItem.cshtml"
using Filing.Base.Extensions;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"80bbccb77eabcc67f74d1deb1527bb764f381986", @"/Views/Shared/Partials/_MessageListItem.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"58acc36c7c6b2cabb3fe2c504456252e879f0d65", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Partials__MessageListItem : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Messaging.Base.Entities.Message>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n    <li class=\"media\">\r\n        <a href=\"javascript:;\">\r\n            <div class=\"media-left\"><img");
            BeginWriteAttribute("src", " src=\"", 170, "\"", 193, 1);
#nullable restore
#line 6 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\Partials\_MessageListItem.cshtml"
WriteAttributeValue("", 176, Model.GetImage(), 176, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"media-object\"");
            BeginWriteAttribute("alt", " alt=\"", 215, "\"", 238, 2);
#nullable restore
#line 6 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\Partials\_MessageListItem.cshtml"
WriteAttributeValue("", 221, Model.Name, 221, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 232, "Image", 233, 6, true);
            EndWriteAttribute();
            WriteLiteral(" /></div>\r\n            <div class=\"media-body\">\r\n                <h6 class=\"media-heading\">");
#nullable restore
#line 8 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\Partials\_MessageListItem.cshtml"
                                     Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n                <p>");
#nullable restore
#line 9 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\Partials\_MessageListItem.cshtml"
              Write(Model.MessageString);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <div class=\"text-muted f-s-11\">");
#nullable restore
#line 10 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Views\Shared\Partials\_MessageListItem.cshtml"
                                          Write(Model.CreatedDateString);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n            </div>\r\n        </a>\r\n    </li>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Messaging.Base.Entities.Message> Html { get; private set; }
    }
}
#pragma warning restore 1591
