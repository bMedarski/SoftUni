namespace PandaWebApp.Services.Contracts
{
	using System.Collections.Generic;
	using Models.ViewModels.Receipts;

	public interface IReceiptsService
	{
		IList<ReceiptsViewModel> GetMyReceipts(string user);
		ReceiptDetailedViewModel GetReceipt(int id);
	}
}
