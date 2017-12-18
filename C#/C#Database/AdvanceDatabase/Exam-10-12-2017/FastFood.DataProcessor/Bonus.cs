using System;
using System.Linq;
using FastFood.Data;

namespace FastFood.DataProcessor
{
    public static class Bonus
    {
	    public static string UpdatePrice(FastFoodDbContext context, string itemName, decimal newPrice)
	    {
		    var itemId = context.Items.SingleOrDefault(i => i.Name == itemName)?.Id;

		    if (itemId == null)
		    {
			    return $"Item {itemName} not found!";
		    }
		    else
		    {
			    decimal currentPrice = 0;
			    var items = context.Items.Where(i => i.Name == itemName).ToArray();
			    foreach (var item in items)
			    {
				    currentPrice = item.Price;
				    item.Price = newPrice;
					
			    }
			    context.SaveChanges();
			    return $"{itemName} Price updated from ${currentPrice:F2} to ${newPrice:F2}";
		    }
	    }
    }
}
