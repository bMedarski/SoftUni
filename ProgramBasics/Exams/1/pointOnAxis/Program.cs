using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pointOnAxis
{
    class Program
    {
        static void Main(string[] args)
        {

            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int point = int.Parse(Console.ReadLine());

            var position = "";
            if (((point>first)&&(point>second))||
                ((point<first)&&(point<second)))
            {
                position = "out";
            }
            else
            {
                position = "in";
            }
            Console.WriteLine(position);

            int a = first - point;
            int b = second - point;
            if (a < 0)
            {
                a *= -1;
            }
            if (b<0)
            {
                b *= -1;
            }
            if (a<b)
            {
                Console.WriteLine(a);
            }else
            {
                Console.WriteLine(b);
            }

        }
    }
}
