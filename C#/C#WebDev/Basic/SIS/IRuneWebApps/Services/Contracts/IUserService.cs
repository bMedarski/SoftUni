namespace IRuneWebApp.Services.Contracts
{
	using IRuneModels;
	using SIS.HTTP.Cookies;
	using SIS.HTTP.Requests.Contracts;

	public interface IUserService
	{
		User GetUser(string username, string email, string password);
		User CreateUser(string username, string email, string password);
		bool IsAuthenticated(IHttpRequest request);
		HttpCookie SignIn(string username, IHttpRequest request);
		string HashPassword(string password);
	}
}
