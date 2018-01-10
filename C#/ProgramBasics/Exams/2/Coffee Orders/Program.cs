using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee_Orders
{
    class Program
    {
        static void Main(string[] args)
        {

            long n = int.Parse(Console.ReadLine());
            decimal priceAll = 0;
            decimal priceOrder = 0;
            long add = 0;
            long days = 0;

            for (int i = 0; i<n; i++)
            {
                decimal price = decimal.Parse(Console.ReadLine());
                long[] orderDate = Console.ReadLine().Split('/').Select(long.Parse).ToArray();
                long capsuleCount = int.Parse(Console.ReadLine());

                if (orderDate[2]%4==0)
                {
                    if (orderDate[2] % 100== 0)
                    {
                        add = 0;
                    }else if((orderDate[2] % 100 == 0)&& (orderDate[2] % 400 == 0))
                    {
                        add = 1;
                    }
                    else
                    {
                        add = 1;
                    }
                }

                if (orderDate[1]==1||orderDate[1]==3||orderDate[1]==5|| orderDate[1] ==7|| orderDate[1] ==8|| orderDate[1] ==10|| orderDate[1] ==12)
                {
                    days = 31;
                }else if (orderDate[1] ==2)
                {
                    days = 28 + add;
                }
                else
                {
                    days = 30;
                }
                priceOrder = days * capsuleCount * price;
                Console.WriteLine("The price for the coffee is: ${0:F2}",Math.Round(priceOrder,2));
                priceAll += priceOrder;

            }
            Console.WriteLine("Total: ${0:F2}", Math.Round(priceAll,2));

        }
    }
}
