#pragma checksum "C:\Users\Botin\source\repos\Server-CRM-Framework\Server-CRM-Framework\Views\login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ee6375fff8e0d1dcedfc1fb7209395e3831162fe"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_login), @"mvc.1.0.view", @"/Views/login.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ee6375fff8e0d1dcedfc1fb7209395e3831162fe", @"/Views/login.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5b65ff4d2dec8459cb540089e6ccab22f0f66b42", @"/Views/_ViewImports.cshtml")]
    public class Views_login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\Botin\source\repos\Server-CRM-Framework\Server-CRM-Framework\Views\login.cshtml"
  
    ViewData["Title"] = "login";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<script>
    function buttonLogin(){
                var xhr = new XMLHttpRequest();
                xhr.open('GET', ""loginProcess"", true);
                xhr.responseType = 'json';
                xhr.setRequestHeader('Content-Type', 'application/json');
                xhr.setRequestHeader('user', document.getElementById('login-form-user').value);
                xhr.setRequestHeader('pass', document.getElementById('login-form-pass').value);
                xhr.onload = function() {
                var status = xhr.status;
                    if (status === 200) {
                        if (xhr.response != ""Invalid"") {
                            console.log(xhr);
                            localStorage.setItem('token', xhr.response);
                            window.location.replace(""https://""+window.location.host);
                        }
                    } else if(status === 451){
                        window.location.replace(xhr.getResponseHeader(""location""));
             ");
            WriteLiteral(@"       }else {
                        console.log(status, xhr.response);
                    }
                };
                xhr.send();
            }
    localStorage.clear();
</script>
<div id=""login-form-bg"">
    <div id=""login-form"">
        <div class=""imgbg"">
            <img src=""images/User-Login.png"" />
        </div>
        <h2>ACCOUNT LOGIN</h2>
        <div style=""width: 280px;margin-left: -30px;"">
            <h1>User</h1>
            <input type=""text"" autocomplete=""username"" id=""login-form-user"">
            <h1>Password</h1>
            <input type=""password"" autocomplete=""current-password"" id=""login-form-pass"">
            <button onclick=""buttonLogin()"">Login</button>
        </div>
    </div>
</div>

");
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