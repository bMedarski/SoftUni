using FastFood.Models;
using Microsoft.EntityFrameworkCore;

namespace FastFood.Data
{
	public class FastFoodDbContext : DbContext
	{
		public FastFoodDbContext()
		{
		}

		public FastFoodDbContext(DbContextOptions options)
			: base(options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder builder)
		{
			if (!builder.IsConfigured)
			{
				builder.UseSqlServer(Configuration.ConnectionString);
			}
		}

		public DbSet<Employee> Employees { get; set; }
		public DbSet<Item> Items { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Position> Positions { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<OrderItem> OrderItems { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{

			builder.Entity<Position>().HasAlternateKey(s => s.Name);
			builder.Entity<Category>().HasAlternateKey(s => s.Name);
			builder.Entity<Item>().HasAlternateKey(s => s.Name);
			builder.Entity<OrderItem>().HasAlternateKey(oi => new { oi.OrderId, oi.ItemId });
			builder.Entity<Order>().Ignore(o => o.TotalPrice);

			builder.Entity<OrderItem>().HasKey(oi => new { oi.OrderId, oi.ItemId });

			builder.Entity<OrderItem>().Property(ts => ts.Quantity)
				.IsRequired();

			builder.Entity<OrderItem>().Property(ts => ts.ItemId)
				.IsRequired();

			builder.Entity<OrderItem>().Property(ts => ts.OrderId)
				.IsRequired();

			builder.Entity<OrderItem>().HasOne(ts => ts.Order)
				.WithMany(t => t.OrderItems)
				.HasForeignKey(tr => tr.OrderId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.Entity<OrderItem>().HasOne(ts => ts.Item)
				.WithMany(sc => sc.OrderItems)
				.HasForeignKey(ts => ts.ItemId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}