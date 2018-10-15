namespace SIS.HTTP.Sessions
{
	using System.Collections.Generic;
	using Common;
	using Contracts;

	public class HttpSession : IHttpSession
	{
		private readonly IDictionary<string, object> sessionParameters;

		public HttpSession(string id)
		{
			this.Id = id;
			this.sessionParameters = new Dictionary<string, object>();
		}

		public string Id { get; private set; }

		public void AddParameter(string name, object parameter)
		{
			Validator.ThrowIfNullOrEmpty(name,nameof(name));
			Validator.ThrowIfNull(parameter,name);
			this.sessionParameters.Add(name,parameter);
		}

		public void ClearParameters()
		{
			this.sessionParameters.Clear();
		}

		public bool ContainsParameter(string name)
		{
			Validator.ThrowIfNullOrEmpty(name,nameof(name));
			return this.sessionParameters.ContainsKey(name);
		}

		public object GetParameter(string name)
		{
			Validator.ThrowIfNullOrEmpty(name,nameof(name));
			return this.sessionParameters[name];
		}
	}
}
