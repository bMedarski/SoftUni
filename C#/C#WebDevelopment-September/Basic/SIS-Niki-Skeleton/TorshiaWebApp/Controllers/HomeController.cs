namespace TorshiaWebApp.Controllers
{
	using Services;
	using SIS.HTTP.Responses;
	using ViewModels.Home;

	public class HomeController:BaseController
	{
		public HomeController(TasksService tasksService)
		{
			this.TasksService = tasksService;
		}

		private TasksService TasksService { get; set; }

		public IHttpResponse Index()
		{
			if (this.User.IsLoggedIn)
			{
				var tasks = this.TasksService.GetAllTasksNotReported();
				var model = new HomeViewModel
				{
					Tasks = tasks,

				};
				var productsCount = tasks.Count;
				if (productsCount % 5 != 0 && productsCount % 5 < 5)
				{
					model.EmptyBlocks = 5 - (productsCount % 5);
				}
				return this.View(model);
			}

			return this.View();
		}
	}
}
