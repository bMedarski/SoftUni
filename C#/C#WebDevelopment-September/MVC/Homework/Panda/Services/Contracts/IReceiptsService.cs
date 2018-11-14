namespace Panda.Services.Contracts
{
	using System.Collections.Generic;
	using ViewModels.Receipts;

	public interface IReceiptsService
	{
		IList<ReceiptsViewModel> GetMyReceipts(string user);
		ReceiptDetailedViewModel GetReceipt(int id);
	}
}
