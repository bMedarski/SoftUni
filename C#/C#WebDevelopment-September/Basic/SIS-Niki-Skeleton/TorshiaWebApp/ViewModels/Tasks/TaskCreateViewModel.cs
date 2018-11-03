namespace TorshiaWebApp.ViewModels.Tasks
{
	using System;
	using System.Collections.Generic;

	public class TaskCreateViewModel
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime DueDate { get; set; }
		public string Participants { get; set; }
		public IEnumerable<string> Sector { get; set; }

	}
}
