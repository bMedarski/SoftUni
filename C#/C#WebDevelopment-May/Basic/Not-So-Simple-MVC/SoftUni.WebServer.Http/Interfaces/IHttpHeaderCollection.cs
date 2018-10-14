namespace SoftUni.WebServer.Http.Interfaces
{
    using System.Collections.Generic;
    using SoftUni.WebServer.Http.Headers;

    public interface IHttpHeaderCollection : IEnumerable<HttpHeader>
    {
        void Add(HttpHeader header);

        bool ContainsKey(string key);

        HttpHeader Get(string key);
    }
}
