namespace MeTube.App
{
    using SimpleMvc.Data;
    using SimpleMvc.Framework;
    using SimpleMvc.Framework.Routers;
    using WebServer;

    public class Launcher
    {
        public static void Main()
        {
            var server = new WebServer(1111, new ControllerRouter(), new ResourceRouter());

            MvcEngine.Run(server, new MeTubeDbContext());
        }
    }
}
