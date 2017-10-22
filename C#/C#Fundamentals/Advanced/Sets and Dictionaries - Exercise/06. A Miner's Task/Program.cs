using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.A_Miner_s_Task
{
    class Program
    {
        static void Main(string[] args)
        {

            var resources = new Dictionary<string, int>();

            while (true)
            {
                var resoure = Console.ReadLine();
                if (resoure == "stop")
                {
                    break;
                }
                var quantity = int.Parse(Console.ReadLine());

                if (resources.ContainsKey(resoure))
                {
                    resources[resoure] += quantity;
                }
                else
                {
                    resources.Add(resoure, quantity);
                }

            }
            foreach (var resource in resources)
            {
                Console.WriteLine($"{resource.Key} -> {resource.Value}");
            }
        }
    }
}