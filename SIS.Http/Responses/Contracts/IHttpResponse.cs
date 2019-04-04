using System.Net;
using SIS.Http.Contracts;
using SIS.Http.Headers;

namespace SIS.Http.Responses.Contracts
{
    public interface IHttpResponse
    {
        HttpStatusCode StatusCode { get; }

        IHttpHeaderCollection Headers { get; }

        byte[] Content { get; set; }

        void AddHeader(HttpHeader header);

        byte[] GetBytes();

    }
}
