using System;
using System.Configuration;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;
using Owin;

namespace owin_signalr_console
{
    internal static class Program
    {
        private static void Main()
        {
            var port = int.Parse(ConfigurationManager.AppSettings["Port"]);

            WebApp.Start(new StartOptions {Port = port}, app =>
            {
                app.MapHubs("signalr", new HubConfiguration
                {
                    EnableCrossDomain = true,
                    EnableJavaScriptProxies = true
                });
            });

            Console.WriteLine($"JavaScript proxy url: http://localhost:{port}/signalr/hubs");
            Console.WriteLine($"Test url: http://localhost:{port}/signalr/hubs/ping");
            Console.WriteLine("Press [Enter] to exit");

            Console.ReadLine();
        }
    }
}
