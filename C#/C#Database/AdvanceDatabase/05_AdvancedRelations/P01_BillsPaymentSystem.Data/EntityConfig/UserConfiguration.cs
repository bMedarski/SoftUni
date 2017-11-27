using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_BillsPaymentSystem.Data.Models;

namespace P03_FootballBetting.Data
{
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasKey(u=>u.UserId);

			builder.Property(u => u.FirstName)
				.HasMaxLength(50)
				.IsRequired(true)
				.IsUnicode(true);
			
			builder.Property(u => u.LastName)
				.HasMaxLength(50)
				.IsRequired(true)
				.IsUnicode(true);

			builder.Property(u => u.Email)
				.HasMaxLength(80)
				.IsRequired(true)
				.IsUnicode(false);

			builder.Property(u => u.Password)
				.HasMaxLength(25)
				.IsRequired(true)
				.IsUnicode(false);

			
		}
	}
}