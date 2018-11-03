namespace TorshiaWebApp.Services
{
	using System.Collections.Generic;
	using System.Linq;
	using TorshiaData;
	using ViewModels.Reports;

	public class ReportsService
	{
		public ReportsService()
		{
			this.Db = new TorshiaDb();
		}
		public TorshiaDb Db { get; set; }

		public List<ReportViewModel> GetAllReports()
		{
			return this.Db.Reports.Select(r => new ReportViewModel
			{
				Id = r.Id,
				Title = r.Task.Title,
				Level = r.Task.AffectedSectors.Count,
				Status = r.Status.ToString()
			}).ToList();
		}

		public bool IsValidReportId(int id)
		{
			var report = this.Db.Reports.Where(r => r.Id == id).FirstOrDefault();
			if (report == null)
			{
				return false;
			}

			return true;
		}

		public ReportDetailViewModel GetReport(int id)
		{
			return this.Db.Reports.Where(r => r.Id == id).Select(r => new ReportDetailViewModel
			{
				Id = r.Id,
				Description = r.Task.Description,
				Title = r.Task.Title,
				Status = r.Status.ToString(),
				DueDate = r.Task.DueDate,
				ReportedOn = r.ReportedOn,
				Reporter = r.Reporter.Username,
				Participants = r.Task.Participants,
				Sectors = string.Join(", ", r.Task.AffectedSectors.Select(s => s.Sector.Name).ToList()),
				Level = r.Task.AffectedSectors.Count,
			}).FirstOrDefault();
		}
	}
}
