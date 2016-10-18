using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Sales_Report
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, double> saleReport = new SortedDictionary<string, double>();
            int n = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < n; i++)
            {
                string[] sales = Console.ReadLine().Split().ToArray();
                Sale sale = getSale(sales);
                addToReport(saleReport,sale);
            }
            foreach (var item in saleReport)
            {
                Console.WriteLine($"{item.Key} -> {item.Value:F2}");
            }

        }

        private static void addToReport(SortedDictionary<string, double> saleReport, Sale sale)
        {
            if (!saleReport.ContainsKey(sale.town))
            {
                saleReport.Add(sale.town,sale.price*sale.quantity);
            }
            else
            {
                saleReport[sale.town] += sale.price * sale.quantity;
            }
        }

        private static Sale getSale(string[] sale)
        {
            Sale currentSale = new Sale();
            currentSale.town = sale[0];
            currentSale.product = sale[1];
            currentSale.price = double.Parse(sale[2]);
            currentSale.quantity = double.Parse(sale[3]);
            return currentSale;
        }
    }
    class Sale
    {
        public string town { get; set; }
        public string product { get; set; }
        public double price { get; set; }
        public double quantity { get; set; }
    }
}
