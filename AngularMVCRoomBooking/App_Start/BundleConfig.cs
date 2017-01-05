﻿using System.Web;
using System.Web.Optimization;

namespace AngularMVCRoomBooking
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

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      //"~/Content/bootstrap.css",
                      "~/Content/site.css"));

            //bundles.Add(new StyleBundle("~/bundles/hotelBooking/style").Include(
            //    "~/Content/bootstrap.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/hotelBooking/script").Include(
                "~/scripts/angular.min.js",
                "~/scripts/angular-route.min.js",
                "~/scripts/angular-ui/ui-bootstrap-tpls.min.js",
                "~/app/AngularFormsApp.js",
                "~/app/DataService.js",
                "~/app/RoomBookingForm/RoomBookingController.js",
                "~/app/RoomBookingForm/RoomBookingDirective.js",
                "~/app/HomeForm/HomeController.js",
                "~/app/DashboardForm/DashboardController.js"
                ));

            BundleTable.EnableOptimizations = false;
        }
    }
}
