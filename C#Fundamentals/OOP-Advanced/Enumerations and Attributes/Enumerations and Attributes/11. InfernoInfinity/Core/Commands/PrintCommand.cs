using System.Collections.Generic;
using System.Linq;

public class PrintCommand : ICommand
{
	private IWeaponsFactory weaponsFactory;
	private IList<string> args;
	private IWriter writer;

	public PrintCommand(IWeaponsFactory weaponsFactory, IList<string> args,IWriter writer)
	{
		this.weaponsFactory = weaponsFactory;
		this.args = new List<string>(args);
		this.writer = writer;
	}
	public void Execute()
	{
		var weapon = this.weaponsFactory.CreatedWeapons.First(w => w.Name == this.args[0]);
		this.writer.Writer(weapon.ToString());
	}
}

