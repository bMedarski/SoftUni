namespace TorshiaWebApp
{
	using Services;
	using SIS.MvcFramework;
	using SIS.MvcFramework.Services;

	public class Startup : IMvcApplication
	{
		public MvcFrameworkSettings  Configure()
		{
			return new MvcFrameworkSettings();
		}

		public void ConfigureServices(IServiceCollection collection)
		{
			collection.AddService<ValidateService,ValidateService>();
			collection.AddService<UsersService,UsersService>();
			collection.AddService<TasksService,TasksService>();
			collection.AddService<ReportsService,ReportsService>();
		}
	}
}
