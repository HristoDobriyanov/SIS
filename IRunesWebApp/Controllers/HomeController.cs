using SIS.HTTP.Enums;
using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using SIS.WebServer.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRunesWebApp.Controllers
{
    class HomeController : BaseController
    {
        public IHttpResponse Index(IHttpRequest request) => this.View();

    }
}
