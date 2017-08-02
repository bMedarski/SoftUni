public interface IMission
{
	MissionState State { get; }
	string CodeName { get; }
	void CompleteMission();
	string ToString();
}

