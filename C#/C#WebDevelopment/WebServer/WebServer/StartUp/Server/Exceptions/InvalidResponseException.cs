namespace StartUp.Server.Exceptions
{
	using System;

    public class InvalidResponseException: Exception
    {
	    public InvalidResponseException(string msg)
		    : base(msg)
	    {
		    
	    }
	}
}
