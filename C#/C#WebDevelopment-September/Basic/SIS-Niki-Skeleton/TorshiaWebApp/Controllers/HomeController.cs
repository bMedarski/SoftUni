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
				var model = new HomeViewModel
				{
					Tasks = this.TasksService.GetAllTasksNotReported()
				};
				
				return this.View(model);
			}

			return this.View();
		}
	}
}
