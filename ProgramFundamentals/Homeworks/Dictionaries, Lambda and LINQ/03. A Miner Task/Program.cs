using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {

            string resource = "";
            long quantity=0;
            long quantitySum = 0;
            int count = 1;
            Dictionary<string, long> items = new Dictionary<string, long>();

            while (resource!="stop")
            {
                if (count%2!=0)
                {
                    resource = Console.ReadLine();
                }
                else
                {
                    quantity = long.Parse(Console.ReadLine());

                    if (items.ContainsKey(resource))
                    {
                        quantitySum = quantity + items[resource];
                        items[resource] = quantitySum;
                    }
                    else
                    {
                        items[resource] = quantity;
                    }                   
                }
                count++;
            }
            foreach(var i in items)
            {
                Console.WriteLine($"{i.Key} -> {i.Value}");
            }
        }
    }
}
