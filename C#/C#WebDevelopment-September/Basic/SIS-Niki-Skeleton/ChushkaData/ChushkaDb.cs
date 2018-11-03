namespace ChushkaData
{
	using ChushkaModels;
	using Microsoft.EntityFrameworkCore;

	public class ChushkaDb:DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<ProductType> ProductTypes { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=.;Database=Chushka;Trusted_Connection=true;");

			base.OnConfiguring(optionsBuilder);
		}
	}
}
