#pragma checksum "G:\Programming\DotNet\ASP-DOTNET-CORE-2.2\Project-1\EmployeeManagement-ASP.Net-Core-MVC-Project\EmployeeManagement-ASP.Net-Core-MVC-Project\Views\Shared\NotFound.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2601e21bda51a3629cc9c2fd5b20e22d24e49c8e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_NotFound), @"mvc.1.0.view", @"/Views/Shared/NotFound.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/NotFound.cshtml", typeof(AspNetCore.Views_Shared_NotFound))]
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
#line 13 "G:\Programming\DotNet\ASP-DOTNET-CORE-2.2\Project-1\EmployeeManagement-ASP.Net-Core-MVC-Project\EmployeeManagement-ASP.Net-Core-MVC-Project\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2601e21bda51a3629cc9c2fd5b20e22d24e49c8e", @"/Views/Shared/NotFound.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"11ce8aa50d16a9ec476416a6f8ff9d8d77aa5e6d", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_NotFound : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "G:\Programming\DotNet\ASP-DOTNET-CORE-2.2\Project-1\EmployeeManagement-ASP.Net-Core-MVC-Project\EmployeeManagement-ASP.Net-Core-MVC-Project\Views\Shared\NotFound.cshtml"
  
    ViewBag.Title = "Not Found";

#line default
#line hidden
            BeginContext(41, 6, true);
            WriteLiteral("\r\n<h1>");
            EndContext();
            BeginContext(48, 20, false);
#line 5 "G:\Programming\DotNet\ASP-DOTNET-CORE-2.2\Project-1\EmployeeManagement-ASP.Net-Core-MVC-Project\EmployeeManagement-ASP.Net-Core-MVC-Project\Views\Shared\NotFound.cshtml"
Write(ViewBag.ErrorMessage);

#line default
#line hidden
            EndContext();
            BeginContext(68, 9, true);
            WriteLiteral("</h1>\r\n\r\n");
            EndContext();
            BeginContext(77, 95, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2601e21bda51a3629cc9c2fd5b20e22d24e49c8e5062", async() => {
                BeginContext(121, 47, true);
                WriteLiteral("\r\n    Click here to navigate to the home page\r\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
