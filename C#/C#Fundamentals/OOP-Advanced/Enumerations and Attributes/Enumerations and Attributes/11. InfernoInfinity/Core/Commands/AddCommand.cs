using System;
using System.Collections.Generic;
using System.Linq;

public class AddCommand : ICommand
{

	private IWeaponsFactory weaponsFactory;
	private IList<string> args;

	public AddCommand(IWeaponsFactory weaponsFactory, IList<string> args)
	{
		this.weaponsFactory = weaponsFactory;
		this.args = new List<string>(args);
	}

	public void Execute()
	{
		var weapon = this.weaponsFactory.CreatedWeapons.First(w => w.Name == this.args[0]);
		var gemArgs = this.args[2].Split(' ');
		var socketPosition = int.Parse(this.args[1]);
		Enum.TryParse(gemArgs[0], out GemSize gemSize);
		Enum.TryParse(gemArgs[1], out GemType gemType);
		var gem = new Gem(gemSize,gemType);
		if (socketPosition>=0)
		{
			weapon.Gems[socketPosition] = gem;
			weapon.Calculate();
		}
		
	}
}

