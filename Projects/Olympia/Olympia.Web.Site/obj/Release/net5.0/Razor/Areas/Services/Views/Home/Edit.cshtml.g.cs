#pragma checksum "G:\Projects\Olympia\Olympia.Web.Site\Areas\Services\Views\Home\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6868f6c9e41795a4b532a2cb0f28b5175aa6169b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Services_Views_Home_Edit), @"mvc.1.0.view", @"/Areas/Services/Views/Home/Edit.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6868f6c9e41795a4b532a2cb0f28b5175aa6169b", @"/Areas/Services/Views/Home/Edit.cshtml")]
    public class Areas_Services_Views_Home_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ServiceAddEditModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/summernote.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.SingleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.SingleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.SingleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/bs-filestyle.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.SingleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/summernote/summernote.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/bs-filestyle.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "G:\Projects\Olympia\Olympia.Web.Site\Areas\Services\Views\Home\Edit.cshtml"
  
    ViewData["Title"] = $"Edit {@Model.Entity.Name}";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Styles", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "6868f6c9e41795a4b532a2cb0f28b5175aa6169b5109", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "6868f6c9e41795a4b532a2cb0f28b5175aa6169b6374", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            WriteLiteral("\r\n<form");
            BeginWriteAttribute("class", " class=\"", 280, "\"", 288, 0);
            EndWriteAttribute();
            WriteLiteral(@" asp-area=""Services"" asp-controller=""Home"" asp-action=""Edit"" enctype=""multipart/form-data"" method=""post"" style=""margin: 0 !important"">
    <div class=""form-horizontal"">
        <div class=""row"">
            <div class=""col-md-4"">
                <div class=""form-group"" style=""padding: 0 25px"">
                    <div class=""previewd"" style=""overflow: hidden"">
                        <img id=""preview"" style=""width: 100%""");
            BeginWriteAttribute("src", " src=\"", 719, "\"", 844, 1);
#nullable restore
#line 19 "G:\Projects\Olympia\Olympia.Web.Site\Areas\Services\Views\Home\Edit.cshtml"
WriteAttributeValue("", 725, Model.Entity.GetPath("http://admin.metsi.co.za", ImageType.Cover, "/images/placeholders/MetsiPlaceholder-800x533.jpg"), 725, 119, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 845, "\"", 869, 1);
#nullable restore
#line 19 "G:\Projects\Olympia\Olympia.Web.Site\Areas\Services\Views\Home\Edit.cshtml"
WriteAttributeValue("", 851, Model.Entity.Name, 851, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" />
                    </div>
                        <input asp-for=""CoverUpload"" class=""form-control"" onchange=""loadFile(event)"" />
                        <input type=""hidden"" asp-for=""CoverCropSettings.X"" />
                        <input type=""hidden"" asp-for=""CoverCropSettings.Y"" />
                        <input type=""hidden"" asp-for=""CoverCropSettings.Width"" />
                        <input type=""hidden"" asp-for=""CoverCropSettings.Height"" />
                        <input type=""hidden"" asp-for=""CoverCropSettings.Rotate"" />
                        <input type=""hidden"" asp-for=""CoverCropSettings.ScaleX"" />
                        <input type=""hidden"" asp-for=""CoverCropSettings.ScaleY"" />
                    </div>
                </div>
            <div class=""col-md-8"">
                <h4>Service Details</h4>
                <hr />
                <div class=""form-group"">
                    <label asp-for=""Entity.Name"" class=""control-label col-md-2""></label>
                    <di");
            WriteLiteral(@"v class=""col-md-10"">
                        <input asp-for=""Entity.Name"" class=""form-control"" />
                        <span asp-validation-for=""Entity.Name"" class=""text-danger""></span>
                    </div>
                </div>
                <div class=""form-group"">
                    <label class=""control-label col-md-2"">Short Description</label>
                    <div class=""col-md-10"">
                        <textarea asp-for=""Entity.AdditionalInfo"" class=""form-control"" style=""height:100px""></textarea>
                        <span asp-validation-for=""Entity.AdditionalInfo"" class=""text-danger""></span>
                    </div>
                </div>
                <div class=""col-md-6"">
                    <label asp-for=""Entity.Featured"" class=""control-label col-md-2""></label>
                    <div class=""col-md-10"">
                        <input asp-for=""Entity.Featured"" class=""form-control"" />
                    </div>
                </div>
                <div");
            WriteLiteral(@" class=""col-md-6"">
                    <label asp-for=""Entity.Active"" class=""control-label col-md-2""></label>
                    <div class=""col-md-10"">
                        <input asp-for=""Entity.Active"" class=""form-control"" />
                    </div>
                </div>
                <input type=""hidden"" asp-for=""Entity.Id"" />
            </div>
        </div>
        <div class=""row"">
            <div class=""col-md-12"">
                <div class=""row"" style=""padding-bottom: 20px;"">
                    <div class=""col-md-12 bottommargin text-center"">
                        <h5>Select your Images:</h5><br>
                        <input asp-for=""ImagesUpload"" id=""input-3"" type=""file"" class=""file"" multiple data-show-upload=""false"" data-show-caption=""true"" data-show-preview=""true"">
                    </div>
                    <hr />
                    <div class=""col-md-12 bottommargin text-center"" style="" margin-top: 25px;"">
");
#nullable restore
#line 72 "G:\Projects\Olympia\Olympia.Web.Site\Areas\Services\Views\Home\Edit.cshtml"
                         foreach (var image in Model.Entity.Images.Where(c => c.ImageType == ImageType.Image))
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"col-lg-2\"");
            BeginWriteAttribute("id", " id=\"", 4080, "\"", 4094, 1);
#nullable restore
#line 74 "G:\Projects\Olympia\Olympia.Web.Site\Areas\Services\Views\Home\Edit.cshtml"
WriteAttributeValue("", 4085, image.Id, 4085, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                <img");
            BeginWriteAttribute("src", " src=\"", 4134, "\"", 4213, 1);
#nullable restore
#line 75 "G:\Projects\Olympia\Olympia.Web.Site\Areas\Services\Views\Home\Edit.cshtml"
WriteAttributeValue("", 4140, image.Entity.GetPath( "http://admin.metsi.co.za", ImageType.Cover, null), 4140, 73, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 4214, "\"", 4226, 1);
#nullable restore
#line 75 "G:\Projects\Olympia\Olympia.Web.Site\Areas\Services\Views\Home\Edit.cshtml"
WriteAttributeValue("", 4220, image, 4220, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                                <button type=\"button\" data-toggle=\"Remote Image\"");
            BeginWriteAttribute("onclick", " onclick=\"", 4312, "\"", 4356, 3);
            WriteAttributeValue("", 4322, "removeImageFromObject(\'", 4322, 23, true);
#nullable restore
#line 76 "G:\Projects\Olympia\Olympia.Web.Site\Areas\Services\Views\Home\Edit.cshtml"
WriteAttributeValue("", 4345, image.Id, 4345, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4354, "\')", 4354, 2, true);
            EndWriteAttribute();
            WriteLiteral(" title=\"Remove Image\" class=\"btn btn-block btn-danger btn-sm\">Delete</button>\r\n                            </div>\r\n");
#nullable restore
#line 78 "G:\Projects\Olympia\Olympia.Web.Site\Areas\Services\Views\Home\Edit.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </div>
                    <hr />
                </div>
                <div class=""form-group"">
                    <label asp-for=""Entity.Description"" class=""control-label""></label>
                    <textarea asp-for=""Entity.Description"" class=""form-control""></textarea>
                    <span asp-validation-for=""Entity.Description"" class=""text-danger""></span>
                </div>
            </div>
        </div>
    </div>
    <!-- ================== FORM BUTTON ================== -->
    <div class=""row"" style=""padding-bottom: 50px"">
        <div class=""form-group"">
            <div class=""col-md-offset-2 col-md-10 text-right"">
                <input name=""main"" type=""submit"" value=""Submit & Create"" class=""btn btn-primary"" />
                <input name=""finnish"" type=""submit"" value=""Submit & Finnish"" class=""btn btn-primary"" />
                <a asp-area=""Services"" asp-controller=""Home"" asp-action=""List"" class=""btn btn-danger"">Cancel</a>
            </div>
");
            WriteLiteral("        </div>\r\n    </div>\r\n    <!-- ================== END FORM BUTTON ================== -->\r\n\r\n</form>\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
#nullable restore
#line 107 "G:\Projects\Olympia\Olympia.Web.Site\Areas\Services\Views\Home\Edit.cshtml"
Write(await Html.PartialAsync("_ValidationScriptsPartial"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"

    <script>
        var loadFile = function(event) {
            var output = document.getElementById('preview');
            if (event.target.files.length !== 0) {

                var oldstring = """";
                if (output === null) {
                    oldstring = ""/images/placeholders/MetsiPlaceholder-800x533.jpg"";
                } else {
                    oldstring = output.src;
                }

                var url = ""/Home/CropImage?cropUrl="" + URL.createObjectURL(event.target.files[0]) + ""&originalUrl="" + oldstring + ""&width="" + 800 + ""&height="" + 533
                    + ""&previewClass=previewd"" + ""&uploadProperty=CoverUpload"" + ""&xTag=CoverCropSettings_X"" + ""&yTag=CoverCropSettings_Y""
                    + ""&widthTag=CoverCropSettings_Width"" + ""&heightTag=CoverCropSettings_Height"" + ""&rotateTag=CoverCropSettings_Rotate"" + ""&scaleXTag=CoverCropSettings_ScaleX""
                    + ""&scaleYTag=CoverCropSettings_ScaleY"";

                $(""#CropModal"").load(url,
 ");
                WriteLiteral("                   function () {\r\n                        $(\"#CropModal\").modal(\"show\");\r\n                    });\r\n            }\r\n        };\r\n    </script>\r\n\r\n    <!-- Summer Note JS -->\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6868f6c9e41795a4b532a2cb0f28b5175aa6169b17629", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6868f6c9e41795a4b532a2cb0f28b5175aa6169b18729", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"

    <script type=""text/javascript"">
        // Default
        $(document).ready(function() {
            var HomeIndex = function() {

                var $this = this;

                function initialize() {
                    $('#Entity_Description').summernote({
                        height: 250,
                        codemirror: { // codemirror options
                            theme: 'monokai'
                        }
                    });
                }

                $this.init = function() {
                    initialize();
                }
            };
            var self = new HomeIndex();
            self.init();
        });

        var fileimages = {
            'removefromfile': function(image_id) {
                removeImageFromObject(image_id);
            }
        };


        function removeImageFromObject(image_id) {
            $.ajax({
                url: ""/Services/Home/RemoveImageAjax"",
                type: ""POST"",
       ");
                WriteLiteral(@"         data: { id: image_id },
                async: false,
                dataType: ""json"",
                success: function(data) {
                    $('#' + image_id).empty();
                },
                error: function(error) {
                    alert(""Error : "" + JSON.stringify(error, null, 2));
                }
            });
        };
    </script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ServiceAddEditModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
