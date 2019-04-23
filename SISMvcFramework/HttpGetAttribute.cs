using System;
using System.IO;

namespace SIS.MvcFramework
{
    public class HttpGetAttribute : Attribute
    {
        public string Path { get; }

        public HttpGetAttribute(string path)
        {
              Path = path;
        }
    }
}
