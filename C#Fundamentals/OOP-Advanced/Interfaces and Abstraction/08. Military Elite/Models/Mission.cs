public class Mission:IMission
{
	private MissionState state;
	private string codeName;

	public Mission(MissionState state, string codeName)
	{
		this.State = state;
		this.CodeName = codeName;
	}

	public MissionState State
	{
		get { return this.state; }
		private set { this.state = value; }
	}

	public string CodeName
	{
		get { return this.codeName; }
		private set { this.codeName = value; }
	}

	public void CompleteMission()
	{
		this.state = MissionState.finished;
	}

	public override string ToString()
	{
		//Code Name: <codeName> State: <state>
		return $"Code Name: {this.CodeName} State: {this.State}";
	}
}

