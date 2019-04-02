using System;
using System.Collections.Generic;
using System.Text;
using SIS.Http.Contracts;
using SIS.Http.Enum;
using SIS.Http.Headers;

namespace SIS.Http.Requests
{
    public class HttpRequest : IHttpRequest
    {

        public HttpRequest(string requestString)
        {
            this.FormData = new Dictionary<string, object>();

            this.QueryData = new Dictionary<string, object>();

            this.Headers = new HttpHeadersCollection();

            this.ParseRequest(requestString);

        }

        private void ParseRequest(string requestString)
        {
            throw new NotImplementedException();
        }






        public string Path { get; private set; }

        public string Url { get; private set; }

        public Dictionary<string, object> FormData { get; }

        public Dictionary<string, object> QueryData { get; }

        public IHttpHeaderCollection Headers { get; }

        public HttpRequestMethod RequestMethod { get; private set; }
    }
}
