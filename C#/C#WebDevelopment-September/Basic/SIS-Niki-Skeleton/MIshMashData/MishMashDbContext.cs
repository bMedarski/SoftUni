namespace MIshMashData
{
	using Microsoft.EntityFrameworkCore;
	using MishMashModels;

	public class MishMashDbContext:DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Channel> Channels { get; set; }
		public DbSet<ChannelType> ChannelTypes { get; set; }
		public DbSet<Tag> Tags { get; set; }
		public DbSet<UserChannel> UserChannels { get; set; }
		public DbSet<ChannelTag> ChannelTags { get; set; }

		protected override void OnConfiguring(
			DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=.;Database=MishMash;Integrated Security=True;");
		}
	}
}
