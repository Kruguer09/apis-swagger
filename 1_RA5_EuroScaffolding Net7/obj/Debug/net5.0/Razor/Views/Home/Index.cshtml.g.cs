#pragma checksum "C:\Users\Usuario\Documents\IES TRASSIERRA 23-24\DI\_exam 2ª eval\_23-24\Examen final\recursos para alumnos\recursos para alumnos\EuroScaffolding2\Views\Home\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "99c2d270b0e2a3b8cba24921ca1d2b8244d26bbdb0e360b6042a2114608790a0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
namespace AspNetCore
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
#line 1 "C:\Users\Usuario\Documents\IES TRASSIERRA 23-24\DI\_exam 2ª eval\_23-24\Examen final\recursos para alumnos\recursos para alumnos\EuroScaffolding2\Views\_ViewImports.cshtml"
using EuroScaffolding2;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Usuario\Documents\IES TRASSIERRA 23-24\DI\_exam 2ª eval\_23-24\Examen final\recursos para alumnos\recursos para alumnos\EuroScaffolding2\Views\_ViewImports.cshtml"
using EuroScaffolding2.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"99c2d270b0e2a3b8cba24921ca1d2b8244d26bbdb0e360b6042a2114608790a0", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"e2afb52791b5ee98a7adbe591ea20266dbfcf56642863e6bbef3c83f06109699", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Usuario\Documents\IES TRASSIERRA 23-24\DI\_exam 2ª eval\_23-24\Examen final\recursos para alumnos\recursos para alumnos\EuroScaffolding2\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"text-center\">\r\n    <h1 class=\"display-4\">Welcome</h1>\r\n    <p>Learn about <a href=\"https://docs.microsoft.com/aspnet/core\">building Web apps with ASP.NET Core</a>.</p>\r\n\r\n\r\n    ");
#nullable restore
#line 10 "C:\Users\Usuario\Documents\IES TRASSIERRA 23-24\DI\_exam 2ª eval\_23-24\Examen final\recursos para alumnos\recursos para alumnos\EuroScaffolding2\Views\Home\Index.cshtml"
Write(Html.ActionLink("Lista de CANCIONES", "Index", "Canciones"));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n    ");
#nullable restore
#line 11 "C:\Users\Usuario\Documents\IES TRASSIERRA 23-24\DI\_exam 2ª eval\_23-24\Examen final\recursos para alumnos\recursos para alumnos\EuroScaffolding2\Views\Home\Index.cshtml"
Write(Html.ActionLink("Lista de FESTIVALES", "Index", "EdFestivales"));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n    ");
#nullable restore
#line 12 "C:\Users\Usuario\Documents\IES TRASSIERRA 23-24\DI\_exam 2ª eval\_23-24\Examen final\recursos para alumnos\recursos para alumnos\EuroScaffolding2\Views\Home\Index.cshtml"
Write(Html.ActionLink("Lista de PAISES", "Index", "Paises"));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
