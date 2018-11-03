namespace TorshiaModels
{
	using System;
	using System.Collections.Generic;

	public class Task
	{
		public Task()
		{
			this.AffectedSectors = new HashSet<TaskSector>();
		}
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public bool IsReported { get; set; }
		public ICollection<TaskSector> AffectedSectors { get; set; }
		public DateTime? DueDate { get; set; }
		public string Participants { get; set; }
	}
}
