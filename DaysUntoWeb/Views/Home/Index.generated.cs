﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18034
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DaysUntoWeb.Views.Home
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    
    #line 1 "..\..\Views\Home\Index.cshtml"
    using DaysUntoWeb.Helpers;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "1.5.4.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Home/Index.cshtml")]
    public partial class Index : System.Web.Mvc.WebViewPage<DaysUntoWeb.Models.HomeViewModel>
    {
        public Index()
        {
        }
        public override void Execute()
        {
WriteLiteral("<div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" id=\"column-1\"");

WriteLiteral(" class=\"span6\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" id=\"infoyou\"");

WriteLiteral(" class=\"span6\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"breadcrumb\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"well-small\"");

WriteLiteral(">\r\n                        <i");

WriteLiteral(" class=\"icon-calendar icon-4x pull-left icon-border\"");

WriteLiteral("></i>\r\n                        <h1>How Many Days Til</h1>\r\n                      " +
"  A countdown for your important events!\r\n                        <br />\r\n      " +
"                  <br />\r\n");

            
            #line 14 "..\..\Views\Home\Index.cshtml"
                        
            
            #line default
            #line hidden
            
            #line 14 "..\..\Views\Home\Index.cshtml"
                         if (Request.IsAuthenticated)
                        {
                            
            
            #line default
            #line hidden
            
            #line 16 "..\..\Views\Home\Index.cshtml"
                       Write(Html.Partial("_AddEvent"));

            
            #line default
            #line hidden
            
            #line 16 "..\..\Views\Home\Index.cshtml"
                                                      
                        }

            
            #line default
            #line hidden
WriteLiteral("                    </div>\r\n                    <div");

WriteLiteral(" class=\"clearfix\"");

WriteLiteral("></div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <div" +
"");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 24 "..\..\Views\Home\Index.cshtml"
       Write(Html.Partial("_Holidays", Model));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" id=\"column-2\"");

WriteLiteral(" class=\"span6\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 28 "..\..\Views\Home\Index.cshtml"
   Write(Html.Partial("_Events", Model));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n</div>\r\n");

        }
    }
}
#pragma warning restore 1591
