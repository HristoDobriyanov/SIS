using System.Net;
using SIS.Http.Responses.Contracts;
using SIS.WebServer.Results;

namespace CakesWebApp.Controllers

{
    public class HomeController : BaseController
    {
        public IHttpResponse Index(IhttpRequest request)
        {
            return this.View("Index");
        }
    }
}
