namespace SIS.HTTP.Sessions
{
	using System.Collections.Concurrent;
	using Contracts;
	using HTTP.Common;

	public class HttpSessionStorage
	{
		private static readonly ConcurrentDictionary<string, IHttpSession> sessions = new ConcurrentDictionary<string, IHttpSession>();

		public static IHttpSession GetSession(string id)
		{
			Validator.ThrowIfNullOrEmpty(id,nameof(id));
			return sessions.GetOrAdd(id, _ => new HttpSession(id));
		}
	}
}
