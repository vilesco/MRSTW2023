using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;

namespace AutoCar.Web.App_Start
{
    public static class BundleConfig
    {
        // GET: BundleConfig
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/owlcarousel/css").Include(
                      "~/Content/css/owl.carousel.css", new CssRewriteUrlTransform()));
            bundles.Add(new StyleBundle("~/bundles/otherstyles/css").Include(
                      "~/Content/css/otherstyles.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/bootstrap/css").Include(
                      "~/Content/css/bootstrap.min.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/fontawesome/css").Include(
                      "~/Content/css/font-awesome.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/main/css").Include(
                      "~/Content/css/main.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/owlcarouseltheme/css").Include(
                      "~/Content/owl.theme.default.min.css", new CssRewriteUrlTransform()));

            bundles.Add(new ScriptBundle("~/bundles/jquery/js").Include(
                      "~/Content/js/jquery-2.1.4.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap/js").Include(
                      "~/Content/js/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/owlcarousel/js").Include(
                      "~/Content/js/owl.carousel.js"));

            bundles.Add(new ScriptBundle("~/bundles/main/js").Include(
                      "~/Content/js/script.js"));
        }
    }

}