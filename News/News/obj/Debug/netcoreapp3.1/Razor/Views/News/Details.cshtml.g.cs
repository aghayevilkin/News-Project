#pragma checksum "C:\Users\ASUS\source\repos\News\News\Views\News\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a2af87b6d9cd98fa47fae4daf49324a6adae5722"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_News_Details), @"mvc.1.0.view", @"/Views/News/Details.cshtml")]
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
using News.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ASUS\source\repos\News\News\Views\_ViewImports.cshtml"
using News.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\ASUS\source\repos\News\News\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a2af87b6d9cd98fa47fae4daf49324a6adae5722", @"/Views/News/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"161a6f4aeb0c61b495cf5d6761ddb4e220572a81", @"/Views/_ViewImports.cshtml")]
    public class Views_News_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("max-w-full"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/banner-02.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("IMG"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\ASUS\source\repos\News\News\Views\News\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n<!-- Content -->\r\n<section class=\"bg0 p-b-70 p-t-5\">\r\n    <!-- Title -->\r\n    <div class=\"bg-img1 size-a-18 how-overlay1\"");
            BeginWriteAttribute("style", " style=\"", 172, "\"", 246, 4);
            WriteAttributeValue("", 180, "background-image:", 180, 17, true);
            WriteAttributeValue(" ", 197, "url(", 198, 5, true);
#nullable restore
#line 11 "C:\Users\ASUS\source\repos\News\News\Views\News\Details.cshtml"
WriteAttributeValue("", 202, Url.Content("~/images/blog-detail-01.jpg"), 202, 43, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 245, ")", 245, 1, true);
            EndWriteAttribute();
            WriteLiteral(@">
        <div class=""container h-full flex-col-e-c p-b-58"">
            <a href=""#"" class=""f1-s-10 cl0 hov-cl10 trans-03 text-uppercase txt-center m-b-33"">
                Technology
            </a>

            <h3 class=""f1-l-5 cl0 p-b-16 txt-center respon2"">
                Nulla non interdum metus non laoreet nisi tellus eget aliquam lorem pellentesque
            </h3>

            <div class=""flex-wr-c-s"">
                <span class=""f1-s-3 cl8 m-rl-7 txt-center"">
                    <a href=""#"" class=""f1-s-4 cl8 hov-cl10 trans-03"">
                        by John Alvarado
                    </a>

                    <span class=""m-rl-3"">-</span>

                    <span>
                        Feb 18
                    </span>
                </span>

                <span class=""f1-s-3 cl8 m-rl-7 txt-center"">
                    5239 Views
                </span>

                <a");
            BeginWriteAttribute("href", " href=\"", 1185, "\"", 1192, 0);
            EndWriteAttribute();
            WriteLiteral(@" class=""f1-s-3 cl8 m-rl-7 txt-center hov-cl10 trans-03"">
                    0 Comment
                </a>
            </div>
        </div>
    </div>

    <!-- Detail -->
    <div class=""container p-t-82"">
        <div class=""row justify-content-center"">
            <div class=""col-md-10 col-lg-8 p-b-100"">
                <div class=""p-r-10 p-r-0-sr991"">
                    <!-- Blog Detail -->
                    <div class=""p-b-70"">
                        <p class=""f1-s-11 cl6 p-b-25"">
                            Curabitur volutpat bibendum molestie. Vestibulum ornare gravida semper. Aliquam a dui suscipit, fringilla metus id, maximus leo. Vivamus sapien arcu, mollis eu pharetra vitae, condimentum in orci. Integer eu sodales dolor. Maecenas elementum arcu eu convallis rhoncus. Donec tortor sapien, euismod a faucibus eget, porttitor quis libero.
                        </p>

                        <p class=""f1-s-11 cl6 p-b-25"">
                            Lorem ipsum dolor sit amet, c");
            WriteLiteral(@"onsectetur adipiscing elit. Nunc sit amet est vel orci luctus sollicitudin. Duis eleifend vestibulum justo, varius semper lacus condimentum dictum. Donec pulvinar a magna ut malesuada. In posuere felis diam, vel sodales metus accumsan in. Duis viverra dui eu pharetra pellentesque. Donec a eros leo. Quisque sed ligula vitae lorem efficitur faucibus. Praesent sit amet imperdiet ante. Nulla id tellus auctor, dictum libero a, malesuada nisi. Nulla in porta nibh, id vestibulum ipsum. Praesent dapibus tempus erat quis aliquet. Donec ac purus id sapien condimentum feugiat.
                        </p>

                        <p class=""f1-s-11 cl6 p-b-25"">
                            Praesent vel mi bibendum, finibus leo ac, condimentum arcu. Pellentesque sem ex, tristique sit amet suscipit in, mattis imperdiet enim. Integer tempus justo nec velit fringilla, eget eleifend neque blandit. Sed tempor magna sed congue auctor. Mauris eu turpis eget tortor ultricies elementum. Phasellus vel placerat orci, a venenatis ");
            WriteLiteral(@"justo. Phasellus faucibus venenatis nisl vitae vestibulum. Praesent id nibh arcu. Vivamus sagittis accumsan felis, quis vulputate
                        </p>

                        <!-- Tag -->
                        <div class=""flex-s-s p-t-12 p-b-15"">
                            <span class=""f1-s-12 cl5 m-r-8"">
                                Tags:
                            </span>

                            <div class=""flex-wr-s-s size-w-0"">
                                <a href=""#"" class=""f1-s-12 cl8 hov-link1 m-r-15"">
                                    Streetstyle
                                </a>

                                <a href=""#"" class=""f1-s-12 cl8 hov-link1 m-r-15"">
                                    Crafts
                                </a>
                            </div>
                        </div>

                        <!-- Share -->
                        <div class=""flex-s-s"">
                            <span class=""f1-s-12 cl5 p-t-1 m-r");
            WriteLiteral(@"-15"">
                                Share:
                            </span>

                            <div class=""flex-wr-s-s size-w-0"">
                                <a href=""#"" class=""dis-block f1-s-13 cl0 bg-facebook borad-3 p-tb-4 p-rl-18 hov-btn1 m-r-3 m-b-3 trans-03"">
                                    <i class=""fab fa-facebook-f m-r-7""></i>
                                    Facebook
                                </a>

                                <a href=""#"" class=""dis-block f1-s-13 cl0 bg-twitter borad-3 p-tb-4 p-rl-18 hov-btn1 m-r-3 m-b-3 trans-03"">
                                    <i class=""fab fa-twitter m-r-7""></i>
                                    Twitter
                                </a>

                                <a href=""#"" class=""dis-block f1-s-13 cl0 bg-google borad-3 p-tb-4 p-rl-18 hov-btn1 m-r-3 m-b-3 trans-03"">
                                    <i class=""fab fa-google-plus-g m-r-7""></i>
                                    Google+
       ");
            WriteLiteral(@"                         </a>

                                <a href=""#"" class=""dis-block f1-s-13 cl0 bg-pinterest borad-3 p-tb-4 p-rl-18 hov-btn1 m-r-3 m-b-3 trans-03"">
                                    <i class=""fab fa-pinterest-p m-r-7""></i>
                                    Pinterest
                                </a>
                            </div>
                        </div>
                    </div>

                    <!-- Leave a comment -->
                    <div>
                        <h4 class=""f1-l-4 cl3 p-b-12"">
                            Leave a Comment
                        </h4>

                        <p class=""f1-s-13 cl8 p-b-40"">
                            Your email address will not be published. Required fields are marked *
                        </p>

                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a2af87b6d9cd98fa47fae4daf49324a6adae572211899", async() => {
                WriteLiteral(@"
                            <textarea class=""bo-1-rad-3 bocl13 size-a-15 f1-s-13 cl5 plh6 p-rl-18 p-tb-14 m-b-20"" name=""msg"" placeholder=""Comment...""></textarea>

                            <input class=""bo-1-rad-3 bocl13 size-a-16 f1-s-13 cl5 plh6 p-rl-18 m-b-20"" type=""text"" name=""name"" placeholder=""Name*"">

                            <input class=""bo-1-rad-3 bocl13 size-a-16 f1-s-13 cl5 plh6 p-rl-18 m-b-20"" type=""text"" name=""email"" placeholder=""Email*"">

                            <input class=""bo-1-rad-3 bocl13 size-a-16 f1-s-13 cl5 plh6 p-rl-18 m-b-20"" type=""text"" name=""website"" placeholder=""Website"">

                            <button class=""size-a-17 bg2 borad-3 f1-s-12 cl0 hov-btn1 trans-03 p-rl-15 m-t-10"">
                                Post Comment
                            </button>
                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
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
            </div>

            <div class=""col-md-10 col-lg-4 p-b-100"">
                <div class=""p-l-10 p-rl-0-sr991"">
                    <!-- Banner -->
                    <div class=""flex-c-s"">
                        <a href=""#"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "a2af87b6d9cd98fa47fae4daf49324a6adae572214342", async() => {
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
            WriteLiteral("\r\n                        </a>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>");
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
