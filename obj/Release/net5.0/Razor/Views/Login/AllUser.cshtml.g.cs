#pragma checksum "D:\Digital Vichar Projects\EducationPortal\EducationPortal\Views\Login\AllUser.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cc215be70447e2bf6aed124c42668b22cfeab410"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Login_AllUser), @"mvc.1.0.view", @"/Views/Login/AllUser.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc215be70447e2bf6aed124c42668b22cfeab410", @"/Views/Login/AllUser.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"875253d060e4281d80190ac96fe7860f2c374707", @"/Views/_ViewImports.cshtml")]
    public class Views_Login_AllUser : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EducationPortal.ViewModel.UserViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/jquery-confirm.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "SaveUser", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Login", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("margin-bottom:20px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary add-new"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/jquery-confirm.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/common.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/SiteUrl.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Digital Vichar Projects\EducationPortal\EducationPortal\Views\Login\AllUser.cshtml"
  
    ViewData["Title"] = "AllUser";
    Layout = "~/Views/Shared/_Layout.cshtml";


#line default
#line hidden
#nullable disable
            DefineSection("style", async() => {
                WriteLiteral("\r\n    <link rel=\"stylesheet\" href=\"https://kendo.cdn.telerik.com/2020.1.219/styles/kendo.default-v2.min.css\" />\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "cc215be70447e2bf6aed124c42668b22cfeab4106872", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
#nullable restore
#line 12 "D:\Digital Vichar Projects\EducationPortal\EducationPortal\Views\Login\AllUser.cshtml"
  
    System.Data.DataTable dtRolePrivileges = ViewData["RolePrivileges"] as System.Data.DataTable;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"page-header\">\r\n    <div class=\"row\">\r\n\r\n        <div class=\"col-sm-12\">\r\n            <br />\r\n");
#nullable restore
#line 21 "D:\Digital Vichar Projects\EducationPortal\EducationPortal\Views\Login\AllUser.cshtml"
             if (TempData["success"] != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"alert alert-success alert-dismmissible text-center\">\r\n                    <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>\r\n                    <strong>Success!</strong> ");
#nullable restore
#line 25 "D:\Digital Vichar Projects\EducationPortal\EducationPortal\Views\Login\AllUser.cshtml"
                                         Write(TempData["success"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n");
#nullable restore
#line 27 "D:\Digital Vichar Projects\EducationPortal\EducationPortal\Views\Login\AllUser.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n            <h3 class=\"page-title\">User</h3>\r\n");
#nullable restore
#line 29 "D:\Digital Vichar Projects\EducationPortal\EducationPortal\Views\Login\AllUser.cshtml"
             if (Convert.ToBoolean(dtRolePrivileges.Rows[1]["Add"]))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cc215be70447e2bf6aed124c42668b22cfeab4109870", async() => {
                WriteLiteral("<i class=\"fa fa-plus\"></i>  Add New");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 32 "D:\Digital Vichar Projects\EducationPortal\EducationPortal\Views\Login\AllUser.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</div>\r\n<div class=\"card m-b-30\">\r\n    <div class=\"card-body\">\r\n        <div id=\"UserGrid\"></div>\r\n    </div>\r\n\r\n</div>\r\n");
#nullable restore
#line 42 "D:\Digital Vichar Projects\EducationPortal\EducationPortal\Views\Login\AllUser.cshtml"
 if (Convert.ToBoolean(dtRolePrivileges.Rows[1]["Delete"]))
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""row"">
        <div class=""col-sm-12"">
            <div class=""row"">
                <div class=""col-sm-12"">
                    <button type=""submit"" class=""btn btn-secondary"" title=""Delete"" onclick=""return Check_CheckBox_Count('UserId');""><i class=""fa fa-trash""></i> Delete</button>
                </div>
            </div>
        </div>
    </div>
");
#nullable restore
#line 53 "D:\Digital Vichar Projects\EducationPortal\EducationPortal\Views\Login\AllUser.cshtml"
}

#line default
#line hidden
#nullable disable
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n    <script src=\"https://kendo.cdn.telerik.com/2020.1.219/js/jquery.min.js\"></script>\r\n    <script src=\"https://kendo.cdn.telerik.com/2020.1.219/js/kendo.all.min.js\"></script>\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cc215be70447e2bf6aed124c42668b22cfeab41012925", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cc215be70447e2bf6aed124c42668b22cfeab41014025", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cc215be70447e2bf6aed124c42668b22cfeab41015125", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    <script type=\"text/javascript\">\r\n          $(document).ready(function () {\r\n            $.ajax({\r\n                type: \"POST\",\r\n                url: \"");
#nullable restore
#line 64 "D:\Digital Vichar Projects\EducationPortal\EducationPortal\Views\Login\AllUser.cshtml"
                 Write(Url.Content("~/Login/_AjaxBinding"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@""",
                success: function (result) {
                    loadGrid(result);
                },
                error: function (req, status, error) {
                    alert(error);
                }
            });
          });

        function loadGrid(results) {
            $(""#UserGrid"").kendoGrid({
                dataSource: {
                    data: results,
                    cache: false,
                    schema: {
                        model: {
                            userId: ""userID"",
                            fields: {
                                FirstName: {
                                    type: ""string""
                                }
                            },
                        }
                    },
                    pageSize: 10
                },
                editable: false,
                selectable: true,
                pageable: { refresh: true },
                groupable: true,
                sorta");
                WriteLiteral("ble: true,\r\n                filterable: true,\r\n                    columns: [\r\n                        {\r\n                            title:\"Delete\",\r\n                            width: 50,\r\n                            headerTemplate: \'");
#nullable restore
#line 101 "D:\Digital Vichar Projects\EducationPortal\EducationPortal\Views\Login\AllUser.cshtml"
                                        Write(Convert.ToBoolean(dtRolePrivileges.Rows[1]["Delete"]));

#line default
#line hidden
#nullable disable
                WriteLiteral("\' == \'True\' ? \"<input type=\'checkbox\' id=\'allCheckBox\' name=\'allCheckBox\' title=\'check all records\' class=\'regular-checkbox\' onclick=\'return initializeAllCheckBox();\'/>\" : \'\',\r\n                            template: \'");
#nullable restore
#line 102 "D:\Digital Vichar Projects\EducationPortal\EducationPortal\Views\Login\AllUser.cshtml"
                                  Write(Convert.ToBoolean(dtRolePrivileges.Rows[1]["Delete"]));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"' == 'True' ? ""<input class='singleCheckBox' name='chkDelete' id='#= userID#' type='checkbox' value='#=userID#' onclick='return initializeSingleCheckBox(this);'>"" : ''
                        },
                        { field: ""firstName"", title: ""First Name"" },
                        { field: ""lastName"" , title: ""Last Name"" },
                        { field: ""email"", title: ""Email"" },
                        { field: ""address"", title: ""Address"" },
                        { field: ""mobileNumber"", title: ""Mobile Number"" },
                        {
                            title: '");
#nullable restore
#line 110 "D:\Digital Vichar Projects\EducationPortal\EducationPortal\Views\Login\AllUser.cshtml"
                               Write(Convert.ToBoolean(dtRolePrivileges.Rows[1]["Edit"]));

#line default
#line hidden
#nullable disable
                WriteLiteral("\' == \'True\' ? \'Edit\':\'\',\r\n                            template: \'");
#nullable restore
#line 111 "D:\Digital Vichar Projects\EducationPortal\EducationPortal\Views\Login\AllUser.cshtml"
                                  Write(Convert.ToBoolean(dtRolePrivileges.Rows[1]["Edit"]));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"' == 'True' ? '<img src=""~/image/image-icon/edit.png"" />' : '',
                            width: 100
                        },
                    ],
                editable: false
            });
        }

        function Check_CheckBox_Count(deleteName) {
            var $b = $('input[name=chkDelete]');
            var total_selected = $b.filter(':checked').length;
            if (total_selected > 0) {
                $.confirm({
                    title: 'Alert!',
                    content: 'Are you sure? Do you want to delete record(s)?',
                    type: 'red',
                    icon: 'fa fa-warning',
                    buttons: {
                        confirm: function () {
                            checked = [];
                            $(""input[name=chkDelete]:checkbox"").each(function () {
                                if (this.checked) {
                                    checked.push(this.value);
                                    var SiteBaseUr");
                WriteLiteral(@"l = SiteUrl + ""Login/Delete"";
                                    $.post(SiteBaseUrl, { userId: checked }, function (result) {
                                        if (result) {
                                            window.location.reload();
                                        }
                                        else {
                                            alert(""Something Went Wrong!"");
                                        }
                                    });
                                }
                            });
                        },
                        cancel: function () {
                            return;
                        }
                    }
                });
            }
            else {
                alert(""Please select at least one checkbox to delete."");
                return false;
            }
        }
    </script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EducationPortal.ViewModel.UserViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
