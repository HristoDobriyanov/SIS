using System.Net;
using SIS.Http.Responses.Contracts;
using SIS.WebServer.Results;

namespace CakesWebApp
{
    public class HomeController
    {
        public IHttpResponse Index()
        {
            string content = "<h1>Hello World!</h1>";

            return new HtmlResult(content, HttpStatusCode.OK);
        }
    }
}
