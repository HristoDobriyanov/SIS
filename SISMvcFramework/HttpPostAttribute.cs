using System;

namespace SIS.MvcFramework
{
    public class HttpPostAttribute : Attribute
    {
        public string Path { get; }

        public HttpPostAttribute(string path)
        {
            Path = path;
        }
    }
}
