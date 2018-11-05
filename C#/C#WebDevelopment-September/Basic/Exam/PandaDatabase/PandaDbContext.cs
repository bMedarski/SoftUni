namespace PandaDatabase
{
	using System.Linq;
	using Microsoft.EntityFrameworkCore;
	using PandaModel;

	public class PandaDbContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Package> Packages { get; set; }
		public DbSet<Status> Statuses { get; set; }
		public DbSet<Receipt> Receipts { get; set; }

		protected override void OnConfiguring(
			DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=.;Database=bMedarskiPanda;Integrated Security=True;");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Receipt>().HasOne(u => u.Recipient).WithMany(u => u.Receipts).OnDelete(DeleteBehavior.Restrict);
			modelBuilder.Entity<Package>().HasOne(u => u.Recipient).WithMany(u => u.Packages).OnDelete(DeleteBehavior.Restrict);

			base.OnModelCreating(modelBuilder);
		}
	}
}
