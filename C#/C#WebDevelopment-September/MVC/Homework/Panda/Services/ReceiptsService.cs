namespace Panda.Services
{
	using System.Collections.Generic;
	using System.Globalization;
	using System.Linq;
	using Common;
	using Contracts;
	using Data;
	using Microsoft.EntityFrameworkCore;
	using ViewModels.Receipts;

	public class ReceiptsService:IReceiptsService
	{
		private ApplicationDbContext Db { get; }

		public ReceiptsService(ApplicationDbContext db)
		{
			this.Db = db;
		}

		public IList<ReceiptsViewModel> GetMyReceipts(string user)
		{
			var currentUser = this.Db.Users.FirstOrDefault(u => u.UserName == user);
			var receipts = this.Db.Receipts
				.Where(r => r.Recipient.UserName == currentUser.UserName)
				.Select(r => new ReceiptsViewModel
				{
					Id = r.Id,
					IssuedOn = r.IssuedOn.ToString(Constants.DateFormatPattern,CultureInfo.InvariantCulture),
					Recipient = currentUser.UserName,
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
				Recipient = r.Recipient.UserName,
				Fee = r.Fee,
				Description = r.Package.Description,
				Address = r.Package.ShippingAddress,
				Weight = r.Package.Weight
			}).FirstOrDefault();
		}
	}
}
