using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.Http.Cookies.Contracts
{
    public interface IHttpCookieCollection
    {
        void Add(HttpCookie httpCookie);

        HttpCookie GetCookie(string key);

        bool ContainsCookie(string key);

        bool HasCookie();
    }
}
