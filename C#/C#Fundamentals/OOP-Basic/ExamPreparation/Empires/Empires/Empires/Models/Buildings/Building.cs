public abstract class Building
{
	private Resource resource;
	private int resourceBuildCounter;
	private int unitBuildCounter;
	private UnitFactory unitFactory;
	private int totalCount;

	public Building()
	{
		this.unitFactory = new UnitFactory();
	}

	public Resource Resource
	{
		get { return this.resource; }
		protected set { this.resource = value; }
	}

	public int ResourceBuldCounter
	{
		get { return this.resourceBuildCounter; }
		protected set { this.resourceBuildCounter = value; }
	}

	public int UnitBuildCounter
	{
		get { return this.unitBuildCounter; }
		protected set { this.unitBuildCounter = value; }
	}

	public UnitFactory UnitFactory
	{
		get { return this.unitFactory; }
	}

	public int TotalCount
	{
		get { return this.totalCount; }
		protected set { this.totalCount = value; }
	}
	public virtual void Turn()
	{
		
	}
}

