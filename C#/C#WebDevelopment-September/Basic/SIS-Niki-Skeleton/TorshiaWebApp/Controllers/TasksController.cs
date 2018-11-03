namespace TorshiaWebApp.Controllers
{
	using Services;
	using SIS.HTTP.Responses;
	using SIS.MvcFramework;
	using ViewModels.Tasks;
	using Common;

	public class TasksController:BaseController
	{
		public TasksController(TasksService tasksService)
		{
			this.TasksService = tasksService;
		}
		private TasksService TasksService { get; set; }

		[Authorize("Admin")]
		public IHttpResponse Create()
		{
			return this.View();
		}

		[Authorize("Admin")]
		[HttpPost]
		public IHttpResponse Create(TaskCreateViewModel model)
		{
			this.TasksService.Create(model);
			return this.RedirectToHome();
		}

		[Authorize]
		public IHttpResponse Details(int id)
		{
			if (!this.TasksService.IsValidTaskId(id))
			{
				return this.BadRequestError(Constants.NoSuchIdMessage);
			}
			var task = this.TasksService.GetTaskById(id);
			return this.View(task);
		}

		public IHttpResponse Report(int id)
		{
			if (!this.TasksService.IsValidTaskId(id))
			{
				return this.BadRequestError(Constants.NoSuchIdMessage);
			}

			this.TasksService.Report(id,this.User.Username);
			return this.RedirectToHome();
		}
	}
}
