using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using CakesWebApp.Data;
using SIS.Http.Requests;
using SIS.Http.Responses.Contracts;
using SIS.WebServer.Results;
using System.Linq;
using CakesWebApp.Models;
using CakesWebApp.Services;


namespace CakesWebApp.Controllers
{
    class AccountController : BaseController
    {
        private IHashService hashService;


        public AccountController()
        {
           this.hashService = new HashService();   
        }


        public IHttpResponse Register(IHttpRequest request)
        {
            return this.View("Register");
        }

        public IHttpResponse DoRegister(IHttpRequest request)
        {
            var userName = request.FormData["username"].ToString().Trim();
            var password = request.FormData["password"].ToString();
            var confirmPassword = request.FormData["confirmPassword"].ToString();

            if (string.IsNullOrWhiteSpace(userName) || userName.Length < 4)
            {
                return this.BadRequestError("Please provide valid username, with 4 or more characters.");
            }

            if (this.Db.Users.Any(x => x.Username == userName))
            {
                return this.BadRequestError("That username is already taken!");
            }

            if (string.IsNullOrEmpty(password) || password.Length <= 6)
            {
                return this.BadRequestError("Password must contain at least 6 characters.");
            }

            if (password != confirmPassword)
            {
                return this.BadRequestError("Passwords do not match.");
            }

            var hashedPassword = hashService.Hash(password);

            var user = new User()
            {
                Name =  userName,
                Username = userName,
                Password = hashedPassword
            };

            this.Db.Users.Add(user);

            try
            {
                this.Db.SaveChanges();
            }
            catch (Exception e)
            {
                return this.ServerError(e.Message);
            }

            return new RedirectResult("/");
        }

        public IHttpResponse Login(IHttpRequest request)
        {
            return this.View("Login");
        }

        public IHttpResponse DoLogin(IHttpRequest request)
        {
            var userName = request.FormData["username"].ToString().Trim();
            var password = request.FormData["password"].ToString();
            var hashedPassword = this.hashService.Hash(password);

            var user = this.Db.Users.FirstOrDefault(x => x.Username == userName && x.Password == hashedPassword);

            if (user == null)
            {
                return this.BadRequestError("Username or password incorrect.");
            }

            return new RedirectResult("/");
        }
    }
}
