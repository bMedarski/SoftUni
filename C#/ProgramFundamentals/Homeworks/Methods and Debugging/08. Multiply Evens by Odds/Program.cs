using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Multiply_Evens_by_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            x = Math.Abs(x);
            Console.WriteLine(GetMultipleOfEvensAndOdds(x));

        }
        static int GetEvenNumbers(int num)
        {
            int sumEven = 0;
            while (num>0)
            {
                int currentNum = num % 10;
                if (currentNum%2==0)
                {
                    sumEven += currentNum;
                }
                num = num / 10;
            }

            return sumEven;
        }
        static int GetOddNumbers(int num)
        {
            int sumOdd = 0;
            while (num > 0)
            {
                int currentNum = num % 10;
                if (currentNum % 2 != 0)
                {
                    sumOdd += currentNum;
                }
                num = num / 10;
            }

            return sumOdd;
        }
        static int GetMultipleOfEvensAndOdds(int a)
        {

            int sumOdds = GetOddNumbers(a);
            int sumEvens = GetEvenNumbers(a);
            return sumEvens*sumOdds;
        }
    }
}
