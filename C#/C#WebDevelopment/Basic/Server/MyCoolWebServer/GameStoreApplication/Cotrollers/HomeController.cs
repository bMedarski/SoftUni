namespace MyCoolWebServer.GameStoreApplication.Cotrollers
{
	using Infrastructure;
	using Server.Http.Contracts;

	public class HomeController:Controller
    {
			public IHttpResponse Index() => this.FileViewResponse(@"home\guest-home");
    }
}
