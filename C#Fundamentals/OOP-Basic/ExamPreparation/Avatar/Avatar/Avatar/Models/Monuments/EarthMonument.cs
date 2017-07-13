using System.Text;

public class EarthMonument : Monument
{
	private int earthAffinity;

	public EarthMonument(string name,int earthAffinity) : base(name)
	{
		this.EarthAffinity = earthAffinity;
	}

	public int EarthAffinity
	{
		get => earthAffinity;
		private set => earthAffinity = value;
	}

	public override string ToString()
	{
		StringBuilder sb = new StringBuilder();
		sb.AppendLine($"Earth Monument: {this.Name}, Earth Affinity: {this.EarthAffinity}");
		return sb.ToString().Trim();
	}

	public override int Affinity()
	{
		return this.EarthAffinity;
	}
}

