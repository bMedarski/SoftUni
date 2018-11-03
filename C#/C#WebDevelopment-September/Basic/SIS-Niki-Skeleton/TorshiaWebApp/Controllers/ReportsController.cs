namespace TorshiaWebApp.Controllers
{
	using Common;
	using Services;
	using SIS.HTTP.Responses;
	using SIS.MvcFramework;
	using ViewModels.Reports;

	public class ReportsController:BaseController
	{
		public ReportsController(ReportsService reportsService)
		{
			this.ReportsService = reportsService;
		}
		private ReportsService ReportsService { get; set; }

		[Authorize("Admin")]
		public IHttpResponse All()
		{
			var reports = new ReportListView
			{
				Reports = this.ReportsService.GetAllReports()
			};
			
			return this.View(reports);
		}

		[Authorize("Admin")]
		public IHttpResponse Details(int id)
		{
			if (!this.ReportsService.IsValidReportId(id))
			{
				return this.BadRequestError(Constants.NoSuchIdMessage);
			}
			var report = this.ReportsService.GetReport(id);
			return this.View(report);
		}
	}
}
