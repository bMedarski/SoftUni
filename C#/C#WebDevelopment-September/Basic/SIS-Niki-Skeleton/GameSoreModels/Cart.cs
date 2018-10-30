namespace GameSoreModelsNew
{
	using System.Collections.Generic;

	public class Cart
	{
		public Cart()
		{
			this.Games = new List<CartGame>();	
		}
		public int Id { get; set; }
		public int? UserId { get; set; }
		public virtual User User { get; set; }
		public virtual ICollection<CartGame> Games { get; set; }
	}
}
