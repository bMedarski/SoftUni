using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem01_VegetableMarket
{
    class Program
    {
        static void Main(string[] args)
        {

            double priceVegedoubles = double.Parse(Console.ReadLine());
            double priceFruits = double.Parse(Console.ReadLine());
            int weightVegedouble = int.Parse(Console.ReadLine());
            int weightFruits = int.Parse(Console.ReadLine());

            double result = ((priceVegedoubles * weightVegedouble) + (priceFruits*weightFruits)) / 1.94;
            Console.WriteLine(result);

        }
    }
}
