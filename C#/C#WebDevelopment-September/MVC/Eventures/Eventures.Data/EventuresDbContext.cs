namespace Eventures.Data
{
	using EventuresModel;
	using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore;

	public class EventuresDbContext:IdentityDbContext<EventuresUser>
	{

		public DbSet<EventuresEvent> EventuresEvents { get; set; }
		public DbSet<EventuresOrder> EventuresOrders { get; set; }

		public EventuresDbContext(DbContextOptions<EventuresDbContext> options)
			: base(options)
		{
		}
	}
}
