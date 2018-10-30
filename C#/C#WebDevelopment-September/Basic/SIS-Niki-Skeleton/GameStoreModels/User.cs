namespace GameStoreModels
{
	using System.Collections.Generic;

	public class User
	{
		public User()
		{
			this.Games = new List<UsersGames>();
		}
		public int Id { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
		public string FullName { get; set; }
		public virtual Role Role { get; set; }
		public virtual ICollection<UsersGames> Games { get; set; }
		public string CartId { get; set; }
		public virtual Cart Cart { get; set; }
	}
}
