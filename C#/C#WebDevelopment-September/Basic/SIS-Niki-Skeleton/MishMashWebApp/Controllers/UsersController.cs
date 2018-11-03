namespace MishMashWebApp.Controllers
{
	using MIshMashData;
	using Services;

	public class UsersController:BaseController
	{
		public UsersService UsersService { get; set; }

		public UsersController(MishMashDbContext db,UsersService usersService)
		:base(db)
		{
			this.UsersService = usersService;
		}
	}
}
