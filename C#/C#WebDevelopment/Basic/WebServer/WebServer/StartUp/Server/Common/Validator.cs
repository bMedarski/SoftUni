namespace StartUp.Server.Common
{
	using System;

	public static class Validator
    {
	    public static void ThrowIfNull(object obj,string name)
	    {
		    if (obj == null)
		    {
			    throw new ArgumentNullException(name);
		    }
	    }

	    public static void ThrowIfNullOrEmpty(string text, string name)
	    {
		    if (string.IsNullOrWhiteSpace(text))
		    {
			    throw new ArgumentNullException($"{name} cannot be null or empty.");
		    }
	    }
    }
}
