using System.Text;

public class FireMonument : Monument
{
	private int fireAffinity;

	public FireMonument(string name,int fireAffinity) : base(name)
	{
		this.FireAffinity = fireAffinity;
	}

	public int FireAffinity
	{
		get => fireAffinity;
		private set => fireAffinity = value;
	}

	public override string ToString()
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine($"Fire Monument: {this.Name}, Fire Affinity: {this.FireAffinity}");
		return sb.ToString().Trim();
	}

	public override int Affinity()
	{
		return this.FireAffinity;
	}
}

