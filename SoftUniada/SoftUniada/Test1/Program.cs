using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    class Program
    {
        static void Main(string[] args)
        {

            int counter = 1;
            List<int> TestList = new List<int>() { 1,2,3,4,5,6,1,2,5,6,10};

            var test = TestList.ElementAtOrDefault(12);



            //foreach (var item in test)
            //{
            //    Console.WriteLine($"{string.Join(",", item)}->{counter}");
            //    counter++;
            //}
            //Console.WriteLine(test);
            Console.WriteLine(string.Join(",", test));
        }
    }
}
