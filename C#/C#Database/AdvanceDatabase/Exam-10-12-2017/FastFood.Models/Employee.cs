using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FastFood.Models
{
	public class Employee
	{
		public Employee()
		{
			this.Orders = new List<Order>();
		}
		public int Id { get; set; }

		[Required]
		[MinLength(3)]
		[MaxLength(30)]
		public string Name { get; set; }

		[Required]
		[Range(14, 80)]	//Possible (14-80)
		public int Age { get; set; }


		//Possible need for Required
		public int PositionId { get; set; }
		[Required]
		public Position Position { get; set; }

		public ICollection<Order> Orders { get; set; }
	}
}