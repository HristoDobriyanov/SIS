using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using CakesWebApp.Models;
using SIS.HTTP.Exceptions;
using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using SIS.WebServer.Results;

namespace CakesWebApp.Controllers
{
    public class CakesController : BaseController
    {
        public IHttpResponse AddCakes(IHttpRequest request)
        {
            return this.View("AddCakes");
        }

        public IHttpResponse DoAddCakes(IHttpRequest request)
        {
            var name = request.FormData["name"].ToString().Trim();
            var price = decimal.Parse(request.FormData["price"].ToString().Trim());
            var picture = request.FormData["name"].ToString().Trim();


            //TODO: Validation


            var product = new Product
            {
                Name = name,
                Price = price,
                ImageUrl = picture
            };

            this.Db.Products.Add(product);

            try
            {
                this.Db.SaveChanges();
            }
            catch (Exception e)
            {
                return this.ServerError(e.Message);
            }

            //Redirect
            return new RedirectResult("/");

        }

    }
}
