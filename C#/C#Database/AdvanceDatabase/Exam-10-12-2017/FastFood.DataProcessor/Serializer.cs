using System;
using System.IO;
using System.Linq;
using System.Text;
using FastFood.Data;
using FastFood.DataProcessor.Dto.Export;
using FastFood.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace FastFood.DataProcessor
{
	public class Serializer
	{
		public static string ExportOrdersByEmployee(FastFoodDbContext context, string employeeName, string orderType)
		{
			var sb = new StringBuilder();
			var type = Enum.Parse<OrderType>(orderType);

			var employeeee = context.Employees
				.Include(e=>e.Orders)
				.ThenInclude(o=>o.OrderItems)
				.Where(e=>e.Name==employeeName).ToArray();

			EmployeeDto emp = new EmployeeDto();
			emp.Name = employeeee[0].Name;

			foreach (var order in employeeee[0].Orders.Where(o=>o.Type==type))
			{
				var orderDto = new OrderDto()
				{
					Customer = order.Customer
				};

				foreach (var item in order.OrderItems)
				{
					var itemDto = new ItemDto()
					{
						Name = item.Item.Name,
						Price = item.Item.Price,
						Quantity = item.Quantity
					};
					orderDto.Items.Add(itemDto);
				}
				
				emp.Orders.Add(orderDto);
			}
			var result = emp.Orders.OrderByDescending(o => o.TotalPrice).ThenBy(o => o.Items.Count);
			//.Select(e=> new 
			//{
			//	Name = e.Name,
			//	EmployeeId = e.Id,
			//	Orders = context.Orders
			//		.Where(o=>o.Type==type&& o.EmployeeId==e.Id)
			//		.Select(o=> new
			//		{
			//			Customer = o.Customer,
			//			Items = context.OrderItems.Where(oi=>oi.ItemId==o.Id)
			//				.Select(oi=> new
			//				{
			//					Name = context.Items.Where(i=>i.Id== oi.ItemId).Select(i=>i.Name),
			//					Price = context.Items.Where(i => i.Id == oi.ItemId).Select(i => i.Price),
			//				}).ToArray()
			//		}).ToArray()
			//}).ToArray();

			var json = JsonConvert.SerializeObject(result, Formatting.Indented);
			return json;
		}

		public static string ExportCategoryStatistics(FastFoodDbContext context, string categoriesString)
		{
			throw new NotImplementedException();
		}
	}
}