namespace PandaWebApp.Models.ViewModels.Receipts
{
	using System.Collections.Generic;

	public class ReceiptsListViewModel
	{
		public IEnumerable<ReceiptsViewModel> Receipts { get; set; }
	}
}
