using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_BillsPaymentSystem.Data.Models;

namespace P03_FootballBetting.Data
{
	public class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
	{
		public void Configure(EntityTypeBuilder<CreditCard> builder)
		{
			builder.HasKey(c => c.CreditCardId);

			builder.Ignore(c => c.LimitLeft);
			builder.Ignore(c => c.PaymentMethodId);
		}
	}
}