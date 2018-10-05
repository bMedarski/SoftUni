namespace IRuneWebApp.Controllers
{
	using SIS.HTTP.Requests.Contracts;
	using SIS.HTTP.Responses.Contracts;

	public class UsersController:BaseContoller
	{
		public IHttpResponse Login(IHttpRequest request)
		{
			return this.View();
		}
		public IHttpResponse Register(IHttpRequest request)
		{
			return this.View();
		}
	}
}
