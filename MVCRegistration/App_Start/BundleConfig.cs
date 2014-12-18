using System.Web;
using System.Web.Optimization;

namespace MVCRegistration
{
  public class BundleConfig
  {
    // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
    public static void RegisterBundles(BundleCollection bundles)
    {
      bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                  "~/Scripts/jquery-{version}.js"));

      bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                  "~/Scripts/jquery-ui-{version}.js"));

      bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                  "~/Scripts/jquery.unobtrusive*",
                  "~/Scripts/jquery.validate*"));

      // Use the development version of Modernizr to develop with and learn from. Then, when you're
      // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
      bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                  "~/Scripts/modernizr-*"));

      /*
      <script src="js/modernizr.custom.js"></script>
      <script src="js/modernizr.custom.sum.js"></script>
      <script src="js/masonry.pkgd.min.js"></script>
      <script src="js/imagesloaded.pkgd.min.js"></script>
      <script src="js/classie.js"></script>
      <script src="js/colorfinder-1.1.js"></script>
      <script src="js/gridScrollFx.js"></script>
      <script src="js/dynamicTabs.js"></script>
      */
      bundles.Add(new ScriptBundle("~/Store/js").Include(
                  "~/js/modernizr.custom.js",
                  "~/js/modernizr.custom.sum.js",
                  "~/js/masonry.pkgd.js",
                  "~/js/imagesloaded.pkgd.js",
                  "~/js/classie.js",
                  "~/js/colorfinder-1.1.js",
                  "~/js/gridScrollFx.js",
                  "~/js/dynamicTabs.js"
                  ));

      bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

      bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                  "~/Content/themes/base/jquery.ui.core.css",
                  "~/Content/themes/base/jquery.ui.resizable.css",
                  "~/Content/themes/base/jquery.ui.selectable.css",
                  "~/Content/themes/base/jquery.ui.accordion.css",
                  "~/Content/themes/base/jquery.ui.autocomplete.css",
                  "~/Content/themes/base/jquery.ui.button.css",
                  "~/Content/themes/base/jquery.ui.dialog.css",
                  "~/Content/themes/base/jquery.ui.slider.css",
                  "~/Content/themes/base/jquery.ui.tabs.css",
                  "~/Content/themes/base/jquery.ui.datepicker.css",
                  "~/Content/themes/base/jquery.ui.progressbar.css",
                  "~/Content/themes/base/jquery.ui.theme.css"));

      /*
      <link rel="stylesheet" type="text/css" href="css/normalize.css" />
      <link rel="stylesheet" type="text/css" href="css/demo2.css" />
      <link rel="stylesheet" type="text/css" href="css/tabs.css" />
      <link rel="stylesheet" type="text/css" href="css/tabstyles.css" />
      <link rel="stylesheet" type="text/css" href="css/component.css" />
      */
      bundles.Add(new StyleBundle("~/Store/css").Include(
                  "~/css/normalize.css",
                  "~/css/demo2.css",
                  "~/css/tabs.css",
                  "~/css/tabstyles.css",
                  "~/css/component.css"
                  ));
    }
  }
}