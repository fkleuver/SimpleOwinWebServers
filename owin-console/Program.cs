using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace owin_console
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    internal static class Program
    {
        private static void Main()
        {
            var port = int.Parse(ConfigurationManager.AppSettings["Port"]);

            WebApp.Start(new StartOptions {Port = port}, app =>
            {
                app.Use(new Func<AppFunc, AppFunc>(next => (async env =>
                {
                    var response = env["owin.ResponseBody"] as Stream;
                    using (var writer = new StreamWriter(response))
                    {
                        await writer.WriteAsync("<h1>Pong!</h1>");
                    }
                    await next.Invoke(env);
                })));
            });

            Console.WriteLine($"Test url: http://localhost:{port}");
            Console.WriteLine("Press [Enter] to exit");

            Console.ReadLine();
        }
    }
}
