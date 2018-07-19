namespace SoftUni.WebServer.Mvc
{
    using System;
    using System.Reflection;
    using SoftUni.WebServer.Server;

    public static class MvcEngine
    {
        public static void Run(WebServer server)
        {
            ConfigureMvcContext(MvcContext.Get);

            while (true)
            {
                try
                {
                    server.Run();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static void ConfigureMvcContext(MvcContext context)
        {
            context.AssemblyName = Assembly.GetEntryAssembly().GetName().Name;
            context.ControllersFolder = "Controllers";
            context.ControllerSuffix = "Controller";
            context.ModelsFolder = "Models";
            context.ViewsFolder = "Views";
        }
    }
}
