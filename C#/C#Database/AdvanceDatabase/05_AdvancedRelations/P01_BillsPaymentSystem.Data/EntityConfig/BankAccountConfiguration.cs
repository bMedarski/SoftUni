using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_BillsPaymentSystem.Data.Models;

namespace P03_FootballBetting.Data
{
	public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
	{
		public void Configure(EntityTypeBuilder<BankAccount> builder)
		{
			builder.HasKey(b => b.BankAccountId);
			builder.Ignore(c => c.PaymentMethodId);

			builder.Property(b => b.BankName)
				.HasMaxLength(50)
				.IsRequired(true)
				.IsUnicode(true);

			builder.Property(b => b.SwiftCode)
				.HasMaxLength(20)
				.IsRequired(true)
				.IsUnicode(false);
		}
	}
}