using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Money
    {
        static void Main(string[] args)
        {

            int bitcoins = int.Parse(Console.ReadLine());
            double iuans = double.Parse(Console.ReadLine());
            double commision = double.Parse(Console.ReadLine());

            double levs = (bitcoins * 1168) + (iuans * 0.15) * 1.76;
            double euros = levs / 1.95;
            euros = euros - euros * (commision/100);
            Console.WriteLine(euros);
        }
    }
}
