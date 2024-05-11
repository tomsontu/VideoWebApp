#pragma checksum "D:\Users\15380\Source\Repos\Videos\Videos.UI\Pages\Dashboard.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "a8fef80610a0b7985bc20e34e4a8da6d48293dd571aed64eecbcf85a32d632ac"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Videos.UI.Pages.Pages_Dashboard), @"mvc.1.0.razor-page", @"/Pages/Dashboard.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"a8fef80610a0b7985bc20e34e4a8da6d48293dd571aed64eecbcf85a32d632ac", @"/Pages/Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"3c0ade19a894f4c6bafd4c97e19525c65b86e9d677e2eaa826ea978498c53a06", @"/Pages/_ViewImports.cshtml")]
    #nullable restore
    public class Pages_Dashboard : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\Users\15380\Source\Repos\Videos\Videos.UI\Pages\Dashboard.cshtml"
  
	List<string> labels = Model.CreatedCountByMonth.Keys.ToList().Select(x => x.Year.ToString() + "/" + x.Month.ToString()).ToList();
	List<int> values = Model.CreatedCountByMonth.Values.ToList();

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div style=""display: flex;"">
	<div style=""flex: 1;"">
		<canvas id=""barChart""></canvas>
	</div>
	<div style=""flex: 1;"">
		<canvas id=""pieChart""></canvas>
	</div>
</div>

<script src=""https://cdn.jsdelivr.net/npm/chart.js""></script>

<script>
    const labels = ");
#nullable restore
#line 19 "D:\Users\15380\Source\Repos\Videos\Videos.UI\Pages\Dashboard.cshtml"
              Write(Html.Raw(Json.Serialize(labels)));

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n    const values = ");
#nullable restore
#line 20 "D:\Users\15380\Source\Repos\Videos\Videos.UI\Pages\Dashboard.cshtml"
              Write(Html.Raw(Json.Serialize(values)));

#line default
#line hidden
#nullable disable
            WriteLiteral(@";

    const barCtx = document.getElementById('barChart');
    const pieCtx = document.getElementById('pieChart');

    new Chart(barCtx, {
        type: 'bar',
        data: {
            labels: labels,
            datasets: [{
                label: '# of Votes',
                data: values,
                borderWidth: 1
            }]
        },
        options: {
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
    });

    new Chart(pieCtx, {
        type: 'pie',
        data: {
            labels: labels,
            datasets: [{
                label: '# of Votes',
                data: values,
                borderWidth: 1
            }]
        },
        options: {
            responsive: true
        }
    });
</script>



");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Videos.UI.Pages.DashboardModel> Html { get; private set; } = default!;
        #nullable disable
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Videos.UI.Pages.DashboardModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Videos.UI.Pages.DashboardModel>)PageContext?.ViewData;
        public Videos.UI.Pages.DashboardModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
