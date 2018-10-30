namespace GameStoreData
{
	using GameStoreModels;
	using Microsoft.EntityFrameworkCore;

	public class GameDbContext:DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Game> Games { get; set; }
		public DbSet<Cart> Carts { get; set; }


		protected override void OnConfiguring(
			DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Server=.;Database=GameStore;Integrated Security=True;");
		}
	}
}
