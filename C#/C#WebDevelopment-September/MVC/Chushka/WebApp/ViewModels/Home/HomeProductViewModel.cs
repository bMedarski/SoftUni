namespace WebApp.ViewModels.Home
{
	public class HomeProductViewModel
	{
		private string description;

		public int Id { get; set; }
		public string Name { get; set; }

		public string Description
		{
			get
			{
				if (this.description.Length < 50)
				{
					return this.description;
				}
				else
				{
					return this.description.Substring(0, 50) + "...";
				}
			}
			set { this.description = value; }
		}

		public decimal Price { get; set; }
	}
}
