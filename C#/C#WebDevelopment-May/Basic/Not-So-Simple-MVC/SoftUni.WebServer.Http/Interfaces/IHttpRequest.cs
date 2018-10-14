namespace SoftUni.WebServer.Http.Interfaces
{
    using System.Collections.Generic;
    using Enums;

    public interface IHttpRequest
    {
        HttpRequestMethod Method { get; }

        string Url { get; }

        string Path { get; }

        IDictionary<string, string> UrlParameters { get; }

        IDictionary<string, string> QueryParameters { get; }

        IHttpHeaderCollection Headers { get; }

        IHttpCookieCollection Cookies { get; }

        IHttpSession Session { get; set; }

        IDictionary<string, string> FormData { get; }

        void AddUrlParameter(string key, string value);
    }
}
