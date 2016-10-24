using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Owin;

namespace owin_iis
{
    using AppFunc = Func<IDictionary<string, object>, Task>;
    public class Startup
    {
        public void Configuration(IAppBuilder app)
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
        }
    }
}