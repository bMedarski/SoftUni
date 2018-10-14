namespace FrameWork.Attributes.Methods
{
    public class HttpPostAttribute:HttpMethodAttribute
    {
	    public override bool isValid(string requestMethod)
	    {
		    if (requestMethod.ToUpper() == "POST")
		    {
			    return true;
		    }
		    return false;
	    }
    }
}
