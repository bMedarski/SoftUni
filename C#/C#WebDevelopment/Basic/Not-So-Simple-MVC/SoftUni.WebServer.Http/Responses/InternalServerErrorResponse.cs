namespace SoftUni.WebServer.Http.Responses
{
    using System;
    using Enums;

    public class InternalServerErrorResponse : ContentResponse
    {
        public InternalServerErrorResponse(Exception exception)
            : base(HttpStatusCode.InternalServerError, exception.Message)
        {
        }
    }
}
