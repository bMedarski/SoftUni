using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Panda.Data
{
	public class ApplicationDbContext : IdentityDbContext<User>
	{
		public DbSet<Package> Packages { get; set; }
		public DbSet<Status> Statuses { get; set; }
		public DbSet<Receipt> Receipts { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Receipt>().HasOne(u => u.Recipient).WithMany(u => u.Receipts).OnDelete(DeleteBehavior.Restrict);
			modelBuilder.Entity<Package>().HasOne(u => u.Recipient).WithMany(u => u.Packages).OnDelete(DeleteBehavior.Restrict);

			base.OnModelCreating(modelBuilder);
		}
	}
}
