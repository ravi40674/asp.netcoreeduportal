#pragma checksum "D:\Digital Vichar Projects\EducationPortal\EducationPortal\Views\Recipient\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c60146ec246e26d32bf0d50cea9663f92aa8a52f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Recipient_Index), @"mvc.1.0.view", @"/Views/Recipient/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c60146ec246e26d32bf0d50cea9663f92aa8a52f", @"/Views/Recipient/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"875253d060e4281d80190ac96fe7860f2c374707", @"/Views/_ViewImports.cshtml")]
    public class Views_Recipient_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<EducationPortal.Models.tblRecipient>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/jquery-confirm.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Save", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Recipient", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "D:\Digital Vichar Projects\EducationPortal\EducationPortal\Views\Recipient\Index.cshtml"
  
    ViewData["Title"] = "CategoryList";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("style", async() => {
                WriteLiteral("\r\n    <link rel=\"stylesheet\" href=\"https://kendo.cdn.telerik.com/2020.1.219/styles/kendo.default-v2.min.css\" />\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c60146ec246e26d32bf0d50cea9663f92aa8a52f6884", async() => {
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
            WriteLiteral("\r\n");
#nullable restore
#line 12 "D:\Digital Vichar Projects\EducationPortal\EducationPortal\Views\Recipient\Index.cshtml"
  
    System.Data.DataTable dtRolePrivileges = ViewData["RolePrivileges"] as System.Data.DataTable;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"page-header\">\r\n    <div class=\"row\">\r\n        <div class=\"col-sm-12\">\r\n            <br />\r\n");
#nullable restore
#line 20 "D:\Digital Vichar Projects\EducationPortal\EducationPortal\Views\Recipient\Index.cshtml"
             if (TempData["success"] != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"alert alert-success alert-dismmissible text-center\">\r\n                    <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"close\">&times;</a>\r\n                    <strong>Success!</strong> ");
#nullable restore
#line 24 "D:\Digital Vichar Projects\EducationPortal\EducationPortal\Views\Recipient\Index.cshtml"
                                         Write(TempData["success"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </div>\r\n");
#nullable restore
#line 26 "D:\Digital Vichar Projects\EducationPortal\EducationPortal\Views\Recipient\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n            <h3 class=\"page-title\">Category List</h3>\r\n");
#nullable restore
#line 28 "D:\Digital Vichar Projects\EducationPortal\EducationPortal\Views\Recipient\Index.cshtml"
             if (Convert.ToBoolean(dtRolePrivileges.Rows[5]["Add"]))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c60146ec246e26d32bf0d50cea9663f92aa8a52f9932", async() => {
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
#line 31 "D:\Digital Vichar Projects\EducationPortal\EducationPortal\Views\Recipient\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</div>\r\n<div class=\"card m-b-30\">\r\n    <div class=\"card-body\">\r\n        <div id=\"UserGrid\"></div>\r\n    </div>\r\n</div>\r\n\r\n");
#nullable restore
#line 41 "D:\Digital Vichar Projects\EducationPortal\EducationPortal\Views\Recipient\Index.cshtml"
 if (Convert.ToBoolean(dtRolePrivileges.Rows[5]["Delete"]))
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""row"">
        <div class=""col-sm-12"">
            <div class=""row"">
                <div class=""col-sm-12"">
                    <button type=""submit"" class=""btn btn-secondary"" title=""Delete"" onclick=""return Check_CheckBox_Count('recipientID');""><i class=""fa fa-trash""></i> Delete</button>
                </div>
            </div>
        </div>
    </div>
");
#nullable restore
#line 52 "D:\Digital Vichar Projects\EducationPortal\EducationPortal\Views\Recipient\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n    <script src=\"https://kendo.cdn.telerik.com/2020.1.219/js/jquery.min.js\"></script>\r\n    <script src=\"https://kendo.cdn.telerik.com/2020.1.219/js/kendo.all.min.js\"></script>\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c60146ec246e26d32bf0d50cea9663f92aa8a52f13033", async() => {
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c60146ec246e26d32bf0d50cea9663f92aa8a52f14133", async() => {
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c60146ec246e26d32bf0d50cea9663f92aa8a52f15233", async() => {
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
#line 64 "D:\Digital Vichar Projects\EducationPortal\EducationPortal\Views\Recipient\Index.cshtml"
                 Write(Url.Content("~/Recipient/_AjaxBinding"));

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
                            recipientID: ""recipientID"",
                            fields: {
                                RoleName: {
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
            ");
                WriteLiteral("    sortable: true,\r\n                filterable: true,\r\n\r\n                    columns: [\r\n                        {\r\n                            title:\"Delete\",\r\n                            width: 50,\r\n                            headerTemplate:\'");
#nullable restore
#line 102 "D:\Digital Vichar Projects\EducationPortal\EducationPortal\Views\Recipient\Index.cshtml"
                                       Write(Convert.ToBoolean(dtRolePrivileges.Rows[5]["Delete"]));

#line default
#line hidden
#nullable disable
                WriteLiteral("\' == \'True\' ? \"<input type=\'checkbox\' id=\'allCheckBox\' name=\'allCheckBox\' title=\'check all records\' class=\'regular-checkbox\' onclick=\'return initializeAllCheckBox();\'/>\":\'\',\r\n                            template: \'");
#nullable restore
#line 103 "D:\Digital Vichar Projects\EducationPortal\EducationPortal\Views\Recipient\Index.cshtml"
                                  Write(Convert.ToBoolean(dtRolePrivileges.Rows[5]["Delete"]));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"' == 'True' ? ""<input class='singleCheckBox' name='chkDelete' id='#= recipientID#' type='checkbox' value='#=recipientID#' onclick='return initializeSingleCheckBox(this);'/>"":''
                        },
                        { field: ""email"", title: ""Email"" },

                            {
                                title: '");
#nullable restore
#line 108 "D:\Digital Vichar Projects\EducationPortal\EducationPortal\Views\Recipient\Index.cshtml"
                                   Write(Convert.ToBoolean(dtRolePrivileges.Rows[5]["Edit"]));

#line default
#line hidden
#nullable disable
                WriteLiteral("\' == \'True\' ? \'Edit\':\'\',\r\n                                template: \'");
#nullable restore
#line 109 "D:\Digital Vichar Projects\EducationPortal\EducationPortal\Views\Recipient\Index.cshtml"
                                      Write(Convert.ToBoolean(dtRolePrivileges.Rows[5]["Edit"]));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"' == 'True' ? '<a href=""/Recipient/Save?id=#=recipientID#""><img src=""image/image-icon/edit.png"" /></a>':'',
                                width: 100
                            },
                            {
                                title: '");
#nullable restore
#line 113 "D:\Digital Vichar Projects\EducationPortal\EducationPortal\Views\Recipient\Index.cshtml"
                                   Write(Convert.ToBoolean(dtRolePrivileges.Rows[5]["Detail"]));

#line default
#line hidden
#nullable disable
                WriteLiteral("\' == \'True\' ? \'Detail\':\'\',\r\n                                template: \'");
#nullable restore
#line 114 "D:\Digital Vichar Projects\EducationPortal\EducationPortal\Views\Recipient\Index.cshtml"
                                      Write(Convert.ToBoolean(dtRolePrivileges.Rows[5]["Detail"]));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"' == 'True' ? '<a href=""/Recipient/Details?id=#=recipientID#""><img src=""image/image-icon/info.png"" /></a>':'',
                                width: 100
                            },
                    ],
                editable: false
            });
        }

        function Check_CheckBox_Count(deleteName) {

            var b = $('input[name=chkDelete]');
            var selectval = b.filter(':checked').length;
            var SiteBaseUrl = SiteUrl + ""Recipient/Delete"";
            if (selectval > 0) {
                $.confirm({
                    title: 'Alert!',
                    content: 'Are you sure? Do you want to delete record(s)?',
                    type: 'red',
                    icon: 'fa fa-warning',
                    buttons: {
                        confirm: function () {
                            checks = [];
                            $(""input[name=chkDelete]:checkbox"").each(function () {
                                if (this.checked) {
        ");
                WriteLiteral(@"                            checks.push(this.value);
                                }
                            });
                            $.post(SiteBaseUrl, { recipientID: checks }, function (result) {
                                if (result) {
                                    window.location.reload();
                                }
                                else {
                                    alert(""Something Went Wrong!"");
                                }
                            });
                        },
                        cancel: function () {
                            return;
                        }
                    }
                });
                console.log(recipientID);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<EducationPortal.Models.tblRecipient>> Html { get; private set; }
    }
}
#pragma warning restore 1591
