#pragma checksum "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Documents\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ab8214a20005d5634eb61a3e9faaede39302b62c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Documents_Views_Home_Index), @"mvc.1.0.view", @"/Areas/Documents/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Documents\Views\_ViewImports.cshtml"
using Microsoft.Extensions.Options;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Documents\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ab8214a20005d5634eb61a3e9faaede39302b62c", @"/Areas/Documents/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c6f06eba713a9bfa74aea7aee87534bbdaccb1ec", @"/Areas/Documents/Views/_ViewImports.cshtml")]
    public class Areas_Documents_Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("url", "/Documents/Home/FileOperations", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("downloadUrl", "/Documents/Home/Download", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("uploadUrl", "/Documents/Home/Upload", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("getImageUrl", "/Documents/Home/GetImage", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("file", new global::Microsoft.AspNetCore.Html.HtmlString("files"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("folder", new global::Microsoft.AspNetCore.Html.HtmlString("folder"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("layout", new global::Microsoft.AspNetCore.Html.HtmlString("layout"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", "file", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("maxFileSize", new global::Microsoft.AspNetCore.Html.HtmlString("104857600"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("menuOpen", "menuOpen", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("menuClick", "menuClick", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("toolbarClick", "toolbarClick", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("toolbarCreate", "onCreate", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_13 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/apps.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Syncfusion.EJ2.FileManager.FileManager __Syncfusion_EJ2_FileManager_FileManager;
        private global::Syncfusion.EJ2.FileManager.FileManagerAjaxSettings __Syncfusion_EJ2_FileManager_FileManagerAjaxSettings;
        private global::Syncfusion.EJ2.FileManager.FileManagerContextMenuSettings __Syncfusion_EJ2_FileManager_FileManagerContextMenuSettings;
        private global::Syncfusion.EJ2.FileManager.FileManagerNavigationPaneSettings __Syncfusion_EJ2_FileManager_FileManagerNavigationPaneSettings;
        private global::Syncfusion.EJ2.FileManager.FileManagerToolbarSettings __Syncfusion_EJ2_FileManager_FileManagerToolbarSettings;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Documents\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Documents Manager";
    string[] items = new string[] { "NewFolder", "Upload", "Delete", "Download", "Rename", "SortBy", "Refresh", "Selection", "View", "Details" , "Share", "Email Link"};
    string[] files = new string[] { "Share", "Email Link", "Open", "|", "Delete", "Download", "Rename", "|", "Details" };
    string[] folder = new string[] { "Share", "Email Link", "Open", "|", "Delete", "Download", "Rename", "|", "Details" };
    string[] layout = new string[] { "Share", "Email Link", "SortBy", "View", "Refresh", "|", "NewFolder", "Upload", "|", "Details", "|", "SelectAll" };

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\" control-section\">\r\n        <div class=\"sample-container\">\r\n            <!--  Filemanager element declaration -->\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("ejs-filemanager", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ab8214a20005d5634eb61a3e9faaede39302b62c9561", async() => {
                WriteLiteral("\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("e-filemanager-ajaxsettings", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ab8214a20005d5634eb61a3e9faaede39302b62c9846", async() => {
                    WriteLiteral("\r\n                ");
                }
                );
                __Syncfusion_EJ2_FileManager_FileManagerAjaxSettings = CreateTagHelper<global::Syncfusion.EJ2.FileManager.FileManagerAjaxSettings>();
                __tagHelperExecutionContext.Add(__Syncfusion_EJ2_FileManager_FileManagerAjaxSettings);
                __Syncfusion_EJ2_FileManager_FileManagerAjaxSettings.Url = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __Syncfusion_EJ2_FileManager_FileManagerAjaxSettings.DownloadUrl = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __Syncfusion_EJ2_FileManager_FileManagerAjaxSettings.UploadUrl = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __Syncfusion_EJ2_FileManager_FileManagerAjaxSettings.GetImageUrl = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("e-filemanager-contextmenusettings", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ab8214a20005d5634eb61a3e9faaede39302b62c11753", async() => {
                }
                );
                __Syncfusion_EJ2_FileManager_FileManagerContextMenuSettings = CreateTagHelper<global::Syncfusion.EJ2.FileManager.FileManagerContextMenuSettings>();
                __tagHelperExecutionContext.Add(__Syncfusion_EJ2_FileManager_FileManagerContextMenuSettings);
#nullable restore
#line 19 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Documents\Views\Home\Index.cshtml"
__Syncfusion_EJ2_FileManager_FileManagerContextMenuSettings.Visible = true;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("visible", __Syncfusion_EJ2_FileManager_FileManagerContextMenuSettings.Visible, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 19 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Documents\Views\Home\Index.cshtml"
__Syncfusion_EJ2_FileManager_FileManagerContextMenuSettings.File = files;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("file", __Syncfusion_EJ2_FileManager_FileManagerContextMenuSettings.File, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 19 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Documents\Views\Home\Index.cshtml"
__Syncfusion_EJ2_FileManager_FileManagerContextMenuSettings.Folder = folder;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("folder", __Syncfusion_EJ2_FileManager_FileManagerContextMenuSettings.Folder, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 19 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Documents\Views\Home\Index.cshtml"
__Syncfusion_EJ2_FileManager_FileManagerContextMenuSettings.Layout = layout;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("layout", __Syncfusion_EJ2_FileManager_FileManagerContextMenuSettings.Layout, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("e-filemanager-navigationpanesettings", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ab8214a20005d5634eb61a3e9faaede39302b62c14854", async() => {
                }
                );
                __Syncfusion_EJ2_FileManager_FileManagerNavigationPaneSettings = CreateTagHelper<global::Syncfusion.EJ2.FileManager.FileManagerNavigationPaneSettings>();
                __tagHelperExecutionContext.Add(__Syncfusion_EJ2_FileManager_FileManagerNavigationPaneSettings);
#nullable restore
#line 20 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Documents\Views\Home\Index.cshtml"
__Syncfusion_EJ2_FileManager_FileManagerNavigationPaneSettings.Visible = true;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("visible", __Syncfusion_EJ2_FileManager_FileManagerNavigationPaneSettings.Visible, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("e-filemanager-toolbarsettings", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ab8214a20005d5634eb61a3e9faaede39302b62c16684", async() => {
                }
                );
                __Syncfusion_EJ2_FileManager_FileManagerToolbarSettings = CreateTagHelper<global::Syncfusion.EJ2.FileManager.FileManagerToolbarSettings>();
                __tagHelperExecutionContext.Add(__Syncfusion_EJ2_FileManager_FileManagerToolbarSettings);
#nullable restore
#line 21 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Documents\Views\Home\Index.cshtml"
__Syncfusion_EJ2_FileManager_FileManagerToolbarSettings.Visible = true;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("visible", __Syncfusion_EJ2_FileManager_FileManagerToolbarSettings.Visible, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 21 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Documents\Views\Home\Index.cshtml"
__Syncfusion_EJ2_FileManager_FileManagerToolbarSettings.Items = items;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("items", __Syncfusion_EJ2_FileManager_FileManagerToolbarSettings.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            ");
            }
            );
            __Syncfusion_EJ2_FileManager_FileManager = CreateTagHelper<global::Syncfusion.EJ2.FileManager.FileManager>();
            __tagHelperExecutionContext.Add(__Syncfusion_EJ2_FileManager_FileManager);
            __Syncfusion_EJ2_FileManager_FileManager.Id = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
#nullable restore
#line 13 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Documents\Views\Home\Index.cshtml"
__Syncfusion_EJ2_FileManager_FileManager.AllowMultiSelection = true;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("allowMultiSelection", __Syncfusion_EJ2_FileManager_FileManager.AllowMultiSelection, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
#nullable restore
#line 13 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Documents\Views\Home\Index.cshtml"
__Syncfusion_EJ2_FileManager_FileManager.View = global::Syncfusion.EJ2.FileManager.ViewType.Details;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("view", __Syncfusion_EJ2_FileManager_FileManager.View, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 13 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Admin\Areas\Documents\Views\Home\Index.cshtml"
__Syncfusion_EJ2_FileManager_FileManager.AllowDragAndDrop = true;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("allowDragAndDrop", __Syncfusion_EJ2_FileManager_FileManager.AllowDragAndDrop, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Syncfusion_EJ2_FileManager_FileManager.MenuOpen = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
            __Syncfusion_EJ2_FileManager_FileManager.MenuClick = (string)__tagHelperAttribute_10.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_10);
            __Syncfusion_EJ2_FileManager_FileManager.ToolbarClick = (string)__tagHelperAttribute_11.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_11);
            __Syncfusion_EJ2_FileManager_FileManager.ToolbarCreate = (string)__tagHelperAttribute_12.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_12);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            <!-- end of filemanager element -->
        </div>
    </div>
</div>

<script type=""text/javascript"">
    // event for custom toolbar item
    function toolbarClick(args) {
        if (args.item.text === 'Share') {
            var fileDetails = document.getElementById('file').ej2_instances[0].getSelectedFiles();

            if (fileDetails.length > 0) {
                var obj = { data: fileDetails };
                alert(JSON.stringify(obj));

                $.ajax({
                    type: ""POST"",
                    contentType: ""application/json; charset=utf-8"",
                    // Custom method the data passed 
                    url: ""/Documents/Home/DoShareFileFolder"",
                    data: JSON.stringify(obj),
                    dataType: ""html"",
                    success: function(data) {
                        $(""#ModalPlaceHolder"").html(data);
                        $(""#ModalPlaceHolder"").modal(""show"");
                    },
               ");
            WriteLiteral(@"     error: function(xhr, textStatus, err) {
                        alert(""An error with the following detials occured : "" +
                            ""\r\n == readyState: "" +
                            xhr.readyState +
                            ""\r\n == status: "" +
                            xhr.status +
                            ""\r\n == text status: "" +
                            textStatus +
                            ""\r\n == error: "" +
                            err);
                    }
                });
            } else {
                alert(""Please select a file first"")
            }
        }
        else if (args.item.text === 'Email Link') {
            var fileDetails = document.getElementById('file').ej2_instances[0].getSelectedFiles();
            if (fileDetails.length > 0) {
            var obj = { data: fileDetails };
            alert(JSON.stringify(obj));

            $.ajax({
                type: ""POST"",
                contentType: ""applicatio");
            WriteLiteral(@"n/json; charset=utf-8"",
                // Custom method the data passed 
                url: ""/Documents/Home/ShareFileFolderByAddress"",
                data: JSON.stringify(obj),
                dataType: ""html"",
                success: function (data) {
                    $(""#ModalPlaceHolder"").html(data);
                    $(""#ModalPlaceHolder"").modal(""show"");
                },
                error: function (xhr, textStatus, err) {
                    alert(""An error with the following detials occured : ""
                        + ""\r\n == readyState: "" + xhr.readyState
                        + ""\r\n == status: "" + xhr.status
                        + ""\r\n == text status: "" + textStatus
                        + ""\r\n == error: "" + err);
                }
            }); 
            } else {
                alert(""Please select a file first"")
            }
        }
    }
    function onCreate(args) {
        for (var i = 0; i < args.items.length; i++) {
            if (");
            WriteLiteral(@"args.items[i].id === this.element.id + '_tb_share') {
                args.items[i].prefixIcon = 'e-icons e-fe-share';
            }
            else if (args.items[i].id === this.element.id + '_tb_email link') {
                args.items[i].prefixIcon = 'e-icons e-fe-mail';
            }
        }
    }
    // Icon added to custom menu item
    function menuOpen(args) {
        for (var i = 0; i < args.items.length; i++) {
            if (args.items[i].id === this.element.id + '_cm_share') {
                args.items[i].iconCss = 'e-icons e-fe-tick';
            }
            else if (args.items[i].id === this.element.id + '_cm_email link') {
                args.items[i].prefixIcon = 'e-icons e-fe-mail';
            }
        }
    }

// event for custom menu item
    function menuClick(args) {
        if (args.item.text === 'Share') {
            var fileDetails = document.getElementById('file').ej2_instances[0].getSelectedFiles(); 
            var obj = { data: fileDetails }; 
 ");
            WriteLiteral(@"           $.ajax({ 
                type: ""POST"", 
                contentType: ""application/json; charset=utf-8"", 
                // Custom method the data passed 
                url: ""/Documents/Home/ShareFileFolder"",             
                data: JSON.stringify(obj), 
                dataType: ""html"", 
                success: function (data) { 
                    $(""#ModalPlaceHolder"").html(data);
                    $(""#ModalPlaceHolder"").modal(""show"");
                },
                error: function (xhr, textStatus, err) { 
                    alert(""An error with the following detials occured : ""
                        + ""\r\n == readyState: "" + xhr.readyState
                        + ""\r\n == status: "" + xhr.status
                        + ""\r\n == text status: "" + textStatus
                        + ""\r\n == error: "" + err);
                } 
            }); 
        }
        else
        if (args.item.text === 'Email Link') {
            var fileDetails = doc");
            WriteLiteral(@"ument.getElementById('file').ej2_instances[0].getSelectedFiles();
            var obj = { data: fileDetails };
            alert(JSON.stringify(obj));

            $.ajax({
                type: ""POST"",
                contentType: ""application/json; charset=utf-8"",
                // Custom method the data passed 
                url: ""/Documents/Home/ShareFileFolderByAddress"",
                data: JSON.stringify(obj),
                dataType: ""html"",
                success: function (data) {
                        $(""#ModalPlaceHolder"").html(data);
                        $(""#ModalPlaceHolder"").modal(""show"");
                    },
                error: function (xhr, textStatus, err) {
                        alert(""An error with the following detials occured : ""
                            + ""\r\n == readyState: "" + xhr.readyState
                            + ""\r\n == status: "" + xhr.status
                            + ""\r\n == text status: "" + textStatus
                       ");
            WriteLiteral("     + \"\\r\\n == error: \" + err);\r\n                    }\r\n            }); \r\n        }\r\n    }\r\n\r\n</script>\r\n<style>\r\n    .e-fe-share:before {\r\n        content: \'\\e65b\';\r\n    }\r\n    .e-fe-mail:before {\r\n        content: \'\\e711\';\r\n    }\r\n</style>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ab8214a20005d5634eb61a3e9faaede39302b62c28772", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_13);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    <script>\r\n        $(document).ready(function () {\r\n            App.init();\r\n        });\r\n    </script>\r\n    \r\n");
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