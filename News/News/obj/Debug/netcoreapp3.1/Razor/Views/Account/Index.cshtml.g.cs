#pragma checksum "C:\Users\ASUS\source\repos\News\News\Views\Account\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f548c82261a370b1ae8cfb97210f873c725b6fca"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Index), @"mvc.1.0.view", @"/Views/Account/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f548c82261a370b1ae8cfb97210f873c725b6fca", @"/Views/Account/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"099ef9e36d23f5c69976c5942300df24ac2f9f52", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<VmProfile>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_DashboardNavbar", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_MyAccount", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\ASUS\source\repos\News\News\Views\Account\Index.cshtml"
  
    ViewData["Title"] = "My Account";
    ViewBag.Section = "dashboard";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""page-title"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-12 col-md-12"">

                <h2 class=""ipt-title"">Welcome!</h2>
                <span class=""ipn-subtitle"">Welcome To Your Account</span>

            </div>
        </div>
    </div>
</div>

<section class=""bg-light"">
    <div class=""container-fluid"">

        <div class=""row"">

            <div class=""col-lg-3 col-md-12"">

                <div class=""simple-sidebar sm-sidebar"" id=""filter_search"">

                    <div class=""search-sidebar_header"">
                        <h4 class=""ssh_heading"">Close Filter</h4>
                        <button onclick=""closeFilterSearch()"" class=""w3-bar-item w3-button w3-large""><i class=""ti-close""></i></button>
                    </div>

                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f548c82261a370b1ae8cfb97210f873c725b6fca5235", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

                </div>
            </div>

            <div class=""col-lg-9 col-md-12"">

                <div class=""row"">
                    <div class=""col-lg-12 col-md-12 col-sm-12"">
                        <br />
                    </div>
                </div>

                <div class=""row"">

                    <div class=""col-lg-4 col-md-6 col-sm-12"">
                        <div class=""dashboard-stat widget-1"">
                            <div class=""dashboard-stat-content""><h4>");
#nullable restore
#line 52 "C:\Users\ASUS\source\repos\News\News\Views\Account\Index.cshtml"
                                                               Write(Model.Posts.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h4> <span>My News</span></div>
                            <div class=""dashboard-stat-icon""><i class=""fas fa-blog""></i></div>
                        </div>
                    </div>

                    <div class=""col-lg-4 col-md-6 col-sm-12"">
                        <div class=""dashboard-stat widget-2"">
                            <div class=""dashboard-stat-content""><h4>");
#nullable restore
#line 59 "C:\Users\ASUS\source\repos\News\News\Views\Account\Index.cshtml"
                                                               Write(Model.SavedNews.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h4> <span>Saved News</span></div>
                            <div class=""dashboard-stat-icon""><i class=""ti-bookmark""></i></div>
                        </div>
                    </div>

                    <div class=""col-lg-4 col-md-6 col-sm-12"">
                        <div class=""dashboard-stat widget-6"">
");
#nullable restore
#line 66 "C:\Users\ASUS\source\repos\News\News\Views\Account\Index.cshtml"
                             if (ViewBag.LastPostDate != null)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div class=\"dashboard-stat-content\"><h4>");
#nullable restore
#line 68 "C:\Users\ASUS\source\repos\News\News\Views\Account\Index.cshtml"
                                                                   Write(ViewBag.LastPostDate.Date.ToString("dd MMMM yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4> <span>Last News added date</span></div>\r\n");
#nullable restore
#line 69 "C:\Users\ASUS\source\repos\News\News\Views\Account\Index.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <div class=\"dashboard-stat-content\"><h4>0</h4> <span>Last News added date</span></div>\r\n");
#nullable restore
#line 73 "C:\Users\ASUS\source\repos\News\News\Views\Account\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            <div class=""dashboard-stat-icon""><i class=""far fa-clock""></i></div>
                        </div>
                    </div>

                </div>

                <div class=""dashboard-wraper"">

                    <!-- Basic Information -->
                    <!--My Account-->
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "f548c82261a370b1ae8cfb97210f873c725b6fca9791", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n                </div>\r\n            </div>\r\n\r\n        </div>\r\n    </div>\r\n</section>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<IdentityUser> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<VmProfile> Html { get; private set; }
    }
}
#pragma warning restore 1591
