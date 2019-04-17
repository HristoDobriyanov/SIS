using System;
using System.Collections.Generic;
using System.Text;
using SIS.HTTP.Requests;
using SIS.HTTP.Responses;

namespace CakesWebApp.Controllers
{
    public class CakesController : BaseController
    {
        public IHttpResponse AddCakes(IHttpRequest request)
        {
            return this.View("AddCakes");
        }
    }
}
