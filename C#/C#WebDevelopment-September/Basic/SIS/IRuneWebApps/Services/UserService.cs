namespace IRuneWebApp.Services
{
	using System.Linq;
	using Contracts;
	using IRuneData;
	using IRuneModels;

	public class UserService : IUserService
	{
		private readonly IRuneDbContext db;
		private readonly IHashService hashService;

		public UserService(IHashService hashService)
		{
			this.db = new IRuneDbContext();
			this.hashService = hashService;
		}
		public User GetUser(string username,string email, string password)
		{
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
		public string HashPassword(string password)
		{
			return this.hashService.Hash(password);
		}
	}
}
