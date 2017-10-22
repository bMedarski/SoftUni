using System.Collections.Generic;
using System.Text;

public class Commando : SpecialisedSoldier, ICommando
{
	private IList<IMission> missions;

	public Commando(int id, string firstName, string lastName, double salary, Corps corps)
		: base(id, firstName, lastName, salary, corps)
	{
		this.missions = new List<IMission>();
	}

	public void AddMission(IMission mission)
	{
		this.missions.Add(mission);
	}
	public override string ToString()
	{
		var sb = new StringBuilder();
		sb.AppendLine(base.ToString());
		sb.AppendLine("Missions:");
		foreach (var mission in missions)
		{
			if (mission.State==MissionState.inProgress)
			{
				sb.AppendLine($"  {mission}");
			}			
		}
		return sb.ToString().Trim();
	}
}

