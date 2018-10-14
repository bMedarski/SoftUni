using CHUSKA.Models;
using Microsoft.EntityFrameworkCore;

namespace CHUSHKA.Data
{
    public class ChuskaContex:DbContext
    {

		public DbSet<User> Users { get; set; }
	    public DbSet<Product> Products { get; set; }
	    public DbSet<ProductType> Types { get; set; }
	    public DbSet<Order> Orders { get; set; }
	    public DbSet<Role> Roles { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder builder)
	    {
		    if (!builder.IsConfigured)
		    {
			    builder.UseSqlServer("Server=.;Database=Chuska-bMedarski;Integrated Security=True");
		    }

		    base.OnConfiguring(builder);
	    }

	    protected override void OnModelCreating(ModelBuilder builder)
	    {
		    builder.Entity<User>()
			    .HasIndex(u => u.Username)
			    .IsUnique();

		    builder.Entity<User>()
			    .HasOne(u => u.Role);

			builder.Entity<User>(entity =>
		    {
			    entity
				    .HasMany(u => u.Orders)
				    .WithOne(o => o.Client)
				    .HasForeignKey(o => o.ClientId)
				    .OnDelete(DeleteBehavior.Cascade);
		    });

		    builder.Entity<ProductType>()
			    .HasIndex(u => u.Id)
			    .IsUnique();

		    builder.Entity<Role>()
			    .HasIndex(u => u.Name)
			    .IsUnique();
		}

    }
}
