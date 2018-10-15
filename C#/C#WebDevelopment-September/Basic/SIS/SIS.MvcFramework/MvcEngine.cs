namespace SIS.MvcFramework
{
	using System;
	using System.Reflection;
	using WebServer;

	public static class MvcEngine
	{

		public static void Run(Server server)
		{
			RegisterAssemblyName();

			try
			{
				server.Run();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}

		private static void RegisterAssemblyName()
		{
			MvcContext.Get.AssemblyName = Assembly.GetEntryAssembly().GetName().Name;
		}
	}
}
