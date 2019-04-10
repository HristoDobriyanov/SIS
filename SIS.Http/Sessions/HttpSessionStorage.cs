using System.Collections.Concurrent;

namespace SIS.Http.Sessions
{
    public class HttpSessionStorage
    {
        public const string SessionCookieKey = "SIS_ID";

        private static readonly ConcurrentDictionary<string, IHttpSession> sessions =
            new ConcurrentDictionary<string, IHttpSession>();

        public static IHttpSession GetSession(string Id)
        {
            return sessions.GetOrAdd(Id, _ => new HttpSession(Id));
        } 
    }
}
