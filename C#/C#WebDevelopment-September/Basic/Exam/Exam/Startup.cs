namespace PandaWebApp
{
	using Microsoft.EntityFrameworkCore;
	using PandaDatabase;
	using PandaModel;
	using Services;
	using Services.Contracts;
	using SIS.MvcFramework;
	using SIS.MvcFramework.Services;

	public class Startup : IMvcApplication
	{
		public MvcFrameworkSettings  Configure()
		{
			using (var context = new PandaDbContext())
			{
				context.Database.Migrate();
			}

			//this.SeedDatabase();
			return new MvcFrameworkSettings();
		}

		public void ConfigureServices(IServiceCollection collection)
		{
			collection.AddService<PandaDbContext,PandaDbContext>();
			collection.AddService<IUsersService,UsersService>();
			collection.AddService<IPackagesService,PackagesService>();
			collection.AddService<IReceiptsService,ReceiptsService>();
		}
		private void SeedDatabase()
		{
			using (var context = new PandaDbContext())
			{
				context.Database.EnsureCreated();;

				context.Statuses.Add(new Status { Name = "Pending" });
				context.Statuses.Add(new Status { Name = "Shipped" });
				context.Statuses.Add(new Status { Name = "Delivered" });
				context.Statuses.Add(new Status { Name = "Acquired" });

				context.SaveChanges();
			}
		}
	}
}
