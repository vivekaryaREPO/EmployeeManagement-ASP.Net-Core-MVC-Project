#pragma checksum "G:\Programming\DotNet\ASP-DOTNET-CORE-2.2\Project-1\EmployeeManagement-ASP.Net-Core-MVC-Project\EmployeeManagement-ASP.Net-Core-MVC-Project\Views\Shared\Error.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "64bd4d547276b37f960bc17dad8bc4768f779ea2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Error), @"mvc.1.0.view", @"/Views/Shared/Error.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Error.cshtml", typeof(AspNetCore.Views_Shared_Error))]
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
#line 11 "G:\Programming\DotNet\ASP-DOTNET-CORE-2.2\Project-1\EmployeeManagement-ASP.Net-Core-MVC-Project\EmployeeManagement-ASP.Net-Core-MVC-Project\Views\_ViewImports.cshtml"
using EmployeeManagement_ASP.Net_Core_MVC_Project.ViewModels;

#line default
#line hidden
#line 12 "G:\Programming\DotNet\ASP-DOTNET-CORE-2.2\Project-1\EmployeeManagement-ASP.Net-Core-MVC-Project\EmployeeManagement-ASP.Net-Core-MVC-Project\Views\_ViewImports.cshtml"
using EmployeeManagement_ASP.Net_Core_MVC_Project.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"64bd4d547276b37f960bc17dad8bc4768f779ea2", @"/Views/Shared/Error.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7201295602beff19c26467232bd78c71d5a7f7d9", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Error : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 296, true);
            WriteLiteral(@"<h3>
    An occured while processing your request. The support
    team is notified and we are working on the fix
</h3>
<h5>Please contact us on pragim@pragimtech.com</h5>
<hr />
<h3>Exception Details:</h3>
<div class=""alert alert-danger"">
    <h5>Exception Path</h5>
    <hr />
    <p>");
            EndContext();
            BeginContext(297, 21, false);
#line 11 "G:\Programming\DotNet\ASP-DOTNET-CORE-2.2\Project-1\EmployeeManagement-ASP.Net-Core-MVC-Project\EmployeeManagement-ASP.Net-Core-MVC-Project\Views\Shared\Error.cshtml"
  Write(ViewBag.ExceptionPath);

#line default
#line hidden
            EndContext();
            BeginContext(318, 101, true);
            WriteLiteral("</p>\r\n</div>\r\n\r\n<div class=\"alert alert-danger\">\r\n    <h5>Exception Message</h5>\r\n    <hr />\r\n    <p>");
            EndContext();
            BeginContext(420, 24, false);
#line 17 "G:\Programming\DotNet\ASP-DOTNET-CORE-2.2\Project-1\EmployeeManagement-ASP.Net-Core-MVC-Project\EmployeeManagement-ASP.Net-Core-MVC-Project\Views\Shared\Error.cshtml"
  Write(ViewBag.ExceptionMessage);

#line default
#line hidden
            EndContext();
            BeginContext(444, 105, true);
            WriteLiteral("</p>\r\n</div>\r\n\r\n<div class=\"alert alert-danger\">\r\n    <h5>Exception Stack Trace</h5>\r\n    <hr />\r\n    <p>");
            EndContext();
            BeginContext(550, 18, false);
#line 23 "G:\Programming\DotNet\ASP-DOTNET-CORE-2.2\Project-1\EmployeeManagement-ASP.Net-Core-MVC-Project\EmployeeManagement-ASP.Net-Core-MVC-Project\Views\Shared\Error.cshtml"
  Write(ViewBag.StackTrace);

#line default
#line hidden
            EndContext();
            BeginContext(568, 12, true);
            WriteLiteral("</p>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591