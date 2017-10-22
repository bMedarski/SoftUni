public class BuildingFactory
{

	public Building BuildArchery()
	{
		return new Archery();
	}

	public Building BuildBarracks()
	{
		return new Barracks();
	}

}

