using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using FastFood.Data;
using FastFood.DataProcessor.Dto.Import;
using FastFood.Models;
using FastFood.Models.Enums;
using Microsoft.Extensions.Logging.Abstractions;
using Newtonsoft.Json;

namespace FastFood.DataProcessor
{
	public static class Deserializer
	{
		private const string FailureMessage = "Invalid data format.";
		private const string SuccessMessage = "Record {0} successfully imported.";

		public static string ImportEmployees(FastFoodDbContext context, string jsonString)
		{
			EmployeeDto[] employeesDto = JsonConvert.DeserializeObject<EmployeeDto[]>(jsonString);
			var sb = new StringBuilder();

			var validEmployees = new List<Employee>();

			var positions = new HashSet<Position>();

			foreach (var employeeDto in employeesDto)
			{
				int? positionId = context.Positions.SingleOrDefault(p => p.Name == employeeDto.Position)?.Id;
				bool isDuplicated = positions.Any(p => p.Name == employeeDto.Position);

				if (!IsValid(employeeDto))
				{
					continue;
				}
				if (isDuplicated)
				{
					continue;
				}
				if (positionId == null)
				{
					var position = new Position()
					{
						Name = employeeDto.Position
					};
					positions.Add(position);
				}
			}
			context.AddRange(positions);
			context.SaveChanges();

			foreach (var employeeDto in employeesDto)
			{
				if (!IsValid(employeeDto))
				{
					sb.AppendLine(FailureMessage);
					continue;
				}
				var employee = new Employee()
				{
					Name = employeeDto.Name,
					Age = employeeDto.Age,
					Position = positions.FirstOrDefault(p => p.Name == employeeDto.Position)
				};
				validEmployees.Add(employee);
				sb.AppendLine(String.Format(SuccessMessage, employee.Name));
			}
			context.AddRange(validEmployees);
			context.SaveChanges();

			var result = sb.ToString().Trim();
			return result;
		}

		public static string ImportItems(FastFoodDbContext context, string jsonString)
		{
			var sb = new StringBuilder();
			ItemDto[] itemsDtos = JsonConvert.DeserializeObject<ItemDto[]>(jsonString);

			var items = new List<Item>();
			var categories = new HashSet<Category>();

			foreach (var itemsDto in itemsDtos)
			{
				int? categoryId = context.Categories.SingleOrDefault(p => p.Name == itemsDto.Category)?.Id;
				bool isDuplicated = categories.Any(p => p.Name == itemsDto.Category);

				if (!IsValid(itemsDto))
				{
					continue;
				}
				if (isDuplicated)
				{
					continue;
				}
				if (categoryId == null)
				{
					var category = new Category()
					{
						Name = itemsDto.Category
					};
					categories.Add(category);
				}
			}
			context.AddRange(categories);
			context.SaveChanges();

			foreach (var itemsDto in itemsDtos)
			{
				if (!IsValid(itemsDto))
				{
					sb.AppendLine(FailureMessage);
					continue;
				}

				var isExist = items.Any(i => i.Name == itemsDto.Name);

				if (isExist)
				{
					sb.AppendLine(FailureMessage);
					continue;
				}

				var item = new Item()
				{
					Name = itemsDto.Name,
					Price = itemsDto.Price,
					Category = categories.FirstOrDefault(p => p.Name == itemsDto.Category)
				};
				items.Add(item);
				sb.AppendLine(String.Format(SuccessMessage, item.Name));
			}
			context.AddRange(items);
			context.SaveChanges();
			var result = sb.ToString().Trim();
			return result;
		}

		public static string ImportOrders(FastFoodDbContext context, string xmlString)
		{

			var sb = new StringBuilder();

			var serializer = new XmlSerializer(typeof(XmlOrderDtop[]), new XmlRootAttribute("Orders"));
			var deserializedOrders = (XmlOrderDtop[])serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));

			var validOders = new List<Order>();
			foreach (var order in deserializedOrders)
			{
				string employee = order.Employee;
				if (String.IsNullOrWhiteSpace(employee))
				{
					sb.AppendLine(FailureMessage);
					continue;
				}


				string customer = order.Customer;
				DateTime date = DateTime.ParseExact(order.Datetime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
				var type = Enum.Parse<OrderType>(order.Type);


				foreach (var itemOrderDto in order.Items)
				{
					if (itemOrderDto.Quantity < 0)
					{
						sb.AppendLine(FailureMessage);
						continue;
					}
				}
				var employeeId = context.Employees.Where(e => e.Name == employee).ToArray();

				if (employeeId.Length == 0)
				{
					sb.AppendLine(FailureMessage);
					continue;
				}

				sb.AppendLine(String.Format($"Order for {customer} on {date.ToString("dd/MM/yyyy HH:mm")} added", CultureInfo.InvariantCulture));
			}
			//var sb = new StringBuilder();
			////var serializer = new XmlSerializer(typeof(OrdersDto[]), new XmlRootAttribute("Orders"));
			//var xDoc = XDocument.Parse(xmlString);
			//var elements = xDoc.Root.Elements();
			////var deserializedOrders = (OrdersDto[])serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));

			//var validOders = new List<Order>();

			//foreach (var element in elements)
			//{
			//	string employee = element.Element("Employee")?.Value;
			//	string customer = element.Element("Customer")?.Value;
			//	string datetime = element.Element("DateTime")?.Value;
			//	string type = element.Element("Type")?.Value;
			//	//Console.WriteLine(employee);
			//	string quantityString = element.Element("Items")?.Element("Item")?.Element("Quantity")?.Value;

			//	var items = element.Element("Items").Element("Item");

			//	foreach (var item in items)
			//	{
			//		Console.WriteLine(item);
			//		Console.WriteLine();
			//	}
			//	//Console.WriteLine(quantityString);
			//	if (quantityString == null)
			//	{
			//		sb.AppendLine(FailureMessage);
			//		continue;
			//	}
			//	int quantity = int.Parse(quantityString);

			//	if (quantity <0)
			//	{
			//		sb.AppendLine(FailureMessage);
			//		continue;
			//	}

			//	if (String.IsNullOrWhiteSpace(employee)
			//		//||
			//	 //   String.IsNullOrWhiteSpace(customer) ||
			//	 //   String.IsNullOrWhiteSpace(datetime) ||
			//	 //   String.IsNullOrWhiteSpace(type)
			//		)
			//	{
			//		sb.AppendLine(FailureMessage);
			//		continue;
			//	}
			//	DateTime date = DateTime.ParseExact(datetime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
			//	var employeeId = context.Employees.Where(e => e.Name == employee).ToArray();

			//	 if (employeeId.Length==0)
			//	{
			//		sb.AppendLine(FailureMessage);
			//		continue;
			//	}

			//	Console.WriteLine();

			//	var order = new Order()
			//	{
			//		Customer = customer,
			//		Employee = employeeId[0],
			//		DateTime = date,
			//		Type = Enum.Parse<OrderType>(type)
			//	};

			//sb.AppendLine(String.Format($"Order for {customer} on {date.ToString("dd/MM/yyyy HH:mm")} added",CultureInfo.InvariantCulture));
			//		//13:22 Order for Garry on 21/08/2017 added
			//	validOders.Add(order);

			//}
			context.Orders.AddRange(validOders);
			context.SaveChanges();


			var result = sb.ToString().Trim();
			return result;
		}

		private static bool IsValid(object obj)
		{
			var validationContext = new ValidationContext(obj);
			var validationResults = new List<ValidationResult>();

			var isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);
			return isValid;
		}
	}
}