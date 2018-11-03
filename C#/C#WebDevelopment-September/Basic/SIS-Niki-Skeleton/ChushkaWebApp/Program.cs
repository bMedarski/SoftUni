namespace ChushkaWebApp
{
	using SIS.MvcFramework;

	class Program
	{
		static void Main()
		{
			WebHost.Start(new Startup());
		}
	}
}
