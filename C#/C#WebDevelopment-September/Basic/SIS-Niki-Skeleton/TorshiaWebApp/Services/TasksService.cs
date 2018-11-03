using TorshiaWebApp.ViewModels.Tasks;

namespace TorshiaWebApp.Services
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using TorshiaData;
	using TorshiaModels;

	public class TasksService
	{
		public TasksService()
		{
			this.Db = new TorshiaDb();
		}
		private TorshiaDb Db { get; set; }

		internal bool IsValidTaskId(int id)
		{
			var task = this.Db.Tasks.FirstOrDefault(t => t.Id == id);
			if (task == null)
			{
				return false;
			}
			return true;
		}
		internal void Create(TaskCreateViewModel model)
		{
			var task = new Task();
			task.Description = model.Description;
			task.Title = model.Title;
			task.DueDate = model.DueDate;
			task.Participants = model.Participants;
			task.IsReported = false;
			if (model.Sector != null)
			{
				foreach (var userSector in model.Sector)
				{
					var sector = this.GetSector(userSector);
					if (sector != null)
					{
						var taskSector = new TaskSector()
						{
							Task = task,
							Sector = sector,
						};
						this.Db.TaskSectors.Add(taskSector);
					}
				}
			}
			this.Db.Tasks.Add(task);
			this.Db.SaveChanges();
		}

		internal void Report(int id,string username)
		{
			var task = this.Db.Tasks.FirstOrDefault(t => t.Id == id);
			task.IsReported = true;
			var user = this.Db.Users.FirstOrDefault(u => u.Username == username);

			var report = new Report
			{
				Task = task,
				ReportedOn = DateTime.UtcNow,
				Reporter = user,
				Status = (Status) Enum.Parse(typeof(Status), this.GetReportStatus()),
			};

			this.Db.Reports.Add(report);
			this.Db.SaveChanges();
		}

		internal TaskDetailsView GetTaskById(int id)
		{
			return this.Db.Tasks.Where(t => t.Id == id).Select(t => new TaskDetailsView
			{
				Id = t.Id,
				Title = t.Title,
				Description = t.Description,
				DueDate = t.DueDate,
				Participants = t.Participants,
				Level = t.AffectedSectors.Count,
				Sector = string.Join(", ", t.AffectedSectors.Select(s => s.Sector.Name).ToList())
			}).FirstOrDefault();
		}

		internal Sector GetSector(string name)
		{
			return this.Db.Sectors.Where(s => s.Name == name).FirstOrDefault();
		}

		internal List<TaskViewModel> GetAllTasksNotReported()
		{
			return this.Db.Tasks.Where(t=>t.IsReported==false).Select(t => new TaskViewModel()
			{
				Id = t.Id,
				Title = t.Title,
				Level = t.AffectedSectors.Count
			}).ToList();
		}

		private string GetReportStatus()
		{
			Random rnd = new Random();
			int number = rnd.Next(1, 5);
			if (number == 1)
			{
				return "Archived";
			}
			else
			{
				return "Completed";
			}
		}
	}

}
