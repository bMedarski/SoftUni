namespace SIS.HTTP.Requests.Common
{
	public static class RequestConstants
	{
		public const string InvalidRequestLineMessage = "Not a valid request line";
		public const string InvalidRequestMethodMessage = "Invalid request method";
		public const string HostHeaderKey = "Host";
		public const string MissingHostHeaderMessage = "Missing 'Host' header";
		public const string InvalidNumberOfParametersInRequestHeaderKeyValuePair =
			"Invalid number of parameters in request header Key/Value pair";
		public const string InvalidNumberOfPartsOfKeyValuePair = "Key/Value pair must be from two parts";
		public const int RequestLinePartsCount = 3;
		public const int NumberOfParametersInRequestHeaderKeyValuePair = 2;
		public const int NumberOfPartsOfKeyValuePair = 2;
		public const char QueryDelimiter = '?';
		public const char FragmentDelimiter = '#';
		public const string HeaderDelimeter = ": ";
		public const char ParameterDelimiter = '&';
		public const char KeyValuePairsDelimiter = '=';
	}
}
