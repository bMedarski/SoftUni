namespace PandaWebApp.Services
{
	using System.Collections.Generic;
	using System.Globalization;
	using System.Linq;
	using Common;
	using Contracts;
	using Microsoft.EntityFrameworkCore;
	using Models.ViewModels.Receipts;
	using PandaDatabase;

	public class ReceiptsService:IReceiptsService
	{
		private PandaDbContext Db { get; }

		public ReceiptsService(PandaDbContext db)
		{
			this.Db = db;
		}

		public IList<ReceiptsViewModel> GetMyReceipts(string user)
		{
			var currentUser = this.Db.Users.FirstOrDefault(u => u.Username == user);
			var receipts = this.Db.Receipts
				.Where(r => r.RecipientId == currentUser.Id)
				.Select(r => new ReceiptsViewModel
				{
					Id = r.Id,
					IssuedOn = r.IssuedOn.ToString(Constants.DateFormatPattern,CultureInfo.InvariantCulture),
					Recipient = currentUser.Username,
					Fee = r.Fee
				})
				.ToList();

			return receipts;
		}

		public ReceiptDetailedViewModel GetReceipt(int id)
		{
			return this.Db.Receipts.Include(r=>r.Recipient).Include(r=>r.Package).Where(r => r.Id == id).Select(r => new ReceiptDetailedViewModel
			{
				Id = r.Id,
				IssuedOn = r.IssuedOn.ToString(Constants.DateFormatPattern,CultureInfo.InvariantCulture),
				Recipient = r.Recipient.Username,
				Fee = r.Fee,
				Description = r.Package.Description,
				Address = r.Package.ShippingAddress,
				Weight = r.Package.Weight
			}).FirstOrDefault();
		}
	}
}
