namespace BasicWebServer
{
    class StartUp
    {
        static void Main()
        {
            var server = new HttpServer();
			server.Start();
        }
    }
}
