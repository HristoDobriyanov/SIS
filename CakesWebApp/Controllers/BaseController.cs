using SIS.Http.Responses.Contracts;
using SIS.WebServer.Results;
using System.IO;
using System.Net;
using CakesWebApp.Data;
using SIS.Http.Responses;

namespace CakesWebApp.Controllers
{
    public abstract class BaseController
    {
        protected BaseController()
        {
            this.Db = new CakesDbContext();
        }


        protected CakesDbContext Db { get;  }

        protected IHttpResponse View(string viewName)
        {
            var content = File.ReadAllText("Views/" + viewName + ".html");

            return new HtmlResult(content, HttpStatusCode.OK);
        }

        protected IHttpResponse BadRequestError(string errorMassage)
        {
            return new HtmlResult($"<h1>{errorMassage}</h1>", HttpStatusCode.BadRequest);
        }

        protected IHttpResponse ServerError(string errorMassage)
        {
            return new HtmlResult($"<h1>{errorMassage}</h1>", HttpStatusCode.InternalServerError);
        }
    }
}
