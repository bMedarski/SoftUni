using System.Collections.Generic;

namespace StartUp.Server.HTTP.Contracts
{
	public interface IHttpHeaderCollection : IEnumerable<ICollection<HttpHeader>>
    {
	    void Add(HttpHeader header);
	    void Add(string key, string value);
		bool ContainsKey(string key);
		ICollection<HttpHeader> Get(string key);
	}
}
