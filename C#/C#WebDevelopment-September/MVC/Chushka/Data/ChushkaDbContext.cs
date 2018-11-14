namespace Data
{
	using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore;
	using Models;

	public class ChushkaDbContext : IdentityDbContext<ChushkaUser>
	{
		public DbSet<Product> Products { get; set; }
		public DbSet<Order> Orders { get; set; }

		public ChushkaDbContext(DbContextOptions<ChushkaDbContext> options)
			: base(options)
		{
		}
	}
}
