#pragma checksum "G:\IQTechSolutions\Dreyer\GoldTechInnovation\GoldTechSolutions.Web.Site\Views\Shared\Components\ProductWidget\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bdff81049ce8febed215c90c052a0bcec5b915dd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_ProductWidget_Default), @"mvc.1.0.view", @"/Views/Shared/Components/ProductWidget/Default.cshtml")]
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
#line 1 "G:\IQTechSolutions\Dreyer\GoldTechInnovation\GoldTechSolutions.Web.Site\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "G:\IQTechSolutions\Dreyer\GoldTechInnovation\GoldTechSolutions.Web.Site\Views\_ViewImports.cshtml"
using GoldTechInnovation;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "G:\IQTechSolutions\Dreyer\GoldTechInnovation\GoldTechSolutions.Web.Site\Views\_ViewImports.cshtml"
using Troubleshooting.Core.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "G:\IQTechSolutions\Dreyer\GoldTechInnovation\GoldTechSolutions.Web.Site\Views\_ViewImports.cshtml"
using Grouping.Core.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "G:\IQTechSolutions\Dreyer\GoldTechInnovation\GoldTechSolutions.Web.Site\Views\_ViewImports.cshtml"
using Grouping.Base.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "G:\IQTechSolutions\Dreyer\GoldTechInnovation\GoldTechSolutions.Web.Site\Views\_ViewImports.cshtml"
using Troubleshooting.Base.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "G:\IQTechSolutions\Dreyer\GoldTechInnovation\GoldTechSolutions.Web.Site\Views\_ViewImports.cshtml"
using Iqt.Base.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "G:\IQTechSolutions\Dreyer\GoldTechInnovation\GoldTechSolutions.Web.Site\Views\Shared\Components\ProductWidget\Default.cshtml"
using Filing.Base.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "G:\IQTechSolutions\Dreyer\GoldTechInnovation\GoldTechSolutions.Web.Site\Views\Shared\Components\ProductWidget\Default.cshtml"
using Filing.Base.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "G:\IQTechSolutions\Dreyer\GoldTechInnovation\GoldTechSolutions.Web.Site\Views\Shared\Components\ProductWidget\Default.cshtml"
using Iqt.Base.Interfaces;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bdff81049ce8febed215c90c052a0bcec5b915dd", @"/Views/Shared/Components/ProductWidget/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6f9021450af3df96d9cfd50133ad7519af791b71", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_ProductWidget_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GoldTechSolutions.Web.Site.Models.ProductComponentModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Products", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("d-block width-75 text-center"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-blue font-weight-bold"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 8 "G:\IQTechSolutions\Dreyer\GoldTechInnovation\GoldTechSolutions.Web.Site\Views\Shared\Components\ProductWidget\Default.cshtml"
 if (Model.Products.Any())
{


#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"border-bottom border-color-1 mb-5\">\r\n        <h3 class=\"section-title section-title__sm mb-0 pb-2 font-size-18\">");
#nullable restore
#line 12 "G:\IQTechSolutions\Dreyer\GoldTechInnovation\GoldTechSolutions.Web.Site\Views\Shared\Components\ProductWidget\Default.cshtml"
                                                                      Write(Model.WidgetTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n    </div>\r\n    <ul class=\"list-unstyled products-group\">\r\n");
#nullable restore
#line 15 "G:\IQTechSolutions\Dreyer\GoldTechInnovation\GoldTechSolutions.Web.Site\Views\Shared\Components\ProductWidget\Default.cshtml"
         foreach (var product in Model.Products)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li class=\"product-item product-item__list row no-gutters mb-6 remove-divider\">\r\n                <div class=\"col-auto\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bdff81049ce8febed215c90c052a0bcec5b915dd8021", async() => {
                WriteLiteral("<img class=\"img-fluid\"");
                BeginWriteAttribute("src", " src=\"", 813, "\"", 891, 1);
#nullable restore
#line 19 "G:\IQTechSolutions\Dreyer\GoldTechInnovation\GoldTechSolutions.Web.Site\Views\Shared\Components\ProductWidget\Default.cshtml"
WriteAttributeValue("", 819, product.GetPath(ImageType.Cover, Configuration.ImageDefaultPlaceholder), 819, 72, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("alt", " alt=\"", 892, "\"", 923, 3);
#nullable restore
#line 19 "G:\IQTechSolutions\Dreyer\GoldTechInnovation\GoldTechSolutions.Web.Site\Views\Shared\Components\ProductWidget\Default.cshtml"
WriteAttributeValue("", 898, product.Name, 898, 13, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue(" ", 911, "Cover", 912, 6, true);
                WriteAttributeValue(" ", 917, "Image", 918, 6, true);
                EndWriteAttribute();
                WriteLiteral(">");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 19 "G:\IQTechSolutions\Dreyer\GoldTechInnovation\GoldTechSolutions.Web.Site\Views\Shared\Components\ProductWidget\Default.cshtml"
                                                                                        WriteLiteral(product.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n                <div class=\"col pl-4 d-flex flex-column\">\r\n                    <h5 class=\"product-item__title mb-0\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bdff81049ce8febed215c90c052a0bcec5b915dd11919", async() => {
#nullable restore
#line 22 "G:\IQTechSolutions\Dreyer\GoldTechInnovation\GoldTechSolutions.Web.Site\Views\Shared\Components\ProductWidget\Default.cshtml"
                                                                                                                                                                                    Write(product.Name);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 22 "G:\IQTechSolutions\Dreyer\GoldTechInnovation\GoldTechSolutions.Web.Site\Views\Shared\Components\ProductWidget\Default.cshtml"
                                                                                                                             WriteLiteral(product.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</h5>\r\n                    <div class=\"prodcut-price mt-auto\">\r\n                        <div class=\"font-size-15\">R ");
#nullable restore
#line 24 "G:\IQTechSolutions\Dreyer\GoldTechInnovation\GoldTechSolutions.Web.Site\Views\Shared\Components\ProductWidget\Default.cshtml"
                                               Write(product.PriceIncl);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                    </div>\r\n                </div>\r\n            </li>\r\n");
#nullable restore
#line 28 "G:\IQTechSolutions\Dreyer\GoldTechInnovation\GoldTechSolutions.Web.Site\Views\Shared\Components\ProductWidget\Default.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </ul>\r\n");
#nullable restore
#line 30 "G:\IQTechSolutions\Dreyer\GoldTechInnovation\GoldTechSolutions.Web.Site\Views\Shared\Components\ProductWidget\Default.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GoldTechSolutions.Web.Site.Models.ProductComponentModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
