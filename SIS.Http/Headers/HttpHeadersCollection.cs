using SIS.Http.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.Http.Headers
{
    public class HttpHeadersCollection : IHttpHeaderCollection
    {
        private readonly IDictionary<string, HttpHeader> headers;

        public HttpHeadersCollection()
        {
            this.headers = new Dictionary<string, HttpHeader>();
        }

        public void Add(HttpHeader header)
        {
            if (header.Key == null || 
                string.IsNullOrEmpty(header.Value) ||
                string.IsNullOrEmpty(header.Key) ||
                this.ContainsHeader(header.Key))
            {
                throw new Exception();
            }
                this.headers.Add(header.Key, header);
        }

        public bool ContainsHeader(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException($"{nameof(key)} cannot be null");
            }

            return this.headers.ContainsKey(key);

        }

        public HttpHeader GetHeader(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException($"{nameof(key)} cannot be null");
            }

            if (this.ContainsHeader(key))
            {
            return this.headers[key];
            }
            else
            {
                return null;
            }
            
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, this.headers.Values);
        }
    }
}
