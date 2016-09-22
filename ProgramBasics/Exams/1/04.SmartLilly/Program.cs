using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SmartLilly
{
    class Program
    {
        static void Main(string[] args)
        {


            int age = int.Parse(Console.ReadLine());
            double washingMachine = double.Parse(Console.ReadLine());
            int toyPrice = int.Parse(Console.ReadLine());
            int i = 1;
            int countToys = 0;
            int count = 0;
            int money = 0;
            while (i <= age)
            {
                if (i % 2 == 0)
                {
                    count += 1;
                    money += (10 * count) - 1;
                }else
                {
                    countToys += 1;
                }
                i++;
            }
            money += countToys * toyPrice;
            if (washingMachine-money>0)
            {
                Console.WriteLine("No! {0:F2}",washingMachine-money);
            }
            else
            {
                Console.WriteLine("Yes! {0:F2}", (washingMachine - money)*-1);
            }
        }
    }
}
