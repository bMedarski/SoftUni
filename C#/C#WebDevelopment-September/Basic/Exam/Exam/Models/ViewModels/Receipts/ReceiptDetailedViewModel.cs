namespace PandaWebApp.Models.ViewModels.Receipts
{
	public class ReceiptDetailedViewModel
	{
		public int Id { get; set; }
		public string IssuedOn { get; set; }
		public string Address { get; set; }
		public double Weight { get; set; }
		public string Description { get; set; }
		public string Recipient { get; set; }
		public decimal Fee { get; set; }
	}
}
