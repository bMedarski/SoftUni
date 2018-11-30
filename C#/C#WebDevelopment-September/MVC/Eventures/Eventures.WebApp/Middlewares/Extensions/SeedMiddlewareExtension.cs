namespace Eventures.WebApp.Middlewares.Extensions
{
	using Microsoft.AspNetCore.Builder;

	public static class SeedMiddlewareExtension
	{
		public static IApplicationBuilder UseSeedMiddleware(
			this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<SeedMiddleware>();
		}
	}
}
