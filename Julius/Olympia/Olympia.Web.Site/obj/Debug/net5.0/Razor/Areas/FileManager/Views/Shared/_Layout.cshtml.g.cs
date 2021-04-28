#pragma checksum "G:\IQTechSolutions\Julius\Olympia\Olympia.Web.Site\Areas\FileManager\Views\Shared\_Layout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "24e624f2c8d8c4edfe29f69140ef121e2c625437"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_FileManager_Views_Shared__Layout), @"mvc.1.0.view", @"/Areas/FileManager/Views/Shared/_Layout.cshtml")]
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
#line 1 "G:\IQTechSolutions\Julius\Olympia\Olympia.Web.Site\Areas\FileManager\Views\_ViewImports.cshtml"
using Filing.Base.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "G:\IQTechSolutions\Julius\Olympia\Olympia.Web.Site\Areas\FileManager\Views\_ViewImports.cshtml"
using Filing.Base.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "G:\IQTechSolutions\Julius\Olympia\Olympia.Web.Site\Areas\FileManager\Views\_ViewImports.cshtml"
using Grouping.Base.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "G:\IQTechSolutions\Julius\Olympia\Olympia.Web.Site\Areas\FileManager\Views\_ViewImports.cshtml"
using Blogging.Base.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "G:\IQTechSolutions\Julius\Olympia\Olympia.Web.Site\Areas\FileManager\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "G:\IQTechSolutions\Julius\Olympia\Olympia.Web.Site\Areas\FileManager\Views\_ViewImports.cshtml"
using Grouping.Core.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "G:\IQTechSolutions\Julius\Olympia\Olympia.Web.Site\Areas\FileManager\Views\_ViewImports.cshtml"
using Blogging.Core.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "G:\IQTechSolutions\Julius\Olympia\Olympia.Web.Site\Areas\FileManager\Views\_ViewImports.cshtml"
using Iqt.Base.Extensions;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"24e624f2c8d8c4edfe29f69140ef121e2c625437", @"/Areas/FileManager/Views/Shared/_Layout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d68d9c0a01924fc96bffb67fb7f7f00e6c73009d", @"/Areas/FileManager/Views/_ViewImports.cshtml")]
    public class Areas_FileManager_Views_Shared__Layout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "G:\IQTechSolutions\Julius\Olympia\Olympia.Web.Site\Areas\FileManager\Views\Shared\_Layout.cshtml"
  
    Layout = "Layouts/_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Styles", async() => {
                WriteLiteral("\r\n    <link href=\'/css/summernote.css\' rel=\'stylesheet\' type=\'text/css\' />\r\n    <link rel=\"stylesheet\" href=\"/css/bs-filestyle.css\">\r\n\r\n    ");
#nullable restore
#line 10 "G:\IQTechSolutions\Julius\Olympia\Olympia.Web.Site\Areas\FileManager\Views\Shared\_Layout.cshtml"
Write(RenderSection("Styles", required: false));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
            }
            );
            WriteLiteral("\r\n<section class=\"about-section anim-object pdt-110 pdb-50 pdb-lg-80\">\r\n    <div class=\"container\">\r\n        <div class=\"row align-items-center\">\r\n            <div class=\"col-md-12\">\r\n\r\n                ");
#nullable restore
#line 18 "G:\IQTechSolutions\Julius\Olympia\Olympia.Web.Site\Areas\FileManager\Views\Shared\_Layout.cshtml"
           Write(RenderBody());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <!-- Summer Note JS -->
    <script src=""/js/summernote/summernote.js""></script>
    <script src=""/js/bs-filestyle.js""></script>

    <script type=""text/javascript"">
        // Default
        $(document).ready(function () {
            var HomeIndex = function () {

                var $this = this;

                function initialize() {
                    $('#Entity_Description').summernote({
                        height: 250,
                        codemirror: { // codemirror options
                            theme: 'monokai'
                        }
                    });
                }

                $this.init = function () {
                    initialize();
                }
            };
            var self = new HomeIndex();
            self.init();
        });

    </script>

    ");
#nullable restore
#line 57 "G:\IQTechSolutions\Julius\Olympia\Olympia.Web.Site\Areas\FileManager\Views\Shared\_Layout.cshtml"
Write(RenderSection("Scripts", required: false));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
            }
            );
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
