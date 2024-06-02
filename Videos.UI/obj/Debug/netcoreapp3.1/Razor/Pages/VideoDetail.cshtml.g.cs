#pragma checksum "D:\Users\15380\Source\Repos\Videos\Videos.UI\Pages\VideoDetail.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "de0921a42e4f42a55f1dd211543628467c5528316d3fbcd86e6a1ab7d0a3832c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Videos.UI.Pages.Pages_VideoDetail), @"mvc.1.0.view", @"/Pages/VideoDetail.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"de0921a42e4f42a55f1dd211543628467c5528316d3fbcd86e6a1ab7d0a3832c", @"/Pages/VideoDetail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"3c0ade19a894f4c6bafd4c97e19525c65b86e9d677e2eaa826ea978498c53a06", @"/Pages/_ViewImports.cshtml")]
    #nullable restore
    public class Pages_VideoDetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Videos.Application.Video.GetVideo.VideoViewModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Users\15380\Source\Repos\Videos\Videos.UI\Pages\VideoDetail.cshtml"
  
	string authorQuote = "@" + Model.AuthorName;

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"myContainer\">\r\n\t<table>\r\n\t\t<tr>\r\n\t\t\t<td>\r\n\t\t\t\t<blockquote class=\"tiktok-embed\"");
            BeginWriteAttribute("cite", " cite=\"", 201, "\"", 264, 4);
            WriteAttributeValue("", 208, "https://www.tiktok.com/", 208, 23, true);
#nullable restore
#line 9 "D:\Users\15380\Source\Repos\Videos\Videos.UI\Pages\VideoDetail.cshtml"
WriteAttributeValue("", 231, authorQuote, 231, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 243, "/video/", 243, 7, true);
#nullable restore
#line 9 "D:\Users\15380\Source\Repos\Videos\Videos.UI\Pages\VideoDetail.cshtml"
WriteAttributeValue("", 250, Model.VideoId, 250, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("\r\n\t\t\t\t\t\t\tdata-video-id=\"");
#nullable restore
#line 10 "D:\Users\15380\Source\Repos\Videos\Videos.UI\Pages\VideoDetail.cshtml"
                 Write(Model.VideoId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" style=\"max-width: 605px;min-width: 325px;\">\r\n\t\t\t\t\t<section> </section>\r\n\t\t\t\t</blockquote>\r\n\t\t\t</td>\r\n\t\t\t<td>\r\n\t\t\t\tCreate Time: ");
#nullable restore
#line 15 "D:\Users\15380\Source\Repos\Videos\Videos.UI\Pages\VideoDetail.cshtml"
            Write(Model.CreateTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n\t\t\t\tDuration: ");
#nullable restore
#line 16 "D:\Users\15380\Source\Repos\Videos\Videos.UI\Pages\VideoDetail.cshtml"
         Write(Model.Duration);

#line default
#line hidden
#nullable disable
            WriteLiteral(" s<br />\r\n\t\t\t\tRatio: ");
#nullable restore
#line 17 "D:\Users\15380\Source\Repos\Videos\Videos.UI\Pages\VideoDetail.cshtml"
      Write(Model.Ratio);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n\t\t\t\tFormat: ");
#nullable restore
#line 18 "D:\Users\15380\Source\Repos\Videos\Videos.UI\Pages\VideoDetail.cshtml"
       Write(Model.Format);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n\t\t\t\tHeight: ");
#nullable restore
#line 19 "D:\Users\15380\Source\Repos\Videos\Videos.UI\Pages\VideoDetail.cshtml"
       Write(Model.Height);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n\t\t\t\tSize: ");
#nullable restore
#line 20 "D:\Users\15380\Source\Repos\Videos\Videos.UI\Pages\VideoDetail.cshtml"
     Write(Model.Size);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n\t\t\t\tVideo Quality: ");
#nullable restore
#line 21 "D:\Users\15380\Source\Repos\Videos\Videos.UI\Pages\VideoDetail.cshtml"
              Write(Model.VideoQuality);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br /><hr />\r\n\t\t\t\t\r\n");
#nullable restore
#line 23 "D:\Users\15380\Source\Repos\Videos\Videos.UI\Pages\VideoDetail.cshtml"
      
					foreach (var review in Model.Reviews)
					{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t<p>");
#nullable restore
#line 26 "D:\Users\15380\Source\Repos\Videos\Videos.UI\Pages\VideoDetail.cshtml"
    Write(review);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\t\t\t\t\t\t<hr />\r\n");
#nullable restore
#line 28 "D:\Users\15380\Source\Repos\Videos\Videos.UI\Pages\VideoDetail.cshtml"
					}
				

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
				<div class=""container mt-5"">
					<div class=""form-group"">
						<label>Your Comment</label>
						<textarea class=""form-control"" id=""exampleFormControlTextarea1"" rows=""4"" cols=""50""></textarea>
					</div>
				</div>
			</td>
		</tr>
	</table>
</div>
<script async src=""https://www.tiktok.com/embed.js""></script>

");
            DefineSection("HeadContent", async() => {
                WriteLiteral(@"
	<style type=""text/css"">
		.myContainer {
			display: flex;
			justify-content: center;
			align-items: center;
			height: 100vh; /* Adjust as needed */
		}

		table {
			border-collapse: separate;
			border-spacing: 100px;
		}

		td {
			border: 0px solid black; /* For demonstration purposes */
			padding: 10px; /* Optional: Add padding to cells */
		}
	</style>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Videos.Application.Video.GetVideo.VideoViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
