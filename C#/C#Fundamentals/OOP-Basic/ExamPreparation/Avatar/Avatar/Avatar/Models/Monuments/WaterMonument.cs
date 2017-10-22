using System.Text;

public class WaterMonument : Monument
{
	private int waterAffinity;
	public WaterMonument(string name,int waterAffinity) : base(name)
	{
		this.WaterAffinity = waterAffinity;
	}

	public int WaterAffinity
	{
		get => waterAffinity;
		private set => waterAffinity = value;
	}

	public override string ToString()
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine($"Water Monument: {this.Name}, Water Affinity: {this.WaterAffinity}");
		return sb.ToString().Trim();
	}

	public override int Affinity()
	{
		return this.WaterAffinity;
	}
}

