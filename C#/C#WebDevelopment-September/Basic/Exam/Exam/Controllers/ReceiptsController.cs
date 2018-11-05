namespace PandaWebApp.Controllers
{
	using Models.ViewModels.Receipts;
	using PandaDatabase;
	using Services.Contracts;
	using SIS.HTTP.Responses;
	using SIS.MvcFramework;

	public class ReceiptsController:BaseController
	{
		public IReceiptsService ReceiptsService { get; set; }

		public ReceiptsController(PandaDbContext db,IReceiptsService receiptsService)
		:base(db)
		{
			this.ReceiptsService = receiptsService;
		}

		[Authorize]
		public IHttpResponse Details(int id)
		{
			var model = this.ReceiptsService.GetReceipt(id);

			return this.View(model);
		}

		[Authorize]
		public IHttpResponse Index()
		{
			var receipts = this.ReceiptsService.GetMyReceipts(this.User.Username);
			var model = new ReceiptsListViewModel {Receipts = receipts}; 
			return this.View(model);
		}
	}
}
