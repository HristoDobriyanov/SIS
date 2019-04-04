using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using SIS.Http.Common;
using SIS.Http.Contracts;
using SIS.Http.Extensions;
using SIS.Http.Headers;
using SIS.Http.Responses.Contracts;

namespace SIS.Http.Responses
{
    public class HttpResponse : IHttpResponse
    {
        public HttpResponse()
        {
                
        }

        public HttpResponse(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
            Headers = new HttpHeadersCollection();
            Content = new byte[0];
        }

        public HttpStatusCode StatusCode { get; }

        public IHttpHeaderCollection Headers { get; set; }

        public byte[] Content { get; set; }



        public void AddHeader(HttpHeader header)
        {
            this.Headers.Add(header);
        }

        public byte[] GetBytes()
        {
            return Encoding.UTF8
                .GetBytes(this.ToString())
                .Concat(this.Content)
                .ToArray();
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result
                .AppendLine($"{GlobalConstants.HttpOneProtocolFragment} {this.StatusCode.GetResponseLine()}")
                .AppendLine($"{this.Headers}")
                .AppendLine();

            return result.ToString();
        }
    }
}