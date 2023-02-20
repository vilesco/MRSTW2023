using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;

namespace WebApplication1.App_Start
{
    public static class BundleConfig
    {
        // GET: BundleConfig
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/owlcarousel/css").Include(
                      "~/Content/css/owl.carousel.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/bootstrap/css").Include(
                      "~/Content/css/bootstrap.min.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/fontawesome/css").Include(
                      "~/Content/css/font-awesome.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/bundles/main/css").Include(
                      "~/Content/css/main.css", new CssRewriteUrlTransform()));

            bundles.Add(new ScriptBundle("~/bundles/jquery/js").Include(
                      "~/Scripts/jquery-3.6.3.min.js"));

            bundles.Add(new Bundle("~/bundles/bootstrap/js").Include(
                      "~/Content/js/bootstrap.js"));

            bundles.Add(new Bundle("~/bundles/owlcarousel/js").Include(
                      "~/Content/js/owl.carousel.js"));

            bundles.Add(new Bundle("~/bundles/main/js").Include(
                      "~/Content/js/script.js"));
        }
    }

}