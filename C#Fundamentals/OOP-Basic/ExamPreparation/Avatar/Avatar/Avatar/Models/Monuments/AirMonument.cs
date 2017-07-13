using System.Text;

public class AirMonument : Monument
{
	private int airAffinity;
	public AirMonument(string name,int airAffinity) : base(name)
	{
		this.AirAffinity = airAffinity;
	}

	public int AirAffinity
	{
		get => airAffinity;
		private set => airAffinity = value;
	}

	public override string ToString()
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine($"Air Monument: {this.Name}, Air Affinity: {this.AirAffinity}");
		return sb.ToString().Trim();
	}

	public override int Affinity()
	{
		return this.AirAffinity;
	}
}

