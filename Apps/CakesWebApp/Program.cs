using SIS.MvcFramework;

namespace CakesWebApp
{
    class Program
    {
        static void Main(string[] args)
        {
            WebHost.Start(new Startup());
        }
    }
}
