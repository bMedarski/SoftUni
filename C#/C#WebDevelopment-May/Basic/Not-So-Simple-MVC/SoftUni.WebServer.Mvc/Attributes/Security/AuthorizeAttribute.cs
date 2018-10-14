namespace SoftUni.WebServer.Mvc.Attributes.Security
{
    using System;
    using SoftUni.WebServer.Http.Interfaces;
    using SoftUni.WebServer.Http.Responses;

    [AttributeUsage(AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute
    {
        private const string LoginPath = "/users/login";

        public virtual IHttpResponse GetResponse(string message)
        {
            return new RedirectResponse(LoginPath);
        }
    }
}
