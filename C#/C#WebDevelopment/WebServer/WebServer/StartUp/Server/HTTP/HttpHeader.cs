namespace StartUp.Server.HTTP
{
	using Common;

	public class HttpHeader
    {
	    public const string ContentType = "Content-Type";
	    public const string Host = "Host";
	    public const string Location = "Location";
	    public const string Cookie = "Cookie";
	    public const string SetCookie = "Set-Cookie";

		public HttpHeader(string key, string value)
	    {
			Validator.ThrowIfNullOrEmpty(key, nameof(key));
			Validator.ThrowIfNullOrEmpty(value,nameof(value));

		    this.Key = key;
		    this.Value = value;
	    }

	    public string Value { get; private set; }

	    public string Key { get; private set; }

		public override string ToString() => $"{this.Key}: {this.Value}";
	}
}