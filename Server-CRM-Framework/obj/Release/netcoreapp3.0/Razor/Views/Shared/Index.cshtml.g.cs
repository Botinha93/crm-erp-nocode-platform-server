#pragma checksum "C:\Users\Botin\source\repos\Server-CRM-Framework\Server-CRM-Framework\Views\Shared\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4a3ecdb98e9027bc097cfb39a7db32d8ba295b09"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Index), @"mvc.1.0.view", @"/Views/Shared/Index.cshtml")]
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
#line 1 "C:\Users\Botin\source\repos\Server-CRM-Framework\Server-CRM-Framework\Views\_ViewImports.cshtml"
using Server_CRM_Framework;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Botin\source\repos\Server-CRM-Framework\Server-CRM-Framework\Views\_ViewImports.cshtml"
using Server_CRM_Framework.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a3ecdb98e9027bc097cfb39a7db32d8ba295b09", @"/Views/Shared/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5b65ff4d2dec8459cb540089e6ccab22f0f66b42", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Botin\source\repos\Server-CRM-Framework\Server-CRM-Framework\Views\Shared\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div id=""top-bar""></div>
<div id=""app-container"" class=""fleRow"">
    <div id=""side-menu-container""><div id=""side-menu-header"" onclick=""sidemenuheaderClick(event)""><img src=""images/menu-1.png"" /><h3 style="" flex-grow: 1; margin-top: 17px;"">Menu</h3></div><ul id=""side-menu""></li></ul></div>
    <div id=""app-container"" class=""flexColumn"">
        <div id=""nav-bar""><ul id=""nav-bar-menu""></ul><div id=""nav-bar-dropmenu-buttom"">... <ul id=""nav-bar-dropmenu""></ul></div></div>
        <div id=""div-content""></div>
    </div>
</div>
<div id=""login-form-bg"">
    <div id=""login-form"">
        <div class=""imgbg"">
            <img src=""images/User-Login.png"" />
        </div>
        <h2>ACCOUNT LOGIN</h2>
        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4a3ecdb98e9027bc097cfb39a7db32d8ba295b094267", async() => {
                WriteLiteral("\r\n            <h1>User</h1>\r\n            <input type=\"text\" autocomplete=\"username\">\r\n            <h1>Password</h1>\r\n            <input type=\"password\" autocomplete=\"current-password\">\r\n            <button>Login</button>\r\n        ");
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
<script type=""module"">
    var sidemenuheaderStatus = true;
    function sidemenuheaderClick(event) {
        if (sidemenuheaderStatus)
            document.getElementById('side-menu-container').style.width = '40px';
        else
            document.getElementById('side-menu-container').style.width = '';
    }
    import { loadingProcess } from './app-base/load.js'
</script>");
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
