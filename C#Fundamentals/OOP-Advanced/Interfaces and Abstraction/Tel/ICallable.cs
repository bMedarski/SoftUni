using System.Collections.Generic;
public interface ICallable
{
	List<string> Numbers { get; set; }

	string Call();
}
