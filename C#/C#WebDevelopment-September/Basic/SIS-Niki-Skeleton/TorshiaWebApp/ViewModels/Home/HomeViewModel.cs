namespace TorshiaWebApp.ViewModels.Home
{
	using System.Collections.Generic;
	using Tasks;

	public class HomeViewModel
	{
		public IEnumerable<TaskViewModel> Tasks { get; set; }
		public int EmptyBlocks { get; set; }
	}
}
