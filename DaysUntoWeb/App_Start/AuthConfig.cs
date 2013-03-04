using System.Web.Configuration;
using Microsoft.Web.WebPages.OAuth;

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
                consumerKey: "2SB9Hbagjcuw1Uz8t0LVg",
                consumerSecret: "vTxhylaCDKuU9Xmm68YW4F7ls7MR6gCQKmIjamM");

            OAuthWebSecurity.RegisterFacebookClient(
                appId: WebConfigurationManager.AppSettings["FacebookAppId"],
                appSecret: WebConfigurationManager.AppSettings["FacebookAppSecret"]);

            OAuthWebSecurity.RegisterGoogleClient();
        }
    }
}
