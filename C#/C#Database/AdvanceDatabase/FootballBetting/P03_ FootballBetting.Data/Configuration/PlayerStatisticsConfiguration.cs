using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data.Configuration
{
	internal class PlayerStatisticConfiguration : IEntityTypeConfiguration<PlayerStatistic>
	{
		public void Configure(EntityTypeBuilder<PlayerStatistic> builder)
		{
			builder.HasKey(c => new {c.GameId,c.PlayerId});
		}

	}
}
