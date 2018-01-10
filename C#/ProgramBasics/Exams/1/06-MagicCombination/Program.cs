using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_MagicCombination
{
    class Program
    {
        static void Main(string[] args)
        {

            int magicNum = int.Parse(Console.ReadLine());

            for (int i = 100000; i<=999999; i++)
            {
                int first = i / 100000;
                int second = i % 100000 / 10000;
                int third = i % 100000 % 10000 / 1000;
                int forth = i % 100000 % 10000 % 1000 / 100;
                int fifth = i % 100000 % 10000 % 1000 % 100 / 10;
                int sixth = i % 10;

                if (first*second*third*forth*fifth*sixth==magicNum)
                {
                    Console.Write("{0} ",i);
                }
            }
        }
    }
}
