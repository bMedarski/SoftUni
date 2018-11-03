namespace TorshiaWebApp.ViewModels.Reports
{
	using System;

	public class ReportDetailViewModel
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public int Level { get; set; }
		public string Description { get; set; }
		public string Reporter { get; set; }
		public DateTime? DueDate { get; set; }
		public DateTime ReportedOn { get; set; }
		public string Participants { get; set; }
		public string Status { get; set; }
		public string Sectors { get; set; }
	}
}
