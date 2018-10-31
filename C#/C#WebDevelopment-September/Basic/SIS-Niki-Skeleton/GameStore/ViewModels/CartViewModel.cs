namespace GameStore.ViewModels
{
	using System.Collections.Generic;

	public class CartViewModel
	{
		public IEnumerable<GameViewModel> Games { get; set; }
		public decimal TotalPrice { get; set; }
	}
}
