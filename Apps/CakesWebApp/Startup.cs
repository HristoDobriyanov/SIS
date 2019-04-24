﻿using CakesWebApp.Controllers;
using SIS.HTTP.Enums;
using SIS.MvcFramework;
using SIS.MvcFramework.Services;
using SIS.WebServer.Routing;

namespace CakesWebApp
{
    public class Startup : IMvcApplication
    {
        public void Configure()
        {
        }

        public void ConfigureServices(IServiceCollection collection)
        {
            collection.AddService<IHashService, HashService>();
            collection.AddService<IUserCookieService, UserCookieService>();

        }
    }
}