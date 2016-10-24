using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Owin;

namespace owin_staticfiles_iis
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseFileServer(new FileServerOptions
            {
                EnableDirectoryBrowsing = true,
                EnableDefaultFiles = false,
                FileSystem = new PhysicalFileSystem("wwwroot")
            });
        }
    }
}