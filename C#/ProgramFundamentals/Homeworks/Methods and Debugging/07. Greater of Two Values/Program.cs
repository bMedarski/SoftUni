using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Greater_of_Two_Values
{
    class Program
    {
        static void Main(string[] args)
        {

            string type = Console.ReadLine();

            if (type=="int")
            {
                int a = int.Parse(Console.ReadLine());
                int b = int.Parse(Console.ReadLine());
                GetMaxInt(a,b);
            }
            else if (type == "char")
            {
                char a = char.Parse(Console.ReadLine());
                char b = char.Parse(Console.ReadLine());
                GetMaxChar(a,b);
            }
            else if (type == "string")
            {
                string a = Console.ReadLine();
                string b = Console.ReadLine();
                GetMaxString(a,b);
            }
        }
        static void GetMaxInt(int a,int b)
        {
            if (a>=b)
            {
                Console.WriteLine(a);
            }else
            {
                Console.WriteLine(b);
            }
        }
        static void GetMaxChar(char a, char b)
        {
            if (a >= b)
            {
                Console.WriteLine(a);
            }
            else
            {
                Console.WriteLine(b);
            }
        }
        static void GetMaxString(string a, string b)
        {
            if (String.Compare(a,b)==1)
            {
                Console.WriteLine(a);
            }
            else
            {
                Console.WriteLine(b);
            }
        }
    }
}
