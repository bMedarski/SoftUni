namespace IRuneWebApp.Services.Contracts
{
	using IRuneModels;

	public interface IUserService
	{
		User GetUser(string username, string email, string password);
		User CreateUser(string username, string email, string password);
		//bool IsAuthenticated(IHttpRequest request);
		//HttpCookie SignIn(string username, IHttpRequest request);
		string HashPassword(string password);
	}
}
