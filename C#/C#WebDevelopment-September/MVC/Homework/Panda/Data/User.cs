namespace Panda.Data
{
	using System.Collections.Generic;
	using Microsoft.AspNetCore.Identity;

	public class User:IdentityUser
	{
		public ICollection<Package> Packages { get; set; }
		public ICollection<Receipt> Receipts { get; set; }
	}
}
