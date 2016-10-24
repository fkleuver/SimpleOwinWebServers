using System;
using System.Configuration;
using System.Web.Http;
using Microsoft.Owin.Hosting;
using Owin;

namespace owin_webapi_console
{
    internal static class Program
    {
        private static void Main()
        {
            var port = int.Parse(ConfigurationManager.AppSettings["Port"]);

            WebApp.Start(new StartOptions {Port = port}, app =>
            {
                var config = new HttpConfiguration();
                config.Routes.MapHttpRoute("Default", "api/{controller}");
                config.Formatters.Remove(config.Formatters.XmlFormatter);

                app.UseWebApi(config);
            });

            Console.WriteLine($"Test url: http://localhost:{port}/api/ping");
            Console.WriteLine("Press [Enter] to exit");

            Console.ReadLine();
        }
    }
}
