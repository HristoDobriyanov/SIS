using SIS.Http.Contracts;
using SIS.Http.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using SIS.Http.Cookies.Contracts;
using SIS.Http.Sessions;

namespace SIS.Http.Requests
{
    public interface IHttpRequest
    {
        string Path { get; }

        string Url { get; }

        Dictionary<string, object> FormData { get; }

        Dictionary<string, object> QueryData { get; }

        IHttpHeaderCollection Headers { get; }

        IHttpCookieCollection Cookies { get; }

        HttpRequestMethod RequestMethod { get; }

        IHttpSession Session { get; set; }
    }
}
