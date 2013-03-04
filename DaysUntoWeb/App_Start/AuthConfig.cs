using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Configuration;
using Microsoft.Web.WebPages.OAuth;
using DaysUntoWeb.Models;

namespace DaysUntoWeb
{
    public static class AuthConfig
    {
        public static void RegisterAuth()
        {
            // To let users of this site log in using their accounts from other sites such as Microsoft, Facebook, and Twitter,
            // you must update this site. For more information visit http://go.microsoft.com/fwlink/?LinkID=252166

            //OAuthWebSecurity.RegisterMicrosoftClient(
            //    clientId: "",
            //    clientSecret: "");

            OAuthWebSecurity.RegisterTwitterClient(
                consumerKey: "AbSUbjiiZ3H7er0qN8t0w",
                consumerSecret: "4eqLlX4ItOPAaU4G1gAMSLDJlzUubMVXt7MKZ3kvoaY");

            OAuthWebSecurity.RegisterFacebookClient(
                appId: WebConfigurationManager.AppSettings["FacebookAppId"],
                appSecret: WebConfigurationManager.AppSettings["FacebookAppSecret"]);

            OAuthWebSecurity.RegisterGoogleClient();
        }
    }
}
