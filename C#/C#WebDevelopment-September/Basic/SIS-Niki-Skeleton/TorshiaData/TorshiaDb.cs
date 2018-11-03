namespace TorshiaData
{
	using Microsoft.EntityFrameworkCore;
	using TorshiaModels;

	public class TorshiaDb:DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Task> Tasks { get; set; }
		public DbSet<Report> Reports { get; set; }
		public DbSet<Sector> Sectors { get; set; }
		public DbSet<TaskSector> TaskSectors { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder
				.UseSqlServer("Server=.;Database=TorshiaDB;Integrated Security=True;");
		}
	}
}
