namespace TorshiaWebApp.ViewModels.Tasks
{
	using System;

	public class TaskDetailsView
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime? DueDate { get; set; }
		public string Participants { get; set; }
		public string Sector { get; set; }
		public int Level { get; set; }
	}
}
