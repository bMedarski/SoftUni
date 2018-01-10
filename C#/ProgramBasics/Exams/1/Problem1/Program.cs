using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    class Program
    {
        static void Main(string[] args)
        {

            int workingDays = int.Parse(Console.ReadLine());
            double madeMoney = double.Parse(Console.ReadLine());
            double exchangeRate = double.Parse(Console.ReadLine());

            double madeMoneyMonth = workingDays * madeMoney;
            double bonus = madeMoneyMonth * 2.5;
            double madeMoneyYear = (madeMoneyMonth * 12 + bonus)*0.75;
            madeMoneyYear = madeMoneyYear * exchangeRate;
            madeMoney = madeMoneyYear / 365;
            Console.WriteLine("{0:F2}", madeMoney);

        }
    }
}
