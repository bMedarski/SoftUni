using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data.Models;

namespace P03_SalesDatabase.Data
{
    public class SalesContext:DbContext
    {
	    public SalesContext() { }

	    public SalesContext(DbContextOptions options)
		    : base(options) { }

	    public DbSet<Sale> Sales { get; set; }
	    public DbSet<Store> Stores { get; set; }
	    public DbSet<Product> Products { get; set; }
	    public DbSet<Customer> Customers { get; set; }

	    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	    {
		    if (!optionsBuilder.IsConfigured)
		    {
			    optionsBuilder.UseSqlServer("Server=.;Database=Sales;Integrated Security=True;");
		    }
	    }

	    protected override void OnModelCreating(ModelBuilder modelBuilder)
	    {
		    modelBuilder.Entity<Customer>(entity =>
		    {
			    entity.HasKey(e => e.CustomerId);

			    entity.Property(e => e.Name)
				    .IsRequired(true)
					.HasMaxLength(100)
					.IsUnicode(true);

			    entity.Property(e => e.Email)
				    .IsRequired(true)
				    .HasMaxLength(80)
				    .IsUnicode(false);

			});

		    modelBuilder.Entity<Product>(entity =>
		    {
			    entity.HasKey(e => e.ProductId);

			    entity.Property(e => e.Name)
				    .IsRequired(true)
				    .HasMaxLength(50)
				    .IsUnicode(true);

			    entity.Property(e => e.Description)
				    .IsRequired(true)
				    .HasMaxLength(250)
				    .IsUnicode(true)
					.HasDefaultValue("No description");

				entity.Property(e => e.Quantity)
				    .IsRequired(true);
		    });

		    modelBuilder.Entity<Store>(entity =>
		    {
			    entity.HasKey(e => e.StoreId);

			    entity.Property(e => e.Name)
				    .IsRequired(true)
				    .HasMaxLength(80)
				    .IsUnicode(true);
		    });

		    modelBuilder.Entity<Sale>(entity =>
		    {
			    entity.HasKey(e => e.SaleId);

			    entity.Property(e => e.Date)
				    .HasDefaultValueSql("GETDATE()");

			    entity.HasOne(e => e.Product)
				    .WithMany(p => p.Sales)
					.HasForeignKey(e => e.ProductId);

			    entity.HasOne(e => e.Customer)
				    .WithMany(p => p.Sales)
					.HasForeignKey(e => e.CustomerId);

			    entity.HasOne(e => e.Store)
				    .WithMany(p => p.Sales)
					.HasForeignKey(e => e.StoreId);
		    });
		}
    }
}
