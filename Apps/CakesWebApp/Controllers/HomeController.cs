﻿using SIS.HTTP.Enums;
using SIS.HTTP.Responses;

namespace CakesWebApp.Controllers
{
    public class HomeController : BaseController
    {
        public IHttpResponse Index()
        {
            return this.View("Index");
        }

        public IHttpResponse HelloUser()
        {
            return new HtmlResult($"<h1>Hello, {this.GetUsername()}</h1>", HttpResponseStatusCode.Ok);
        }
    }
}
