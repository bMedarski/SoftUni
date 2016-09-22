using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Primes_in_Given_Range
{
    class Program
    {
        static void Main(string[] args)
        {

            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            //CalculatePrimesInRange(a,b);
            string numbers = String.Join(", ", CalculatePrimesInRange(a, b).ToArray());

            Console.WriteLine(numbers);
        }
        public static bool IsPrime(int number)
        {
            if (number == 1 || number == 0) return false;
            if (number == 2) return true;

            int half = number / 2;
            for (int i = 2; i <= half; ++i)
            {
                if (number % i == 0) return false;
            }

            return true;
        }

        private static List<int> CalculatePrimesInRange(int startNumber, int endNumber)
        {
            List<int> numbers = new List<int>();

            for (int i = startNumber; i <= endNumber; i++)
            {
                if (IsPrime(i))
                {
                    numbers.Add(i);
                }
            }

            return numbers;
        }
    }
}
