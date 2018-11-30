namespace Eventures.WebApp.Filter
{
	using System;
	using Microsoft.AspNetCore.Mvc.Filters;
	using Microsoft.Extensions.Logging;

	public class LogEventActionFilter : IActionFilter
	{

		private readonly ILogger logger;

		public LogEventActionFilter(ILogger<LogEventActionFilter> logger)
		{
			this.logger = logger;
		}
		public void OnActionExecuted(ActionExecutedContext context)
		{
			var eventName = context.HttpContext.Request.Form["Name"];
			var eventStart = context.HttpContext.Request.Form["Start"];
			var eventEnd = context.HttpContext.Request.Form["End"];

			this.logger.LogCritical($"{DateTime.UtcNow} Administrator {context.HttpContext.User.Identity.Name} create event {eventName} ({eventStart} / {eventEnd}).");
		}

		public void OnActionExecuting(ActionExecutingContext context)
		{
			//throw new System.NotImplementedException();
		}
	}
}
