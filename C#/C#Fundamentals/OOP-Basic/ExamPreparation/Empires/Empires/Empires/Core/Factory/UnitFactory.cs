public class UnitFactory
{
	public Unit CreateArcher()
	{
		return new Archer();
	}

	public Unit CreateSwordsman()
	{
		return new Swordsman();
	}
}

