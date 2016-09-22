using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Triples_of_Letters
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i<=n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    for (int l = 1; l <= n; l++)
                    {
                        PrintLether(i);
                        PrintLether(j);
                        PrintLether(l);
                        Console.WriteLine();
                    }
                }
            }




        }

        static void PrintLether(int n)
        {
            switch (n)
            {
                case 1:
                    Console.Write("a");
                    break;
                case 2:
                    Console.Write("b");
                    break;
                case 3:
                    Console.Write("c");
                    break;
                case 4:
                    Console.Write("d");
                    break;
                case 5:
                    Console.Write("e");
                    break;
                case 6:
                    Console.Write("f");
                    break;
                case 7:
                    Console.Write("g");
                    break;
                case 8:
                    Console.Write("h");
                    break;
                case 9:
                    Console.Write("i");
                    break;
                case 10:
                    Console.Write("j");
                    break;
                case 11:
                    Console.Write("k");
                    break;
                case 12:
                    Console.Write("l");
                    break;
                case 13:
                    Console.Write("m");
                    break;
                case 14:
                    Console.Write("n");
                    break;
                case 15:
                    Console.Write("o");
                    break;
                case 16:
                    Console.Write("p");
                    break;
                case 17:
                    Console.Write("q");
                    break;
                case 18:
                    Console.Write("r");
                    break;
                case 19:
                    Console.Write("s");
                    break;
                case 20:
                    Console.Write("t");
                    break;
                case 21:
                    Console.Write("u");
                    break;
                case 22:
                    Console.Write("v");
                    break;
                case 23:
                    Console.Write("w");
                    break;
                case 24:
                    Console.Write("x");
                    break;
                case 25:
                    Console.Write("y");
                    break;
                case 26:
                    Console.Write("z");
                    break;


            }
        }
    }
}