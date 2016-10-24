using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.AndreyAndBilliard
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            Dictionary<string, double> menu = new Dictionary<string, double>();
            List<Customer> customers = new List<Customer>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split('-').ToArray();
                menu[input[0]] = double.Parse(input[1]);
            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end of clients")
                {
                    break;
                }
                string[] splitInput = input.Split(new char[] {'-',',' }).ToArray();


                if (menu.ContainsKey(splitInput[1]))
                {
                    Customer newCustomer = new Customer();

                    newCustomer.Name = splitInput[0];
                    newCustomer.Order.Add(splitInput[1], int.Parse(splitInput[2]));
                    newCustomer.OrderCost = menu[splitInput[1]] * double.Parse(splitInput[2]);
                    customers.Add(newCustomer);
                }
            }


            // foreach (var item in customers.OrderBy(x=>x.Name))
            {
            //    Console.WriteLine(item.Name);
            }
        }
        
    }
    class Customer
    {
        public string Name { get; set; }
        public Dictionary<string, int> Order { get; set; }
        public double OrderCost { get; set; }
    }
}
