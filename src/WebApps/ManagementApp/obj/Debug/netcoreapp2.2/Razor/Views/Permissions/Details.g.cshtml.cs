#pragma checksum "D:\GitLab\RMS\src\WebApps\ManagementApp\Views\Permissions\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "436df91cba6700937c1a428f3da50df0cf3cb857"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Permissions_Details), @"mvc.1.0.view", @"/Views/Permissions/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Permissions/Details.cshtml", typeof(AspNetCore.Views_Permissions_Details))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"436df91cba6700937c1a428f3da50df0cf3cb857", @"/Views/Permissions/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44ef6ad91415ccde4286eb92868bf285fd165d6b", @"/Views/_ViewImports.cshtml")]
    public class Views_Permissions_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ApplicationCore.ViewModel.User.PermissionViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(59, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\GitLab\RMS\src\WebApps\ManagementApp\Views\Permissions\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(104, 116, true);
            WriteLiteral("\r\n\r\n\r\n<div>\r\n    <h4>دسترسی ها</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(221, 52, false);
#line 14 "D:\GitLab\RMS\src\WebApps\ManagementApp\Views\Permissions\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.PermissionParent));

#line default
#line hidden
            EndContext();
            BeginContext(273, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(337, 51, false);
#line 17 "D:\GitLab\RMS\src\WebApps\ManagementApp\Views\Permissions\Details.cshtml"
       Write(Html.DisplayFor(model => model.PermissionParent.Id));

#line default
#line hidden
            EndContext();
            BeginContext(388, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(451, 41, false);
#line 20 "D:\GitLab\RMS\src\WebApps\ManagementApp\Views\Permissions\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Title));

#line default
#line hidden
            EndContext();
            BeginContext(492, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(556, 37, false);
#line 23 "D:\GitLab\RMS\src\WebApps\ManagementApp\Views\Permissions\Details.cshtml"
       Write(Html.DisplayFor(model => model.Title));

#line default
#line hidden
            EndContext();
            BeginContext(593, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(656, 40, false);
#line 26 "D:\GitLab\RMS\src\WebApps\ManagementApp\Views\Permissions\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Text));

#line default
#line hidden
            EndContext();
            BeginContext(696, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(760, 36, false);
#line 29 "D:\GitLab\RMS\src\WebApps\ManagementApp\Views\Permissions\Details.cshtml"
       Write(Html.DisplayFor(model => model.Text));

#line default
#line hidden
            EndContext();
            BeginContext(796, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(859, 39, false);
#line 32 "D:\GitLab\RMS\src\WebApps\ManagementApp\Views\Permissions\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Key));

#line default
#line hidden
            EndContext();
            BeginContext(898, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(962, 35, false);
#line 35 "D:\GitLab\RMS\src\WebApps\ManagementApp\Views\Permissions\Details.cshtml"
       Write(Html.DisplayFor(model => model.Key));

#line default
#line hidden
            EndContext();
            BeginContext(997, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1060, 39, false);
#line 38 "D:\GitLab\RMS\src\WebApps\ManagementApp\Views\Permissions\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.URL));

#line default
#line hidden
            EndContext();
            BeginContext(1099, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1163, 35, false);
#line 41 "D:\GitLab\RMS\src\WebApps\ManagementApp\Views\Permissions\Details.cshtml"
       Write(Html.DisplayFor(model => model.URL));

#line default
#line hidden
            EndContext();
            BeginContext(1198, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1261, 44, false);
#line 44 "D:\GitLab\RMS\src\WebApps\ManagementApp\Views\Permissions\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Priority));

#line default
#line hidden
            EndContext();
            BeginContext(1305, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1369, 40, false);
#line 47 "D:\GitLab\RMS\src\WebApps\ManagementApp\Views\Permissions\Details.cshtml"
       Write(Html.DisplayFor(model => model.Priority));

#line default
#line hidden
            EndContext();
            BeginContext(1409, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1472, 46, false);
#line 50 "D:\GitLab\RMS\src\WebApps\ManagementApp\Views\Permissions\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.SateIsPage));

#line default
#line hidden
            EndContext();
            BeginContext(1518, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1582, 42, false);
#line 53 "D:\GitLab\RMS\src\WebApps\ManagementApp\Views\Permissions\Details.cshtml"
       Write(Html.DisplayFor(model => model.SateIsPage));

#line default
#line hidden
            EndContext();
            BeginContext(1624, 55, true);
            WriteLiteral("\r\n        </dd>\r\n      \r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(1679, 56, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "436df91cba6700937c1a428f3da50df0cf3cb8579777", async() => {
                BeginContext(1725, 6, true);
                WriteLiteral("ویرایش");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 59 "D:\GitLab\RMS\src\WebApps\ManagementApp\Views\Permissions\Details.cshtml"
                           WriteLiteral(Model.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1735, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(1743, 40, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "436df91cba6700937c1a428f3da50df0cf3cb85712093", async() => {
                BeginContext(1765, 14, true);
                WriteLiteral("بازگشت به لیست");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1783, 10, true);
            WriteLiteral("\r\n</div>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ApplicationCore.ViewModel.User.PermissionViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
