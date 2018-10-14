namespace SoftUni.WebServer.Http.Interfaces
{
    using System.Collections.Generic;
    using Cookies;

    public interface IHttpCookieCollection : IEnumerable<HttpCookie>
    {
        void Add(HttpCookie cookie);

        void Add(string key, string value);

        bool ContainsKey(string key);

        HttpCookie Get(string key);
    }
}
