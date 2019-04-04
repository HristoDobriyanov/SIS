using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using SIS.Http.Common;
using SIS.Http.Contracts;
using SIS.Http.Enum;
using SIS.Http.Exceptions;
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

        public string Path { get; private set; }

        public string Url { get; private set; }

        public Dictionary<string, object> FormData { get; }

        public Dictionary<string, object> QueryData { get; }

        public IHttpHeaderCollection Headers { get; }

        public HttpRequestMethod RequestMethod { get; private set; }


        private void ParseRequest(string requestString)
        {
            string[] splitRequestContent = requestString
                .Split(Environment.NewLine, StringSplitOptions.None);

            string[] requestLine = splitRequestContent[0].Trim()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);


            if (!this.ValidateRequestLine(requestLine))
            {
                throw new BadRequestException();
            }


            this.ParseRequestMethod(requestLine);
            this.ParseRequestUrl(requestLine);
            this.ParseRequestPath(requestLine);

            this.ParseHeaders(splitRequestContent.Skip(1).ToArray());
            bool requestHasBody = splitRequestContent.Length > 1;
            this.ParseRequestParameters(splitRequestContent[splitRequestContent.Length - 1], requestHasBody);



        }

        private void ParseRequestParameters(string bodyParameters, bool requestHasBody)
        {
            this.ParseQueryParameters(this.Url);

            if (requestHasBody)
            {
                this.ParseFormDataParameters(bodyParameters);
            }
        }

        private void ParseFormDataParameters(string bodyParameters)
        {
            var formDataKeyValuePairs = bodyParameters.Split('&', StringSplitOptions.RemoveEmptyEntries);


            ExtractrRequestParameters(formDataKeyValuePairs, this.FormData);
        }

        private void ParseQueryParameters(string url)
        {
            var queryParameters = this.Url?
                .Split(new[] { '?', '#' })
                .Skip(1)
                .Take(1)
                .ToString();

            if (string.IsNullOrEmpty(queryParameters))
            {
                throw new BadRequestException();
            }

            var queryKeyValuePairs = queryParameters.Split('&', StringSplitOptions.RemoveEmptyEntries);

            ExtractrRequestParameters(queryKeyValuePairs, this.QueryData);
        }

        private void ParseHeaders(string[] requestHeaders)
        {
            if (!requestHeaders.Any())
            {
                throw new BadRequestException();
            }

            foreach (var requestHeader in requestHeaders)
            {
                if (string.IsNullOrEmpty(requestHeader))
                {
                    return;
                }

                var splitRequestHeader = requestHeader.Split(": ", StringSplitOptions.RemoveEmptyEntries);
                var requestHeaderKey = splitRequestHeader[0];
                var requestHeaderValue = splitRequestHeader[1];

                this.Headers.Add(new HttpHeader(requestHeaderKey, requestHeaderValue));
            }
        }

        private void ParseRequestPath(string[] requestLine)
        {
            var path = this.Url?.Split('?').FirstOrDefault();
            if (string.IsNullOrEmpty(path))
            {
                throw new BadRequestException();
            }

            this.Path = path;
        }

        private void ParseRequestUrl(string[] requestLine)
        {
            if (string.IsNullOrEmpty(requestLine[1]))
            {
                throw new BadRequestException();
            }

            this.Url = requestLine[1];

        }

        private void ParseRequestMethod(string[] requestLine)
        {

            var parseResult = System.Enum.TryParse<HttpRequestMethod>
                (requestLine[0], out var parsedRequestMethod);

            if (!parseResult)
            {
                throw new BadRequestException();
            }

            this.RequestMethod = parsedRequestMethod;

        }

        private bool ValidateRequestLine(string[] requestLine)
        {
            if (!requestLine.Any())
            {
                throw new BadRequestException();
            }


            if (requestLine.Length == 3 && requestLine[2] == GlobalConstants.HttpOneProtocolFragment)
            {
                return true;
            }

            return false;
        }

        private void ExtractrRequestParameters(string[] parameterKeyValuePairs,
            Dictionary<string, object> parametersCollection)
        {
            foreach (var parametersKeyValuePair in parameterKeyValuePairs)
            {
                var keyValuePair = parametersKeyValuePair.Split("=", StringSplitOptions.RemoveEmptyEntries);

                if (keyValuePair.Length != 2)
                {
                    throw new BadRequestException();
                }

                var parameterKey = keyValuePair[0];
                var parapmeterValue = keyValuePair[1];

                parametersCollection[parameterKey] = parapmeterValue;
            }
        }
    }
}
