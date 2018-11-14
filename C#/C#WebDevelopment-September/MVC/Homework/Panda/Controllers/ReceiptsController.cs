using Microsoft.AspNetCore.Mvc;

namespace Panda.Controllers
{
	using Data;
	using Microsoft.AspNetCore.Authorization;
	using Services.Contracts;
	using ViewModels.Receipts;

	public class ReceiptsController:BaseController
	{
		public IReceiptsService ReceiptsService { get; set; }

		public ReceiptsController(ApplicationDbContext db,IReceiptsService receiptsService)
			:base(db)
		{
			this.ReceiptsService = receiptsService;
		}

		[Authorize]
		public IActionResult Details(int id)
		{
			var model = this.ReceiptsService.GetReceipt(id);

			return this.View(model);
		}

		[Authorize]
		public IActionResult Index()
		{
			var receipts = this.ReceiptsService.GetMyReceipts(this.User.Identity.Name);
			var model = new ReceiptsListViewModel {Receipts = receipts}; 
			return this.View(model);
		}
	}
}