public class Gem:IGem
{
	private GemSize size;
	private GemType type;

	public Gem(GemSize size, GemType type)
	{
		this.size = size;
		this.type = type;
	}

	public GemSize Size => this.size;
	public GemType Type => this.type;
}

