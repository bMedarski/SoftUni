using Microsoft.AspNetCore.Identity;

namespace Models
{
	using System.Collections.Generic;

	public class ChushkaUser:IdentityUser
	{
		public string FullName { get; set; }
	}
}
