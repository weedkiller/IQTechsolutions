#pragma checksum "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Training\Areas\Courses\Views\Home\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "73245a447364f4f97d258176a2e38c86843f08ae"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Courses_Views_Home_Details), @"mvc.1.0.view", @"/Areas/Courses/Views/Home/Details.cshtml")]
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
#line 1 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Training\Areas\Courses\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Html;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Training\Areas\Courses\Views\Home\Details.cshtml"
using Filing.Base.Enums;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Training\Areas\Courses\Views\Home\Details.cshtml"
using Filing.Base.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Training\Areas\Courses\Views\Home\Details.cshtml"
using Iqt.Base.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Training\Areas\Courses\Views\Home\Details.cshtml"
using Iqt.Base.Interfaces;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"73245a447364f4f97d258176a2e38c86843f08ae", @"/Areas/Courses/Views/Home/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5388979e2860277fdcfa04a5b28a3044b5880a79", @"/Areas/Courses/Views/_ViewImports.cshtml")]
    public class Areas_Courses_Views_Home_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Education.Base.ApiModels.StudentCourseApiModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "/Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary btn-block"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Courses", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Modules", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 10 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Training\Areas\Courses\Views\Home\Details.cshtml"
  
    ViewData["Title"] = @Model.Name;
    ViewData["Description"] = @Model.Description.TruncateLongString(50);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "73245a447364f4f97d258176a2e38c86843f08ae6512", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 15 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Training\Areas\Courses\Views\Home\Details.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model.CurrentModuleId);

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
            WriteLiteral("\r\n\r\n<div class=\"row\">\r\n    <div class=\"col-lg-9\">\r\n\t\t<div class=\"wrapper wrapper-content animated fadeInUp\">\r\n\t\t\t<div class=\"m-b-md\">\r\n\t\t\t\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "73245a447364f4f97d258176a2e38c86843f08ae8373", async() => {
                WriteLiteral("Back to my Courses");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\t\t\t\t<h2>");
#nullable restore
#line 22 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Training\Areas\Courses\Views\Home\Details.cshtml"
               Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n\t\t\t</div>\r\n\t\t\t<div class=\"ibox\">\r\n\t\t\t\t<div class=\"ibox-content\">\r\n\t\t\t\t\t<div class=\"row\">\r\n\t\t\t\t\t\t<div class=\"col-lg-12\">\r\n\r\n\t\t\t\t\t\t\t<dl class=\"dl-horizontal\">\r\n\t\t\t\t\t\t\t\t<dt>Status:</dt>\r\n");
#nullable restore
#line 31 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Training\Areas\Courses\Views\Home\Details.cshtml"
                                 if (Model.CompletedPercentage != "100")
								{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t<dd><span class=\"label label-primary\">Active</span></dd>\r\n");
#nullable restore
#line 34 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Training\Areas\Courses\Views\Home\Details.cshtml"
								}
								else
								{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t<dd><span class=\"label label-info\">Completed</span></dd>\r\n");
#nullable restore
#line 38 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Training\Areas\Courses\Views\Home\Details.cshtml"
								}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t</dl>\r\n\t\t\t\t\t\t</div>\r\n\t\t\t\t\t</div>\r\n\t\t\t\t\t<div class=\"row\">\r\n\t\t\t\t\t\t<div class=\"col-lg-12\">\r\n\t\t\t\t\t\t\t<dl class=\"dl-horizontal\">\r\n\r\n\t\t\t\t\t\t\t\t<dt>Description:</dt>\r\n\t\t\t\t\t\t\t\t<dd>  ");
#nullable restore
#line 47 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Training\Areas\Courses\Views\Home\Details.cshtml"
                                 Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</dd>
							</dl>
						</div>
					</div>
					<div class=""row"">
						<div class=""col-lg-12"">
							<dl class=""dl-horizontal"">
								<dt>Completed:</dt>
								<dd>
									<div class=""progress progress-striped active m-b-sm"">
										<div style=""width: 60%;"" class=""progress-bar""></div>
									</div>
									<small>Project completed in <strong>60%</strong>. Remaining close the project, sign a contract and invoice.</small>
								</dd>
							</dl>
						</div>
					</div>
					<div class=""row m-t-sm"">
						<div class=""col-lg-12"">
							<div class=""panel blank-panel"">
								<div class=""panel-heading"">
									<div class=""panel-options"">
										<ul class=""nav nav-tabs"">
											<li class=""active""><a href=""#tab-1"" data-toggle=""tab"">Users messages</a></li>
											<li");
            BeginWriteAttribute("class", " class=\"", 2059, "\"", 2067, 0);
            EndWriteAttribute();
            WriteLiteral(@"><a href=""#tab-2"" data-toggle=""tab"">Last activity</a></li>
										</ul>
									</div>
								</div>

								<div class=""panel-body"">

									<div class=""tab-content"">
										<div class=""tab-pane active"" id=""tab-1"">
											<div class=""feed-activity-list"">
												<div class=""feed-element"">
													<a href=""#"" class=""pull-left"">
													</a>
													<div class=""media-body "">
														<small class=""pull-right"">2h ago</small>
														<strong>No Current Messages</strong>, please check back later. <br>
													</div>
												</div>
											</div>

										</div>
										<div class=""tab-pane"" id=""tab-2"">

											<table class=""table table-striped"">
												<thead>
													<tr>
														<th>Status</th>
														<th>Title</th>
														<th>Start Time</th>
														<th>End Time</th>
														<th>Comments</th>
													</tr>
												</thead>
												<tbody>
													<tr>
	");
            WriteLiteral(@"													<td>
															<span class=""label label-primary""><i class=""fa fa-check""></i> Completed</span>
														</td>
														<td>
															Create project in webapp
														</td>
														<td>
															12.07.2014 10:10:1
														</td>
														<td>
															14.07.2014 10:16:36
														</td>
														<td>
															<p class=""small"">
																Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable.
															</p>
														</td>

													</tr>
													<tr>
														<td>
															<span class=""label label-primary""><i class=""fa fa-check""></i> Accepted</span>
														</td>
														<td>
															Various versions
														</td>
														<td>
															12.07.2014 10:10:1
														</td>
														<td>
															14.07.2014 10:16:36
					");
            WriteLiteral(@"									</td>
														<td>
															<p class=""small"">
																Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).
															</p>
														</td>

													</tr>
													<tr>
														<td>
															<span class=""label label-primary""><i class=""fa fa-check""></i> Sent</span>
														</td>
														<td>
															There are many variations
														</td>
														<td>
															12.07.2014 10:10:1
														</td>
														<td>
															14.07.2014 10:16:36
														</td>
														<td>
															<p class=""small"">
																There are many variations of passages of Lorem Ipsum available, but the majority have suffered alteration in some form, by injected humour, or randomised words which
															</p>
														</td>

													</tr>
													<tr>
														<td>
															<span clas");
            WriteLiteral(@"s=""label label-primary""><i class=""fa fa-check""></i> Reported</span>
														</td>
														<td>
															Latin words
														</td>
														<td>
															12.07.2014 10:10:1
														</td>
														<td>
															14.07.2014 10:16:36
														</td>
														<td>
															<p class=""small"">
																Latin words, combined with a handful of model sentence structures
															</p>
														</td>

													</tr>
													<tr>
														<td>
															<span class=""label label-primary""><i class=""fa fa-check""></i> Accepted</span>
														</td>
														<td>
															The generated Lorem
														</td>
														<td>
															12.07.2014 10:10:1
														</td>
														<td>
															14.07.2014 10:16:36
														</td>
														<td>
															<p class=""small"">
																The generated Lorem Ipsum is therefore always free from r");
            WriteLiteral(@"epetition, injected humour, or non-characteristic words etc.
															</p>
														</td>

													</tr>
													<tr>
														<td>
															<span class=""label label-primary""><i class=""fa fa-check""></i> Sent</span>
														</td>
														<td>
															The first line
														</td>
														<td>
															12.07.2014 10:10:1
														</td>
														<td>
															14.07.2014 10:16:36
														</td>
														<td>
															<p class=""small"">
																The first line of Lorem Ipsum, ""Lorem ipsum dolor sit amet.."", comes from a line in section 1.10.32.
															</p>
														</td>

													</tr>
													<tr>
														<td>
															<span class=""label label-primary""><i class=""fa fa-check""></i> Reported</span>
														</td>
														<td>
															The standard chunk
														</td>
														<td>
															12.07.2014 10:10:1
		");
            WriteLiteral(@"												</td>
														<td>
															14.07.2014 10:16:36
														</td>
														<td>
															<p class=""small"">
																The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested.
															</p>
														</td>

													</tr>
													<tr>
														<td>
															<span class=""label label-primary""><i class=""fa fa-check""></i> Completed</span>
														</td>
														<td>
															Lorem Ipsum is that
														</td>
														<td>
															12.07.2014 10:10:1
														</td>
														<td>
															14.07.2014 10:16:36
														</td>
														<td>
															<p class=""small"">
																Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable.
															</p>
														</td>

													</tr>
													<tr>
			");
            WriteLiteral(@"											<td>
															<span class=""label label-primary""><i class=""fa fa-check""></i> Sent</span>
														</td>
														<td>
															Contrary to popular
														</td>
														<td>
															12.07.2014 10:10:1
														</td>
														<td>
															14.07.2014 10:16:36
														</td>
														<td>
															<p class=""small"">
																Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in a piece of classical
															</p>
														</td>

													</tr>

												</tbody>
											</table>

										</div>
									</div>

								</div>

							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
    </div>
    <div class=""col-lg-3"">
        <div class=""wrapper wrapper-content project-manager"">
            <h4>Project description</h4>
            <img");
            BeginWriteAttribute("src", " src=\"", 9147, "\"", 9168, 1);
#nullable restore
#line 304 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Training\Areas\Courses\Views\Home\Details.cshtml"
WriteAttributeValue("", 9153, Model.ImageUrl, 9153, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 9169, "\"", 9186, 1);
#nullable restore
#line 304 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Training\Areas\Courses\Views\Home\Details.cshtml"
WriteAttributeValue("", 9175, Model.Name, 9175, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"img-responsive\">\r\n            <p class=\"small\">\r\n                ");
#nullable restore
#line 306 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Training\Areas\Courses\Views\Home\Details.cshtml"
           Write(Model.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </p>\r\n");
            WriteLiteral("            <div class=\"m-t-md\">\r\n                ");
#nullable restore
#line 319 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Training\Areas\Courses\Views\Home\Details.cshtml"
           Write(await Component.InvokeAsync("CourseModules", new { studentId = @Model.StudentId, courseId = @Model.CourseId }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n            <hr/>\r\n");
#nullable restore
#line 322 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Training\Areas\Courses\Views\Home\Details.cshtml"
             if (!Model.Started)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "73245a447364f4f97d258176a2e38c86843f08ae22042", async() => {
                WriteLiteral("Start Course");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-moduleId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 324 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Training\Areas\Courses\Views\Home\Details.cshtml"
                                                                                                                            WriteLiteral(Model.CurrentModuleId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["moduleId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-moduleId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["moduleId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 325 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Training\Areas\Courses\Views\Home\Details.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "73245a447364f4f97d258176a2e38c86843f08ae25174", async() => {
                WriteLiteral("Start Course");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-moduleId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 328 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Training\Areas\Courses\Views\Home\Details.cshtml"
                                                                                                                            WriteLiteral(Model.CurrentModuleId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["moduleId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-moduleId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["moduleId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 329 "C:\Users\Admin\Desktop\Work\IqTechSolution\Projects\EnviroMetsi\Metsi.Web\Metsi.Web.Training\Areas\Courses\Views\Home\Details.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Education.Base.ApiModels.StudentCourseApiModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
