namespace PeakStats.Data
{
	using Microsoft.EntityFrameworkCore;
	using Models;

	public class PeakStatsContext:DbContext
    {
	    public DbSet<User> Users { get; set; }
	    public DbSet<Peak> Peaks { get; set; }

	    protected override void OnConfiguring(DbContextOptionsBuilder builder)
	    {

		    if (!builder.IsConfigured)
		    {
			    builder.UseSqlServer("Server=.;Database=PeakStats;Integrated Security=True");
		    }

		    base.OnConfiguring(builder);
	    }

	    protected override void OnModelCreating(ModelBuilder builder)
	    {
		    builder.Entity<User>()
			    .HasIndex(u => u.Name)
			    .IsUnique();

		    base.OnModelCreating(builder);
	    }
	}
}
