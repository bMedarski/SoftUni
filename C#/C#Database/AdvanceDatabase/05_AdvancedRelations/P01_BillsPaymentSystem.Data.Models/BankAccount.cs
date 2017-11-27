using System;

namespace P01_BillsPaymentSystem.Data.Models
{
	public class BankAccount
	{
		public int BankAccountId { get; set; }
		public decimal Balance { get; set; }
		public string BankName { get; set; }
		public string SwiftCode { get; set; }

		public int PaymentMethodId { get; set; }
		public PaymentMethod PaymentMethod { get; set; }
	}
}
