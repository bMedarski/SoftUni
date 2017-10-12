using System.Collections.Generic;
using System.Linq;

public class RemoveCommand:ICommand
{
	private IWeaponsFactory weaponsFactory;
	private IList<string> args;

	public RemoveCommand(IWeaponsFactory weaponsFactory, IList<string> args)
	{
		this.weaponsFactory = weaponsFactory;
		this.args = new List<string>(args);
	}
	public void Execute()
	{
		var weapon = this.weaponsFactory.CreatedWeapons.First(w => w.Name == this.args[0]);
	}
}

