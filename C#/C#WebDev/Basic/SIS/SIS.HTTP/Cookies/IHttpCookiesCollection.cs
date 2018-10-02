namespace SIS.HTTP.Cookies
{
    public interface IHttpCookiesCollection
    {
	    void Add(HttpCookie cookie);

	    HttpCookie GetCookie(string key);

	    bool ContainsCookie(string key);

	    bool HasCookie();
    }
}
