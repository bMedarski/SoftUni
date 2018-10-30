namespace GameStore.ViewModels
{
	using System.Collections.Generic;

	public class HomeViewModel
	{
		public IEnumerable<GameViewModel> Games { get; set; }
	}
}
