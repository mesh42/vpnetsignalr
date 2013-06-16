using VpNet.SignalR.Examples.App_Start;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(AppStart), "ConfigureBundles")]

namespace VpNet.SignalR.Examples.App_Start
{
    public static class AppStart
    {
        public static void ConfigureBundles()
        {
            // BundleTable.Bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //     "~/Scripts/jquery-{version}.js"));

            // BundleTable.Bundles.Add(new ScriptBundle("~/bundles/jquerycolor").Include(
            //     "~/Scripts/jquery.color-{version}.js"));
        }
    }
}