using StartUp.Server;
using StartUp.Server.Contracts;

namespace StartUp.Application.Views
{
	public class UserDetailsView:IView
	{
		private Model model;

		public UserDetailsView(Model model)
		{
			this.model = model;
		}
		public string View()
		{
			return $"<body>Hello, {this.model["name"]}!</body>";
		}
	}
}
