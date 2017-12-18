using System.Collections.Generic;
using System.Linq;

namespace FastFood.DataProcessor.Dto.Export
{
    public class EmployeeDto
    {
		public string Name { get; set; }

		public ICollection<OrderDto> Orders { get; set; }=new List<OrderDto>();

		public decimal TotalMade
		{
			get { return this.Orders.Sum(i => i.TotalPrice); }
		}

	}
}
