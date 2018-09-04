namespace FrameWork.Attributes.Methods
{
    public class HttpGetAttribute:HttpMethodAttribute
    {
	    public override bool isValid(string requestMethod)
	    {
		    if (requestMethod.ToUpper() == "GET")
		    {
			    return true;
		    }
		    return false;
	    }
    }
}
