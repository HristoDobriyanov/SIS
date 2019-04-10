using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SIS.Http.Cookies.Contracts;

namespace SIS.Http.Cookies
{
    public class HttpCookieCollection : IHttpCookieCollection
    {
        private readonly IDictionary<string, HttpCookie> cookies;

        public HttpCookieCollection()
        {
            this.cookies = new Dictionary<string, HttpCookie>();
        }


        public void Add(HttpCookie httpCookie)
        {
            if (httpCookie == null)
            {
                throw new ArgumentException();
            }

            // TODO: overwrite cookies
            //if (this.ContainsCookie(httpCookie.Key))
            //{
            //    throw new Exception();
            //}

            this.cookies[httpCookie.Key] =  httpCookie;
        }

        public HttpCookie GetCookie(string key)
        {
            if (!this.ContainsCookie(key))
            {
                return null;
            }

            return this.cookies[key];
        }

        public bool ContainsCookie(string key)
        {
            return this.cookies.ContainsKey(key);
        }

        public bool HasCookie()
        {
            return this.cookies.Any();
        }

        public override string ToString()
        {
            return string.Join("; ", this.cookies.Values);
        }
    }
}
