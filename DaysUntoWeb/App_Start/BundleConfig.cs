using System.Web;
using System.Web.Optimization;

namespace DaysUntoWeb
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/scripts").Include(
                        "~/Scripts/jquery.js",
                        "~/Scripts/bootstrap-transition.js",
                        "~/Scripts/bootstrap-alert.js",
                        "~/Scripts/bootstrap-modal.js",
                        "~/Scripts//bootstrap-dropdown.js",
                        "~/Scripts/bootstrap-scrollspy.js",
                        "~/Scripts/bootstrap-tab.js",
                        "~/Scripts/bootstrap-tooltip.js",
                        "~/Scripts/bootstrap-popover.js",
                        "~/Scripts/bootstrap-button.js",
                        "~/Scripts/bootstrap-collapse.js",
                        "~/Scripts/bootstrap-carousel.js",
                        "~/Scripts/bootstrap-typeahead.js",
                        "~/Scripts/application.js",
                        "~/Scripts/jquery.lightbox-0.5.js",
                        "~/Scripts/bootstrap.file-input.js",
                        "~/Scripts/bootstrap-datepicker.js",
                        "~/Scripts/jquery.validate.js",
                        "~/Scripts/jquery.validate.unobtrusive.js",
                        "~/Scripts/jquery.validate.bootstrap.js",
                        "~/Scripts/jquery.cookie.js",
                        "~/Scripts/jQuery.flashMessage.js",
                        "~/Scripts/bootbox.js"));

         
            bundles.Add(new StyleBundle("~/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/font-awesome.css",
                "~/Content/bootstrap-responsive.css",
                "~/Content/jquery.lightbox-0.5.css",
                "~/Content/zocial.css",
                "~/Content/datepicker.css"));

           
        }
    }
}