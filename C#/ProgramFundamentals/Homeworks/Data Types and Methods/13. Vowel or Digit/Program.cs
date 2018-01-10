using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.Vowel_or_Digit
{
    class Program
    {
        static void Main(string[] args)
        {

            char symbol = char.Parse(Console.ReadLine());


            if (symbol == 'a' || symbol == 'o' || symbol == 'u' || symbol == 'i' || symbol == 'e')
            {
                Console.WriteLine("vowel");
            }else if (symbol == '1' || symbol == '2' || symbol == '3' || symbol == '5' || symbol == '4'|| symbol == '6' || symbol == '7' || symbol == '8' || symbol == '9' || symbol == '0')
            {
                Console.WriteLine("digit");
            }
            else
            {
                Console.WriteLine("other");
            }
        }
    }
}
