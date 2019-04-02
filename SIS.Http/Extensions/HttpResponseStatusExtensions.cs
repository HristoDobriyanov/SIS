using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SIS.Http.Extensions
{
    public static class HttpResponseStatusExtensions
    {
        public static string GetResponseLine(this HttpStatusCode statusCode)
        => $"{(int)statusCode} {statusCode}";
    }
}
