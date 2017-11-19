using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data.Configuration
{
    internal class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
		public void Configure(EntityTypeBuilder<Color> builder)
		{
			builder.HasKey(c => c.ColorId);

			builder.HasMany(c => c.PrimaryKitTeams)
				.WithOne(c => c.PrimaryKitColor);


			builder.HasMany(c => c.SecondaryKitTeams)
				.WithOne(c => c.SecondaryKitColor);

		}

	}
}
