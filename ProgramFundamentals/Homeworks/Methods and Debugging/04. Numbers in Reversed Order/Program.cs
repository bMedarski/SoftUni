using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Numbers_in_Reversed_Order
{
    class Program
    {
        static void Main(string[] args)
        {


            double x = double.Parse(Console.ReadLine());

            string a = x.ToString();

            PrintReverse(a);
        }
        static void PrintReverse(string a)
        {
            //string x  = (string)a.Reverse();
            Console.WriteLine(StringHelper.ReverseString(a));
        }
        static class StringHelper
        {
            /// <summary>
            /// Receives string and returns the string with its letters reversed.
            /// </summary>
            public static string ReverseString(string s)
            {
                char[] arr = s.ToCharArray();
                Array.Reverse(arr);
                return new string(arr);
            }
        }

    }
}
