using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data.Configuration
{
	internal class TownConfiguration : IEntityTypeConfiguration<Town>
	{
		public void Configure(EntityTypeBuilder<Town> builder)
		{
			builder.HasKey(c => c.TownId);

			builder.HasMany(c => c.Teams)
				.WithOne(c => c.Town);
		}

	}
}
