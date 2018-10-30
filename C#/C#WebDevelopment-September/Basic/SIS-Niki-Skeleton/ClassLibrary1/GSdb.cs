namespace GameSoreDataNew
{
	using GameSoreModelsNew;
	using Microsoft.EntityFrameworkCore;

	public class GSdb:DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Game> Games { get; set; }
		public DbSet<Cart> Carts { get; set; }
		public DbSet<CartGame> CartGames { get; set; }
		public DbSet<UserGame> UserGames { get; set; }

		protected override void OnConfiguring(
			DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Server=.;Database=GameStoreNew;Integrated Security=True;");
		}
	}
}
