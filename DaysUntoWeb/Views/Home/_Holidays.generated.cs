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

namespace HowManyDaysTil.Web.Views.Home
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
    
    #line 1 "..\..\Views\Home\_Holidays.cshtml"
    using HowManyDaysTil.Web.Helpers;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "1.5.4.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Home/_Holidays.cshtml")]
    public partial class Holidays : System.Web.Mvc.WebViewPage<HowManyDaysTil.Web.Models.HomeViewModel>
    {
        public Holidays()
        {
        }
        public override void Execute()
        {
WriteLiteral("<div");

WriteLiteral(" class=\"span6\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" id=\"upcoming-events\"");

WriteLiteral(" class=\"breadcrumb\"");

WriteLiteral(">\r\n        <h1>Upcoming ");

            
            #line 6 "..\..\Views\Home\_Holidays.cshtml"
                Write(DateTime.Now.Year);

            
            #line default
            #line hidden
WriteLiteral(" US events </h1>\r\n        <br />\r\n");

            
            #line 8 "..\..\Views\Home\_Holidays.cshtml"
        
            
            #line default
            #line hidden
            
            #line 8 "..\..\Views\Home\_Holidays.cshtml"
         foreach (var holiday in Model.Holidays)
        {

            
            #line default
            #line hidden
WriteLiteral("            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"span6\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"span5\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"calendar\"");

WriteLiteral(">\r\n                            <span");

WriteLiteral(" class=\"month\"");

WriteLiteral(">");

            
            #line 14 "..\..\Views\Home\_Holidays.cshtml"
                                           Write(Html.GetMonthName(holiday.HolidayDate));

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                            <span");

WriteLiteral(" class=\"day\"");

WriteLiteral(">");

            
            #line 15 "..\..\Views\Home\_Holidays.cshtml"
                                         Write(holiday.HolidayDate.Day);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                        </div>\r\n                        <h3>");

            
            #line 17 "..\..\Views\Home\_Holidays.cshtml"
                       Write(holiday.HolidayName);

            
            #line default
            #line hidden
WriteLiteral("</h3>\r\n                        <span");

WriteLiteral(" class=\"label label-info\"");

WriteLiteral(">");

            
            #line 18 "..\..\Views\Home\_Holidays.cshtml"
                                                  Write(Html.DisplayDaysLeft(holiday.HolidayDate));

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n" +
"");

WriteLiteral("            <hr />\r\n");

            
            #line 23 "..\..\Views\Home\_Holidays.cshtml"
        }

            
            #line default
            #line hidden
WriteLiteral("        <a");

WriteLiteral(" class=\"hidden-desktop pull-right\"");

WriteLiteral(" onclick=\"$(\'html,body\').animate({scrollTop: $(\'#infoyou\').offset().top}, 1500);\"" +
"");

WriteLiteral("><i");

WriteLiteral(" class=\"icon-circle-arrow-up\"");

WriteLiteral(" style=\"cursor: pointer; text-decoration: none;\"");

WriteLiteral("></i></a>\r\n        <div");

WriteLiteral(" class=\"clearfix\"");

WriteLiteral("></div>\r\n    </div>\r\n</div>\r\n");

        }
    }
}
#pragma warning restore 1591
