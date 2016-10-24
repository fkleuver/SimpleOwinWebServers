using System.Web.Http;

namespace owin_webapi_console
{
    public class PingController : ApiController
    {
        public string Get()
        {
            return "Pong";
        }
    }
}