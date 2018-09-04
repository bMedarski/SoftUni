namespace SimpleMvc.Data
{
    using Constants;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class MeTubeDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Tube> Tubes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(Configuration.ConfigurationString);
            }

            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            builder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            builder.Entity<User>(entity =>
            {
                entity
                    .HasMany(u => u.Tubes)
                    .WithOne(t => t.Uploader)
                    .HasForeignKey(t => t.UploaderId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            base.OnModelCreating(builder);
        }
    }
}
