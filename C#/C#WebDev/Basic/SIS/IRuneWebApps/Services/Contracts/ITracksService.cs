namespace IRuneWebApp.Services.Contracts
{
	using IRuneModels;

	public interface ITracksService
	{
		Track Create(string name, string link, decimal price, string albumId);

		Track GetTrack(string id);
	}
}
