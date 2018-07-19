namespace SoftUni.WebServer.Mvc.Exceptions
{
    using System;

    public class UnauthorizedException : Exception
    {
        private const string DefaultMessage = "You are not authorized to perform this operation.";

        public UnauthorizedException()
            : base(DefaultMessage)
        {
        }

        public UnauthorizedException(string message)
            : base(message)
        {
        }
    }
}
