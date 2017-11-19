using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data
{
	internal class BetConfiguration : IEntityTypeConfiguration<Bet>
	{
		public void Configure(EntityTypeBuilder<Bet> builder)
		{
			builder.HasKey(e => e.BetId);

		}
	}
}