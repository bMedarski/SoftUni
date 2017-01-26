using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Shop_Keeper
{
    class Program
    {
        static void Main(string[] args)
        {            
                List<int> items = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
                List<int> orders = Console.ReadLine().Split(' ').Select(int.Parse).ToList();          
            int counterChanges = 0;
            //var leftOfOrders = new List<int>();
            var toReplace=0;
            var index = 0;
            var i = 0;
            //orders.Select(x => checkedFor(x,items,orders));
            if (items.Contains(orders[0]))
            {
                //for (int i = 1; i < orders.Count; i++)
                //{
                foreach (var item in orders)
                {

                    if (!items.Contains(item))  //Ако поръчката не се съдържа на рафта
                    {

                        //leftOfOrders = orders.Skip(i).Take(orders.Count - i).ToList();
                        toReplace = items.Except(orders.Skip(i).Take(orders.Count - i)).FirstOrDefault();

                        if (toReplace==0)
                        {
                            items[0] = orders[i];
                        }
                        else
                        {
                          index = items.IndexOf(toReplace);
                          items[index] = orders[i];
                        }
                        
                        //Console.WriteLine(items[index]);
                        //Console.WriteLine(string.Join(", ", leftOfOrders));
                        //Console.WriteLine(string.Join(", ", toReplace));
                        counterChanges++;
                    }
                    i++;
                }
                Console.WriteLine(counterChanges);
            }
            if (!items.Contains(orders[0]))
            {           
                Console.WriteLine("impossible");
            }
        }
    }
  }
