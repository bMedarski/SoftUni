namespace AirportData
{
	using AirportModels;
	using Microsoft.EntityFrameworkCore;

	public class AirportDb:DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Ticket> Tickets { get; set; }
		public DbSet<Flight> Flights { get; set; }

		protected override void OnConfiguring(
			DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=.;Database=Airport;Integrated Security=True;");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Ticket>().HasOne<User>().WithMany(u => u.Tickets).HasForeignKey(u => u.CustomerId);

		}
	}
}
