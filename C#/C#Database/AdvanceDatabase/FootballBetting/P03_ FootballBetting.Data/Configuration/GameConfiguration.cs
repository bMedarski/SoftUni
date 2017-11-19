using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data.Configuration
{
	internal class GameConfiguration : IEntityTypeConfiguration<Game>
	{
		public void Configure(EntityTypeBuilder<Game> builder)
		{
			builder.HasKey(c => c.GameId);

			builder.HasMany(g => g.Bets)
				.WithOne(g => g.Game);

			builder.HasMany(g => g.PlayerStatistics)
				.WithOne(g => g.Game);
		}

	}
}
