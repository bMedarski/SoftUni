namespace Eventures.WebApp.ViewModels.Orders
{
	using System.ComponentModel.DataAnnotations;
	using System.Linq;
	using Data;
	using ValidationAttributes;

	public class OrderBindingModel
	{

		[Required]
		public string Id { get; set; }

		[Required]
		[Range(1,int.MaxValue)]
		public int TicketsCount { get; set; }

		[Required]
		[Range(0,int.MaxValue)]
		[GreaterNumberValidation("TicketsCount",ErrorMessage = "Tickets count must be less then Total tickets count")]
		public int TotalTickets { get; set; }

	}
}
