namespace SoftUni.WebServer.Mvc.Routers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using SoftUni.WebServer.Http.Enums;
    using SoftUni.WebServer.Http.Interfaces;
    using SoftUni.WebServer.Http.Responses;
    using SoftUni.WebServer.Server.Interfaces;

    public class ResourceRouter : IHttpRequestHandler
    {
        private const string ContentDirectory = "./Content/";
        private const string BasePath = "/";

        private static readonly Dictionary<string, string> ExtensionsToMIMETypes = new Dictionary<string, string>()
        {
            ["js"] = "application/javascript",
            ["css"] = "text/css",
            ["html"] = "text/html",
            ["htm"] = "text/html",
            ["jpg"] = "image/jpeg",
            ["jpeg"] = "image/jpeg",
            ["jpe"] = "image/jpeg",
            ["bmp"] = "image/bmp",
            ["gif"] = "image/gif",
            ["svg"] = "image/svg+xml",
            ["tif"] = "image/tiff",
            ["tiff"] = "image/tiff",
            ["ico"] = "image/x-icon",
        };

        public IHttpResponse Handle(IHttpRequest request)
        {
            try
            {
                string[] resourcePath = request.Path.Split('/', 3);
                string folderPath = request.Path;

                if (resourcePath.Length > 2)
                {
                    folderPath = resourcePath[2];
                }

                string extension = folderPath.Split('.').Last();
                if (!ExtensionsToMIMETypes.ContainsKey(extension))
                {
                    throw new InvalidOperationException("The file type is not supported.");
                }

                string fileContent = this.ReadFileContent(folderPath);
                return new FileResponse(HttpStatusCode.Ok, fileContent, ExtensionsToMIMETypes[extension]);
            }
            catch (Exception)
            {
                return new NotFoundResponse();
            }
        }

        private string ReadFileContent(string fileFullName)
        {
            return File.ReadAllText(ContentDirectory + fileFullName);
        }
    }
}
