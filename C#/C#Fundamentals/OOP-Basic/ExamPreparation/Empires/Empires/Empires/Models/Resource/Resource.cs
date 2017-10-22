public class Resource
{
	private ResourceType type;
	private int quantity;

	public Resource(ResourceType type, int quantity)
	{
		this.Type = type;
		this.Quantity = quantity;
	}

	public ResourceType Type
	{
		get { return this.type; }
		private set { this.type = value; }
	}

	public int Quantity
	{
		get { return this.quantity; }
		set { this.quantity = value; }
	}
}

