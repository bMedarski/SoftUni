using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_BillsPaymentSystem.Data.Models;

namespace P03_FootballBetting.Data
{
	public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
	{
		public void Configure(EntityTypeBuilder<PaymentMethod> builder)
		{
			builder.HasKey(p => p.Id);

			builder.Property(p => p.BankAccountId)
				.IsRequired(false);

			builder.Property(p => p.CreditCardId)
				.IsRequired(false);

			builder.HasOne(p => p.User)
				.WithMany(u => u.PaymentMethods)
				.HasForeignKey(p => p.UserId);

			builder.HasOne(p => p.BankAccount)
				.WithOne(p => p.PaymentMethod)
				.HasForeignKey<BankAccount>(b => b.PaymentMethodId);

			builder.HasOne(p => p.CreditCard)
				.WithOne(p => p.PaymentMethod)
				.HasForeignKey<CreditCard>(p => p.PaymentMethodId);
		}
	}
}