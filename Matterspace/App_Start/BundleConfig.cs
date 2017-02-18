using System.Web.Optimization;

namespace Matterspace
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                        "~/Scripts/no-np/react-bundle.js",
                        "~/Scripts/app.js"));

            bundles.Add(new ScriptBundle("~/bundles/vue").Include(
                        "~/Scripts/no-np/vue.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/no-np/tether.min.js",
                      "~/Scripts/no-np/bootstrap.min.js",
                      "~/Scripts/respond.js"));

            // This is the bundle that should be added for the non-authenticated part of Matterspace
            bundles.Add(new StyleBundle("~/Content/css-site").Include(
                      "~/Content/bootstrap.site.css",
                      "~/Content/font-awesome.css",
                      "~/Content/site.css",
                      "~/Content/signin-signup.css",
                      "~/Content/home.css"
                      ));

            // This is the bundle that should be added for the authenticated part of Matterspace
            bundles.Add(new StyleBundle("~/Content/css-app").Include(
                      "~/Content/bootstrap.app.css",
                      "~/Content/font-awesome.css",
                      "~/Content/react-bundle.css",
                      "~/Content/site.css",
                      "~/Content/App.css"
                      ));
        }
    }
}
