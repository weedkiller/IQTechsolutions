#pragma checksum "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Views\Shared\Layouts\_Layout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "517b40b019b9eed8ee092af5dc14eb8c6d54815e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Layouts__Layout), @"mvc.1.0.view", @"/Views/Shared/Layouts/_Layout.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"517b40b019b9eed8ee092af5dc14eb8c6d54815e", @"/Views/Shared/Layouts/_Layout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ae93721a468c7c27a84c309b942fba5fba6da670", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Layouts__Layout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "517b40b019b9eed8ee092af5dc14eb8c6d54815e3381", async() => {
                WriteLiteral(@"
    <meta charset=""utf-8"" />
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"" />

    <!--Favicons -->

    <link rel=""apple-touch-icon"" sizes=""57x57"" href=""/img/favicon/apple-icon-57x57.png"">
    <link rel=""apple-touch-icon"" sizes=""60x60"" href=""/img/favicon/apple-icon-60x60.png"">
    <link rel=""apple-touch-icon"" sizes=""72x72"" href=""/img/favicon/apple-icon-72x72.png"">
    <link rel=""apple-touch-icon"" sizes=""76x76"" href=""/img/favicon/apple-icon-76x76.png"">
    <link rel=""apple-touch-icon"" sizes=""114x114"" href=""/img/favicon/apple-icon-114x114.png"">
    <link rel=""apple-touch-icon"" sizes=""120x120"" href=""/img/favicon/apple-icon-120x120.png"">
    <link rel=""apple-touch-icon"" sizes=""144x144"" href=""/img/favicon/apple-icon-144x144.png"">
    <link rel=""apple-touch-icon"" sizes=""152x152"" href=""/img/favicon/apple-icon-152x152.png"">
    <link rel=""apple-touch-icon"" sizes=""180x180"" href=""/img/favicon/apple-icon-180x180.png"">
    <link rel=""icon"" type=""image/png"" sizes=""192x192"" href");
                WriteLiteral(@"=""/img/favicon/android-icon-192x192.png"">
    <link rel=""icon"" type=""image/png"" sizes=""32x32"" href=""/img/favicon/favicon-32x32.png"">
    <link rel=""icon"" type=""image/png"" sizes=""96x96"" href=""/img/favicon/favicon-96x96.png"">
    <link rel=""icon"" type=""image/png"" sizes=""16x16"" href=""/img/favicon/favicon-16x16.png"">
");
                WriteLiteral("    <meta name=\"msapplication-TileColor\" content=\"#ffffff\">\r\n    <meta name=\"msapplication-TileImage\" content=\"/img/favicon/ms-icon-144x144.png\">\r\n    <meta name=\"theme-color\" content=\"#ffffff\">\r\n\r\n    <!-- Primary Meta Tags -->\r\n    <title>Olympia - ");
#nullable restore
#line 28 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Views\Shared\Layouts\_Layout.cshtml"
                Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</title>
    <meta name=""title"" content=""Olympia - Innovative Software Development, Testing and Products"">
    <meta name=""description"" content=""If you`re looking for custom software development, testing, implementation and project management, we`re the team that you should be talking to continuous performance management, software development, performance management system, digital project management"">

    <!-- Open Graph / Facebook -->
    <meta property=""og:type"" content=""website"">
    <meta property=""og:url"" content=""http://olympiahdpreview.iqtechsolutions.co.za/"">
    <meta property=""og:title"" content=""Olympia - Innovative Software Development, Testing and Products"">
    <meta property=""og:description"" content=""If you`re looking for custom software development, testing, implementation and project management, we`re the team that you should be talking to continuous performance management, software development, performance management system, digital project management"">
    <meta property=""og:image");
                WriteLiteral(@""" content=""http://olympiahdpreview.iqtechsolutions.co.za/images/Rectangular_Olympia_Logo.png"">

    <!-- Twitter -->
    <meta property=""twitter:card"" content=""summary_large_image"">
    <meta property=""twitter:url"" content=""http://olympiahdpreview.iqtechsolutions.co.za/"">
    <meta property=""twitter:title"" content=""Olympia - Innovative Software Development, Testing and Products"">
    <meta property=""twitter:description"" content=""If you`re looking for custom software development, testing, implementation and project management, we`re the team that you should be talking to continuous performance management, software development, performance management system, digital project management"">
    <meta property=""twitter:image"" content=""http://olympiahdpreview.iqtechsolutions.co.za/images/Rectangular_Olympia_Logo.png"">

    <meta name=""author"" content=""Novaly"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
    <meta name=""");
                WriteLiteral(@"description"" content=""If youre looking for custom software development, testing, implementation and project management, we&#x2019;re the team that you should be talking to"">
    <meta name=""keywords"" content=""continuous performance management, software development, performance management system, digital project management"" />
    <link href=""images/favicon.png"" rel=""shortcut icon"" type=""image/png"">


    <!-- Main Stylesheet -->
    <link rel=""stylesheet"" href=""/css/style.css"">
    <link rel=""stylesheet"" href=""/css/responsive.css"">
<<<<<<< HEAD
<<<<<<< HEAD

    <script>
        //cancel = function () {
        //    window.open('/CaseStudies/Home/Index', ""PopupWindow"", 'width=1000px,height=500px, bottom=20px,left=20px');
        //}
        $(""#cancel"").click(function () {
            //this will find the selected website from the dropdown
            var go_to_url = $(""#websites"").find("":selected"").val();

            //this will redirect us in same window
            document.location.h");
                WriteLiteral(@"ref = go_to_url;
        });
    </script>
=======
<<<<<<< Updated upstream
<<<<<<< Updated upstream
>>>>>>> origin/Olympia-Map-Model-Completed
   
=======
    


>>>>>>> Stashed changes
=======
    


>>>>>>> Stashed changes
=======




>>>>>>> origin/master
    ");
#nullable restore
#line 93 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Views\Shared\Layouts\_Layout.cshtml"
Write(RenderSection("Styles", required: false));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "517b40b019b9eed8ee092af5dc14eb8c6d54815e10241", async() => {
                WriteLiteral("\r\n    <!-- Preloader Start -->\r\n    <div class=\"preloader\"></div>\r\n\r\n    ");
#nullable restore
#line 101 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Views\Shared\Layouts\_Layout.cshtml"
Write(Html.Partial("Headers/Default"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n    ");
#nullable restore
#line 103 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Views\Shared\Layouts\_Layout.cshtml"
Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    \r\n    ");
#nullable restore
#line 105 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Views\Shared\Layouts\_Layout.cshtml"
Write(Html.Partial("Footers/Default"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"

    <div class=""modal modal-message fade"" id=""CropModal"" data-backdrop=""static"" data-keyboard=""false""></div>
    <div class=""modal modal-message fade"" id=""ModalPlaceHolder""></div>

    <!-- BACK TO TOP SECTION -->
    <div class=""back-to-top bg-gradient-color"">
        <i class=""fab fa-angle-up""></i>
    </div>

    <!-- Integrated important scripts here -->
    <script src=""/js/jquery.v1.12.4.min.js""></script>
    <script src=""/js/bootstrap.min.js""></script>
<<<<<<< HEAD
    ");
                WriteLiteral("\r\n");
                WriteLiteral("    <script src=\"/js/jquery-core-plugins.js\"></script>\r\n    <script src=\"/js/main.js\"></script>\r\n");
                WriteLiteral("\r\n=======\r\n    <script src=\"/js/jquery-core-plugins.js\"></script>\r\n    <script src=\"/js/main.js\"></script>\r\n  \r\n>>>>>>> origin/master\r\n    ");
#nullable restore
#line 133 "C:\Users\Admin\Desktop\Work\IqTechSolution\Julius\Olympia\Olympia.Web.Site\Views\Shared\Layouts\_Layout.cshtml"
Write(RenderSection("Scripts", required: false));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591