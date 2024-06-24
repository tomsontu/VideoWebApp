#pragma checksum "D:\Users\15380\Source\Repos\Videos\Videos.UI\Pages\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "70bcb101342fc6df9cf6e9374501fd19577609682a6880d2a3ae7822e9778ca1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Videos.UI.Pages.Pages_Index), @"mvc.1.0.razor-page", @"/Pages/Index.cshtml")]
namespace Videos.UI.Pages
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Users\15380\Source\Repos\Videos\Videos.UI\Pages\_ViewImports.cshtml"
using Videos.UI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Users\15380\Source\Repos\Videos\Videos.UI\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"70bcb101342fc6df9cf6e9374501fd19577609682a6880d2a3ae7822e9778ca1", @"/Pages/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"3c0ade19a894f4c6bafd4c97e19525c65b86e9d677e2eaa826ea978498c53a06", @"/Pages/_ViewImports.cshtml")]
    #nullable restore
    public class Pages_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/video.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral(@"<div class=""d-flex justify-content-center mt-4"">
	<div id=""app"">

		<div class=""form-group form-inline"">
			<input type=""text"" class=""form-control"" v-model=""searchQuery"" style=""width:360px"" placeholder=""Search keywords/descriptions..."">
			&nbsp;&nbsp;
			<button class=""btn btn-success"" ");
            WriteLiteral("@click=\"search\">Search</button>\r\n\t\t\t&nbsp;&nbsp;\r\n\t\t\t<button class=\"btn btn-warning\" ");
            WriteLiteral(@"@click=""reset"">Reset</button>
		</div>

		<table class=""table"" style=""text-align:center"">
			<th>Id</th>
			<th>Author Name</th>
			<th>Description</th>
			<th>Create Time</th>
			<th>Like ♥</th>
			<th>Duration</th>
			<th>Remark</th>
			<th>Action</th>

			<tr v-for=""(video, index) in displayedVideos"" :key=""index"">
				<td><a v-bind:href=""video.videoUrl"">{{video.id}}</a></td>
				<td><a");
            BeginWriteAttribute("v-bind:href", " v-bind:href=\"", 813, "\"", 869, 2);
            WriteAttributeValue("", 827, "\'https://www.tiktok.com/", 827, 24, true);
            WriteLiteral("@");
            WriteAttributeValue("", 853, "\'+video.authorId", 853, 16, true);
            EndWriteAttribute();
            WriteLiteral(@">{{video.authorName}}</a></td>
				<td>{{video.description}}</td>
				<td>{{video.createTime}}</td>
				<td>{{video.diggCount}}</td>
				<td>{{video.duration}}s</td>
				<td>{{video.remark}}</td>
				<td><a v-bind:href=""'/video/videos/'+video.videoId"">View</a></td>
			</tr>
		</table>

		<!-- Pagination controls -->
		<div class=""d-flex justify-content-center mt-4"">
			<button class=""btn btn-primary mr-2"" ");
            WriteLiteral("@click=\"firstPage\" :disabled=\"currentPage === 1\">|←</button>\r\n\t\t\t<button class=\"btn btn-primary mr-2\" ");
            WriteLiteral("@click=\"previousPage\" :disabled=\"currentPage === 1\">←</button>\r\n\t\t\t<span class=\"align-self-center\">Page <b>{{ currentPage }}</b> of <b>{{ totalPages }}</b></span>\r\n\t\t\t<button class=\"btn btn-primary ml-2\" ");
            WriteLiteral("@click=\"nextPage\" :disabled=\"currentPage === totalPages\">→</button>\r\n\t\t\t<button class=\"btn btn-primary ml-2\" ");
            WriteLiteral("@click=\"lastPage\" :disabled=\"currentPage === totalPages\">→|</button>\r\n\t\t</div>\r\n\r\n\t</div>\r\n</div>\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n\r\n\t");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "70bcb101342fc6df9cf6e9374501fd19577609682a6880d2a3ae7822e9778ca16053", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n\r\n");
            }
            );
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexModel> Html { get; private set; } = default!;
        #nullable disable
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel>)PageContext?.ViewData;
        public IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
