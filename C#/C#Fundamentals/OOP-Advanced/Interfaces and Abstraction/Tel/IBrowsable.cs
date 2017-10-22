using System.Collections.Generic;
public interface IBrowsable
{
	List<string> WebSites { get; set; }

	string Browse();
}