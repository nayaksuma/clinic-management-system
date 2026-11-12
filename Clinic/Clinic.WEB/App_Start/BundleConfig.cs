using System.Web;
using System.Web.Optimization;

namespace Clinic.WEB
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                "~/Scripts/purecounter.js",
                "~/Scripts/bootstrap.bundle.min.js",
                 "~/Scripts/glightbox.min.js",
                 "~/Scripts/swiper-bundle.min.js",
                 "~/Scripts/bootstrap.bundle.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                   "~/fonts/fontawesome-free/css/all.min.css",
                   "~/fonts/boxicons/CSS/boxicons.min.css",
                   "~/fonts/boxicons/fonts/boxicons.svg",
                      "~/Content/animate.min.css",
                      "~/Content/bootstrap.min.css",
                      "~/fonts/bootstrap-icons/bootstrap-icons.css",
                      "~/fonts/boxicons.min.css",
                      "~/Content/glightbox.min.css",
                      "~/fonts/remixicon.css",
                      "~/Content/swiper-bundle.min.css",
                      "~/Content/style.css"));

            bundles.Add(new Bundle("~/bundles/bootstrapdate").Include(
                    "~/Scripts/datepicker-full.min.js",
                    "~/Scripts/datepickerCustom.js"));

            bundles.Add(new StyleBundle("~/Content/bootstrapdate").Include(
                      "~/Content/datepicker.min.css",
                      "~/Content/datepickerCustom.min.css"));

        }
    }
}
