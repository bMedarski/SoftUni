namespace TorshiaModels
{
	using System.Collections.Generic;

	public class Sector
	{
		public Sector()
		{
			this.TaskSectors = new HashSet<TaskSector>();
		}
		public int Id { get; set; }
		public string Name { get; set; }
		public ICollection<TaskSector> TaskSectors { get; set; }
	}
}
