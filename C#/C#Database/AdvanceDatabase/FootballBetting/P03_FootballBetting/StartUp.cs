using P03_FootballBetting.Data;

namespace P03_FootballBetting
{
	class StartUp
	{
		static void Main()
		{
			var db = new FootballBettingContext();

			using (db)
			{
				
			}
		}
	}
}