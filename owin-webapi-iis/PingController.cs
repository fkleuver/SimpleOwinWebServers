using System.Web.Http;

namespace owin_webapi_iis
{
    public class PingController : ApiController
    {
        public string Get()
        {
            return "Pong";
        }
    }
}