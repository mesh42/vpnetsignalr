using System.Web.Routing;
using VpNet.SignalR.Examples.App_Start;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(RegisterHubs), "Start")]
namespace VpNet.SignalR.Examples.App_Start
{
    public static class RegisterHubs
    {
        public static void Start()
        {
            // Register the default hubs route: ~/signalr
            RouteTable.Routes.MapHubs();

        }
    }
}
