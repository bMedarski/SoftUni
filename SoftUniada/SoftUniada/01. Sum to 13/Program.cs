using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Sum_to_13
{
    class Program
    {
        static void Main(string[] args)
        {

            long[] numbers = Console.ReadLine().Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
            long a = numbers[0];
            long b = numbers[1];
            long c = numbers[2];

            if (a+b+Math.Abs(c)==13)
            {
                Console.WriteLine("Yes");
            }else if(a  - b -c == 13)
            {
                Console.WriteLine("Yes");
            }
            else if (-a -b -c == 13)
            {
                Console.WriteLine("Yes");
            }else if (-a + b -c == 13)
            {
                Console.WriteLine("Yes");

            }
            else if (-a + b + c == 13)
            {
                Console.WriteLine("Yes");

            }
            else if (a  -b + c == 13)
            {
                Console.WriteLine("Yes");

            }
            else if (-a -b + c == 13)
            {
                Console.WriteLine("Yes");

            }
            else if (a + b + c == 13)
            {
                Console.WriteLine("Yes");

            }


            else
            {
                Console.WriteLine("No");
            }
            
        }
    }
}
