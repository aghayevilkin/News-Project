#pragma checksum "C:\Users\ASUS\source\repos\News\News\Views\About\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0d56dd60794ae1d2aaa6c9294fc9a27fef471989"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_About_Index), @"mvc.1.0.view", @"/Views/About/Index.cshtml")]
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
#line 1 "C:\Users\ASUS\source\repos\News\News\Views\_ViewImports.cshtml"
using News;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ASUS\source\repos\News\News\Views\_ViewImports.cshtml"
using News.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ASUS\source\repos\News\News\Views\_ViewImports.cshtml"
using News.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\ASUS\source\repos\News\News\Views\_ViewImports.cshtml"
using News.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\ASUS\source\repos\News\News\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0d56dd60794ae1d2aaa6c9294fc9a27fef471989", @"/Views/About/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"099ef9e36d23f5c69976c5942300df24ac2f9f52", @"/Views/_ViewImports.cshtml")]
    public class Views_About_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<VmBase>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\ASUS\source\repos\News\News\Views\About\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!-- Page heading -->\r\n<div class=\"container p-t-4 p-b-35\">\r\n    <h2 class=\"f1-l-1 cl2\">\r\n");
#nullable restore
#line 9 "C:\Users\ASUS\source\repos\News\News\Views\About\Index.cshtml"
         if (Model != null)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\ASUS\source\repos\News\News\Views\About\Index.cshtml"
       Write(Model.About.Title);

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\ASUS\source\repos\News\News\Views\About\Index.cshtml"
                              
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </h2>
</div>

<!-- Content -->
<section class=""bg0 p-b-110"">
    <div class=""container"">
        <div class=""row justify-content-center"">
            <div class=""col-md-7 col-lg-8 p-b-30"">
                <div class=""p-r-10 p-r-0-sr991"">
                    <p class=""f1-s-11 cl6 p-b-25"">
");
#nullable restore
#line 23 "C:\Users\ASUS\source\repos\News\News\Views\About\Index.cshtml"
                         if (Model != null)
                        {
                           

#line default
#line hidden
#nullable disable
#nullable restore
#line 25 "C:\Users\ASUS\source\repos\News\News\Views\About\Index.cshtml"
                      Write(Html.Raw(Model.About.Content));

#line default
#line hidden
#nullable disable
#nullable restore
#line 25 "C:\Users\ASUS\source\repos\News\News\Views\About\Index.cshtml"
                                                         
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </p>
                </div>
            </div>

            <!-- Sidebar -->
            <div class=""col-md-5 col-lg-4 p-b-30"">
                <div class=""p-l-10 p-rl-0-sr991 p-t-5"">
                </div>
            </div>
        </div>
    </div>
</section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<VmBase> Html { get; private set; }
    }
}
#pragma warning restore 1591
