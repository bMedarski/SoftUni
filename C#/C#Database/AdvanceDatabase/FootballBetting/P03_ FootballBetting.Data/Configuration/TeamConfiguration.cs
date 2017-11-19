using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data.Configuration
{
    internal class TeamConfiguration : IEntityTypeConfiguration<Team>
	{
		public void Configure(EntityTypeBuilder<Team> builder)
		{
			builder.HasKey(e => e.TeamId);

			builder.HasMany(t => t.HomeGames)
				.WithOne(g => g.HomeTeam);

			builder.HasMany(t => t.AwayGames)
				.WithOne(g => g.AwayTeam);

			builder.HasMany(t => t.Players)
				.WithOne(g => g.Team);
		}
	}
}
