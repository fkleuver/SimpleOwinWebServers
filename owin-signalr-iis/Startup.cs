using Microsoft.AspNet.SignalR;
using Owin;

namespace owin_signalr_iis
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapHubs("signalr", new HubConfiguration
            {
                EnableCrossDomain = true,
                EnableJavaScriptProxies = true
            });
        }
    }
}