namespace GameStoreModels
{
	public class UsersGames
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public virtual User User { get; set; }
		public int GameId { get; set; }
		public virtual Game Game { get; set; }
	}
}
