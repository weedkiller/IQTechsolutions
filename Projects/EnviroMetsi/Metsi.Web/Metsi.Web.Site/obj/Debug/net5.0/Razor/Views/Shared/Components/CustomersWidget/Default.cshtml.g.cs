#pragma checksum "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Site\Views\Shared\Components\CustomersWidget\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ee1fa3795c8fcaf325d7aec2f7896cd15c47e5ee"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_CustomersWidget_Default), @"mvc.1.0.view", @"/Views/Shared/Components/CustomersWidget/Default.cshtml")]
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
#line 1 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Site\Views\_ViewImports.cshtml"
using Metsi.Web.Site;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Site\Views\_ViewImports.cshtml"
using Metsi.Web.Site.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Site\Views\Shared\Components\CustomersWidget\Default.cshtml"
using Filing.Base.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Site\Views\Shared\Components\CustomersWidget\Default.cshtml"
using Iqt.Base.Interfaces;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ee1fa3795c8fcaf325d7aec2f7896cd15c47e5ee", @"/Views/Shared/Components/CustomersWidget/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b952b6b38781916602073809a0504fde726fe5b7", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_CustomersWidget_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<List<Customers.Base.ApiModels.CustomerModel>>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
            WriteLiteral(@"
<h3>Our Customers</h3>


<div id=""carousel-media2"" class=""carousel slide customer-carousel"" data-ride=""carousel"">
    <!-- Indicators -->
    <ol class=""carousel-indicators"">
        <li data-target=""#carousel-media2"" data-slide-to=""0"" class=""active""></li>
");
#nullable restore
#line 15 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Site\Views\Shared\Components\CustomersWidget\Default.cshtml"
         for (int i = 1; i < Model.Count(); i++)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li data-target=\"#carousel-media2\" data-slide-to=\"");
#nullable restore
#line 17 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Site\Views\Shared\Components\CustomersWidget\Default.cshtml"
                                                         Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"></li>\r\n");
#nullable restore
#line 18 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Site\Views\Shared\Components\CustomersWidget\Default.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </ol>\r\n\r\n    <!-- Wrapper for slides -->\r\n    <div class=\"carousel-inner text-center\">\r\n\r\n");
#nullable restore
#line 24 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Site\Views\Shared\Components\CustomersWidget\Default.cshtml"
         for (int i = 0; i < Model.Count(); i++)
        {
            var tt = "";
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Site\Views\Shared\Components\CustomersWidget\Default.cshtml"
             if (i == 0)
            {
                tt = "active text-center";
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div");
            BeginWriteAttribute("class", " class=\"", 900, "\"", 916, 2);
            WriteAttributeValue("", 908, "item", 908, 4, true);
#nullable restore
#line 32 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Site\Views\Shared\Components\CustomersWidget\Default.cshtml"
WriteAttributeValue(" ", 912, tt, 913, 3, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                <div class=\"media\">\r\n");
#nullable restore
#line 34 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Site\Views\Shared\Components\CustomersWidget\Default.cshtml"
                     foreach (var item in Model.ToList()[i])
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div style=\"float:left; width:120px;\">\r\n                            <a href=\"javascript:;\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1156, "\"", 1202, 3);
            WriteAttributeValue("", 1166, "ShowCustomerDetailsModal(\'", 1166, 26, true);
#nullable restore
#line 37 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Site\Views\Shared\Components\CustomersWidget\Default.cshtml"
WriteAttributeValue("", 1192, item.Id, 1192, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1200, "\')", 1200, 2, true);
            EndWriteAttribute();
            BeginWriteAttribute("title", " title=\"", 1203, "\"", 1221, 1);
#nullable restore
#line 37 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Site\Views\Shared\Components\CustomersWidget\Default.cshtml"
WriteAttributeValue("", 1211, item.Name, 1211, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                <img");
            BeginWriteAttribute("src", " src=\"", 1261, "\"", 1281, 1);
#nullable restore
#line 38 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Site\Views\Shared\Components\CustomersWidget\Default.cshtml"
WriteAttributeValue("", 1267, item.ImageUrl, 1267, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 1282, "\"", 1298, 1);
#nullable restore
#line 38 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Site\Views\Shared\Components\CustomersWidget\Default.cshtml"
WriteAttributeValue("", 1288, item.Name, 1288, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                            </a>\r\n                        </div>\r\n");
#nullable restore
#line 41 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Site\Views\Shared\Components\CustomersWidget\Default.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n");
#nullable restore
#line 44 "G:\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Site\Views\Shared\Components\CustomersWidget\Default.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    </div>
    <!-- Controls -->
    <a class=""left carousel-control"" href=""#carousel-media2"" role=""button"" data-slide=""prev"">
        <span class=""glyphicon glyphicon-chevron-left""></span>
    </a>
    <a class=""right carousel-control"" href=""#carousel-media2"" role=""button"" data-slide=""next"">
        <span class=""glyphicon glyphicon-chevron-right""></span>
    </a>
</div>

<script>
    function ShowCustomerDetailsModal(ff) {
        var url = ""/Home/CustomerDetails?id="" + ff;

        $(""#ModalPlaceHolder"").load(url,
            function () {
                $(""#ModalPlaceHolder"").modal(""show"");
            });
    }
</script>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IApplicationConfiguration Configuration { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<List<Customers.Base.ApiModels.CustomerModel>>> Html { get; private set; }
    }
}
#pragma warning restore 1591
