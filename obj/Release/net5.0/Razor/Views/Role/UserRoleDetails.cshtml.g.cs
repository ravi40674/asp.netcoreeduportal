#pragma checksum "D:\Digital Vichar Projects\EducationPortal\EducationPortal\Views\Role\UserRoleDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f18315a63a8da930ed0a0a570d0b39162f21484e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Role_UserRoleDetails), @"mvc.1.0.view", @"/Views/Role/UserRoleDetails.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f18315a63a8da930ed0a0a570d0b39162f21484e", @"/Views/Role/UserRoleDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"875253d060e4281d80190ac96fe7860f2c374707", @"/Views/_ViewImports.cshtml")]
    public class Views_Role_UserRoleDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EducationPortal.Models.tblRole>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Digital Vichar Projects\EducationPortal\EducationPortal\Views\Role\UserRoleDetails.cshtml"
  
    ViewData["Title"] = "UserRoleDetails";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div>\r\n    <h4>Role Details</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
#nullable restore
#line 12 "D:\Digital Vichar Projects\EducationPortal\EducationPortal\Views\Role\UserRoleDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.RoleName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
#nullable restore
#line 15 "D:\Digital Vichar Projects\EducationPortal\EducationPortal\Views\Role\UserRoleDetails.cshtml"
       Write(Html.DisplayFor(model => model.RoleName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\nStatus        </dt>\r\n        <dd class=\"col-sm-10\">\r\n");
#nullable restore
#line 20 "D:\Digital Vichar Projects\EducationPortal\EducationPortal\Views\Role\UserRoleDetails.cshtml"
             if (Model.IsActive)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <label>Active</label>\r\n");
#nullable restore
#line 23 "D:\Digital Vichar Projects\EducationPortal\EducationPortal\Views\Role\UserRoleDetails.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <label>Inactive</label>\r\n");
#nullable restore
#line 27 "D:\Digital Vichar Projects\EducationPortal\EducationPortal\Views\Role\UserRoleDetails.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
#nullable restore
#line 32 "D:\Digital Vichar Projects\EducationPortal\EducationPortal\Views\Role\UserRoleDetails.cshtml"
Write(Html.ActionLink("Update", "SaveUserRole","Role", new {  id = Model.RoleId  }, new { @class = "btn btn-primary" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" &nbsp;\r\n    ");
#nullable restore
#line 33 "D:\Digital Vichar Projects\EducationPortal\EducationPortal\Views\Role\UserRoleDetails.cshtml"
Write(Html.ActionLink("Back", "Index","Role",null,new { @class="btn btn-danger"}));

#line default
#line hidden
#nullable disable
            WriteLiteral(" \r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EducationPortal.Models.tblRole> Html { get; private set; }
    }
}
#pragma warning restore 1591
