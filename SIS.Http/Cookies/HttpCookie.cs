using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.Http.Cookies
{
    public class HttpCookie
    {
        private const int HttpCookieDefaultExpirationInDays = 3;

        public HttpCookie(string key, string value, int expiresInDays = HttpCookieDefaultExpirationInDays)
        {
            Key = key;
            Value = value;
            Expires = DateTime.Now.AddDays(expiresInDays);
            IsNew = true;
        }

        public HttpCookie(string key, string value, int expiresInDays, bool isNew)
            : this(key, value, expiresInDays)
        {
            IsNew = isNew;
        }


        public string Key { get; }

        public string Value { get; }

        public DateTime Expires { get; }

        public bool IsNew { get; }

        public override string ToString()
        {
            return $"{this.Key}={this.Value}";
        }
    }
}
