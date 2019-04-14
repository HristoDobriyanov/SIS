using System;
using CakesWebApp.Controllers;
using SIS.Http.Enum;
using SIS.WebServer;
using SIS.WebServer.Routing;

namespace CakesWebApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerRoutingTable serverRoutingTable = new ServerRoutingTable();

            serverRoutingTable.Routes[HttpRequestMethod.GET]["/"] = request => new HomeController().Index(request);

            Server server = new Server(80, serverRoutingTable);

            server.Run();
        }
    }
}
