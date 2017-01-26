using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Shop_Keeper
{
    class Program
    {
        static void Main(string[] args)
        {
           


            List<int> items = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> orders = Console.ReadLine().Split(' ').Select(int.Parse).ToList();






            //List<int> data = new List<int>() { 1, 2, 3, 4, 1, 5, 2, 7, 8 };
            //string original = string.Join(", ", data);


            //int[] indexes = Enumerable.Range(0, data.Count).Where(i => data[i] == 1).ToArray();
            //Array.ForEach(indexes, i => data[i] = 0);

            //Console.WriteLine(string.Format("Original: {0}\n      New: {1}", original, string.Join(", ", data)));

            //var firstNotSecond = list1.Except(list2).ToList();
            //var secondNotFirst = list2.Except(list1).ToList();

            var distinctList = orders.Except(items).ToList(); //

            var ordersByCount = distinctList.GroupBy(item => item)
                                .OrderBy(x => x.Count())
                                .Select(x => x.First())
                                .ToList();
                                

            //Console.WriteLine(string.Format("{0} -> ", groups.Count(),groups));
            Console.WriteLine(string.Join(",", ordersByCount[0]));

            //foreach (var group in groups)
            //{
            //    Console.WriteLine(string.Join(",", groups[0]));
            //    //Console.WriteLine(string.Format("{0} -> ", groups));
            //}
            //var count = orders
            //    .GroupBy(e => e)
            //    .Where(e => e.Count() > 0)
            //    .Select(e => e);
            //Console.WriteLine(string.Join(", ", count));
            //var groups = orders.Where(n[i]=>n[i]).GroupBy(item => item);
            //orders.Select((order, index) => new { Order = order, Index = index })
            //    .Select(x => x.Index > x.i)
            //    .ToArray();
            //Console.WriteLine(string.Join(", ", orders));

            //foreach (var group in groups)
            //{
            //    Console.WriteLine(string.Format("{0} occurences of {1}", group.Count(), group.Key));
            //}

            int counterChanges = -1;

            if (items.Contains(orders[0]))
            {
                for (int i = 0; i < orders.Count; i++)
                {
                    

                        var list = orders.Select((order, index) => new { index, order })
                        .Where(t => t.index > i)
                        .Select(x => x.order)
                        .OrderBy(x => x)
                        .ToList();
                        //Console.WriteLine(string.Join(", ", list));
                        counterChanges++;
                    }
              
            }
           
        }
    }
}
