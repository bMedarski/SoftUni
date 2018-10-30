namespace GameStoreModels
{
	using System.Collections.Generic;

	public class Cart
	{
		public Cart()
		{
			this.Games = new HashSet<CartsGames>();	
		}
		public int Id { get; set; }
		public int? UserId { get; set; }
		public virtual User User { get; set; }
		public virtual ICollection<CartsGames> Games { get; set; }
	}
}
