namespace AspNetCoreSecurityDemo.Data
{
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        public DbSet<DataValue> DataValues { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=AspNetCoreSecurityDemo;Integrated Security=True");
        }
    }
}
