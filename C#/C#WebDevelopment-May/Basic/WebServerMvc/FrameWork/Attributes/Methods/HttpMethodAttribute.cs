using System;

namespace FrameWork.Attributes.Methods
{
    public abstract class HttpMethodAttribute:Attribute
    {
	    public abstract bool isValid(string requestMethod);
    }
}
