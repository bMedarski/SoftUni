namespace ChushkaWebApp
{
	using ChushkaData;
	using Microsoft.EntityFrameworkCore;
	using Services;
	using SIS.MvcFramework;
	using SIS.MvcFramework.Services;

	public class Startup : IMvcApplication
	{
		public MvcFrameworkSettings  Configure()
		{
			using (var context = new ChushkaDb())
			{
				context.Database.Migrate();
			}

			this.SeedDatabase();
			return new MvcFrameworkSettings();
		}

		public void ConfigureServices(IServiceCollection collection)
		{
			collection.AddService<ChushkaDb,ChushkaDb>();
			collection.AddService<UsersService,UsersService>();
			collection.AddService<ProductsService,ProductsService>();
			collection.AddService<OrdersService,OrdersService>();
		}
		private void SeedDatabase()
		{
			using (var context = new ChushkaDb())
			{
				//context.Database.EnsureCreated();;

				//context.ProductTypes.Add(new ProductType { Name = "Food" });
				//context.ProductTypes.Add(new ProductType { Name = "Domestic" });
				//context.ProductTypes.Add(new ProductType { Name = "Health" });
				//context.ProductTypes.Add(new ProductType { Name = "Cosmetic" });
				//context.ProductTypes.Add(new ProductType { Name = "Other" });

				//context.Products.Add(new Product() { Name = "Banana",Description = "Yellow fruit, very delicious",Price = 2.5m,ProductTypeId = 1});
				//context.Products.Add(new Product() { Name = "CornFlakes",Description = "Eat much, but never get satisfied",Price = 10m,ProductTypeId = 1});
				//context.Products.Add(new Product() { Name = "Computer",Description = "Some brilliant invention, every one is using it",Price = 1290m,ProductTypeId = 2});
				//context.Products.Add(new Product() { Name = "Toothpaste",Description = "For cleaning your teeth, every day use",Price = 0.2m,ProductTypeId = 4});
				//context.Products.Add(new Product() { Name = "Cup",Description = "Every day item for every family, just cant",Price = 1.9m,ProductTypeId = 5});
				//context.Products.Add(new Product() { Name = "Chocolate",Description = "Cant live without it. Makes everyone happy",Price = 2.3m,ProductTypeId = 1});
				//context.Products.Add(new Product() { Name = "Aspirin",Description = "the pill for everything. Take one - be as new",Price = 2.5m,ProductTypeId = 3});

				context.SaveChanges();
			}
		}
	}
}
