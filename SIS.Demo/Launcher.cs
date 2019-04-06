using System;
using SIS.Http.Enum;
using SIS.WebServer;
using SIS.WebServer.Routing;

namespace SIS.Demo
{
    public class Launcher
    {
        static void Main(string[] Args)
        {
            ServerRoutingTable serverRoutingTable = new ServerRoutingTable();

            serverRoutingTable.Routes[HttpRequestMethod.GET]["/"] = request => new HomeController().Index();

            Server server = new Server(8000, serverRoutingTable);

            server.Run();
        }
    }
}
