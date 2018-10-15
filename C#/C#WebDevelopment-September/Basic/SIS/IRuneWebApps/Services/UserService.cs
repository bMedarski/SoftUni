namespace IRuneWebApp.Services
{
	using System.Linq;
	using Common;
	using Contracts;
	using IRuneData;
	using IRuneModels;
	using SIS.HTTP.Cookies;
	using SIS.HTTP.Requests.Contracts;

	public class UserService : IUserService
	{
		private readonly IRuneDbContext db;
		private readonly IHashService hashService;
		public readonly IUserCookieService cookieService;

		public UserService()
		{
			this.db = new IRuneDbContext();
			this.cookieService = new UserCookieService();
			this.hashService = new HashService();
		}
		public User GetUser(string username,string email, string password)
		{
			//get user by username and password
			return this.db.Users.Where(u => (u.Username == username || u.Email==email) && u.Password == password).FirstOrDefault();
		}

		public User CreateUser(string username, string email, string password)
		{
			User user = new User()
			{
				Username = username,
				Password = password,
				Email = email
			};
			this.db.Users.Add(user);
			this.db.SaveChanges();
			return user;
		}
		public bool IsAuthenticated(IHttpRequest request)
		{
			//check if there is cookie with auth key
			if (!request.Cookies.ContainsCookie(Constants.AuthentificationKey))
			{
				return false;
			}

			return true;
		}

		public HttpCookie SignIn(string username,IHttpRequest request)
		{
			//Add username to current session
			request.Session.AddParameter("username",username);
			//Add auth cookie
			var authCookie = this.cookieService.GetUserCookie(username);
			var cookie = new HttpCookie(Constants.AuthentificationKey, authCookie, 5);
			return cookie;
		}

		public string HashPassword(string password)
		{
			return this.hashService.Hash(password);
		}
	}
}
