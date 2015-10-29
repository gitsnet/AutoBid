using System.Web;
using System.Web.Optimization;

namespace AutoBid
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/Content/main/js").Include(
                "~/Content/js/jquery-1.10.2.js",
                "~/Content/js/bootstrap.min.js",
                "~/Content/js/bootstrap.file-input.js",
                "~/Content/js/bootstrap-datepicker.js",
                "~/Content/js/autobid_custom.js"
                ));

            bundles.Add(new ScriptBundle("~/Content/other").Include(
               "~/Content/js/jquery.easyui.min.js",
               "~/Content/js/jquery.form.js",
               "~/Content/js/jquery.inputmask.js",
               "~/Content/js/jquery.inputmask.date.extensions.js",               
               "~/Content/js/jquery.inputmask.numeric.extensions.js",
               "~/Content/js/jquery.maskMoney.js"
               ));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/main/css").Include(
                "~/Content/css/bootstrap.css",
                "~/Content/css/autobid.css",
                "~/Content/css/datepicker.css",
                  "~/Content/font-awesome/font-awesome.css"
            ));
            bundles.Add(new StyleBundle("~/Content/main/fontawsome").Include(
               "~/Content/font-awesome/font-awesome.css"
           ));
        }
    }
}
