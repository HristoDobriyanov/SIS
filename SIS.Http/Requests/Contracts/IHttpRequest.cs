using SIS.Http.Contracts;
using SIS.Http.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.Http.Requests
{
    public interface IHttpRequest
    {
        string Path { get; }

        string Url { get; }

        Dictionary<string, object> FormData { get; }

        Dictionary<string, object> QueryData { get; }

        IHttpHeaderCollection Headers { get; }

        HttpRequestMethod RequestMethod { get; }
    }
}
