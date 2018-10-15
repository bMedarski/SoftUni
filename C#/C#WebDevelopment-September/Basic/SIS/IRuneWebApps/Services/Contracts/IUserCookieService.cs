public interface IUserCookieService
{
	string GetUserCookie(string userName);

	string GetUserData(string cookieContent);
}