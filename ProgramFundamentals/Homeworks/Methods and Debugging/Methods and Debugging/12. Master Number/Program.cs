using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Master_Number
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            for (int i =1; i<=n; i++)
            {
                if (IsPalindrome(i.ToString()) && SumOfDigits(i) && ContainsEvenNumber(i))
                {
                    Console.WriteLine(i);
                }
            }
            

        }
        public static bool IsPalindrome(string value)
        {
            int min = 0;
            int max = value.Length - 1;
            while (true)
            {
                if (min > max)
                {
                    return true;
                }
                char a = value[min];
                char b = value[max];
                if (char.ToLower(a) != char.ToLower(b))
                {
                    return false;
                }
                min++;
                max--;
            }
        }

        static bool SumOfDigits(int num)
        {
            long sum = 0;
            int currentDigit;
            while (num > 0)
            {
                currentDigit = num % 10;
                sum += currentDigit;
                num = num / 10;
            }
            if (sum%7==0)
            {
                return true;
            }else
            {
                return false;
            }
        }
        static bool ContainsEvenNumber(int num)
        {
            int currentDigit;
            while (num > 0)
            {
                currentDigit = num % 10;
                if (currentDigit % 2 == 0)
                {
                    return true;
                }
                num = num / 10;
            }          
                return false;         
        }
    }
}
