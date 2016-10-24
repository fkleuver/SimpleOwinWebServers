using System;
using System.Configuration;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.Hosting;
using Microsoft.Owin.StaticFiles;
using Owin;

namespace owin_staticfiles_console
{
    internal static class Program
    {
        private static void Main()
        {
            var port = int.Parse(ConfigurationManager.AppSettings["Port"]);

            WebApp.Start(new StartOptions {Port = port}, app =>
            {
                app.UseFileServer(new FileServerOptions
                {
                    EnableDirectoryBrowsing = true,
                    EnableDefaultFiles = false,
                    FileSystem = new PhysicalFileSystem("wwwroot")
                });
            });

            Console.WriteLine($"Test url: http://localhost:{port}");
            Console.WriteLine("Press [Enter] to exit");

            Console.ReadLine();
        }
    }
}
