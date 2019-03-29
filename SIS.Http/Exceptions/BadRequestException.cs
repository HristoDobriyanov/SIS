using System;
using System.Net;

namespace SIS.Http.Exceptions
{
    public class BadRequestException : Exception
    {
        private const string ErrorMessage = "The Request was malformed or contains unsupported elements.";

        public const HttpStatusCode StatusCode = HttpStatusCode.BadRequest;

        public BadRequestException():
            base(ErrorMessage)
        {

        }
    }
}
