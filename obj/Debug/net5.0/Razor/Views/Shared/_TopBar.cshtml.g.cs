#pragma checksum "D:\Digital Vichar Projects\EducationPortal\EducationPortal\Views\Shared\_TopBar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d685ba6a8eb9f18c5bf00079c11dea92890af1de"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__TopBar), @"mvc.1.0.view", @"/Views/Shared/_TopBar.cshtml")]
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
#line 1 "D:\Digital Vichar Projects\EducationPortal\EducationPortal\Views\_ViewImports.cshtml"
using EducationPortal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Digital Vichar Projects\EducationPortal\EducationPortal\Views\_ViewImports.cshtml"
using EducationPortal.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\Digital Vichar Projects\EducationPortal\EducationPortal\Views\Shared\_TopBar.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d685ba6a8eb9f18c5bf00079c11dea92890af1de", @"/Views/Shared/_TopBar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"875253d060e4281d80190ac96fe7860f2c374707", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__TopBar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""topbar"">

    <nav class=""navbar-custom"">
        <ul class=""list-inline float-right mb-0"">
            <li class=""list-inline-item dropdown notification-list"">
                <a class=""nav-link dropdown-toggle arrow-none waves-effect nav-user"" data-toggle=""dropdown"" href=""#"" role=""button""
                   aria-haspopup=""false"" aria-expanded=""false"">
                    <p style=""color:white;vertical-align:middle;font-size:22px"">  Welcome,  <strong> ");
#nullable restore
#line 9 "D:\Digital Vichar Projects\EducationPortal\EducationPortal\Views\Shared\_TopBar.cshtml"
                                                                                                Write(Context.Session.GetString("uname"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></p>\r\n");
            WriteLiteral(@"                    <div class=""dropdown-menu dropdown-menu-right profile-dropdown "">
                        <!-- item-->
                        <div class=""dropdown-item noti-title"">
                            <h5>Welcome</h5>
                        </div>
                        <a class=""dropdown-item"" href=""#""><i class=""mdi mdi-account-circle m-r-5 text-muted""></i> Profile</a>
                        <a class=""dropdown-item"" href=""#""><i class=""mdi mdi-wallet m-r-5 text-muted""></i> My Wallet</a>
                        <a class=""dropdown-item"" href=""#""><span class=""badge badge-success float-right"">5</span><i class=""mdi mdi-settings m-r-5 text-muted""></i> Settings</a>
                        <a class=""dropdown-item"" href=""#""><i class=""mdi mdi-lock-open-outline m-r-5 text-muted""></i> Lock screen</a>
                        <div class=""dropdown-divider""></div>
                        <a class=""dropdown-item"" href=""#""><i class=""mdi mdi-logout m-r-5 text-muted""></i> Logout</a>
                   ");
            WriteLiteral(" </div>\r\n                </a>\r\n            </li>\r\n        </ul>\r\n        <div class=\"clearfix\"></div>\r\n    </nav>\r\n</div>");
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
