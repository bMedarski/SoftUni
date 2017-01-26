using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Halloween_Pumpkin
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());


            //for (int i = 0; i < 1; i++)
            //{
                for (int j = 0; j < 2*n+1; j++)
                {
                    if (j < n-1||j>n+1)
                    {
                        Console.Write('.');
                    }
                    if (j==n)
                    {
                        Console.Write("_/_");
                    }
                }                
            
                Console.WriteLine();
            for (int j = 0; j < 2 * n + 1; j++)
            {
                if (j==0)
                {
                    Console.Write('/');
                }
                if (j==2 * n)
                {
                    Console.Write('\\');
                }
                if ((j < n-1&&j!=0) || (j > n + 1&&j< 2 * n))
                {
                    Console.Write('.');
                }
                if (j == n)
                {
                    Console.Write("^,^");
                }
            }
            Console.WriteLine();
            if (n>3)
            {
                for (int i = 0; i < n-3; i++)
                {

                    for (int j = 0; j < 2 * n + 1; j++)
                    {
                        if (j == 0)
                        {
                            Console.Write('|');
                        }else if(j == 2 * n)
                        {
                            Console.Write('|');
                        }
                        else
                        {
                            Console.Write(".");
                        }
                       
                    }
                    Console.WriteLine();
                }
            }
            for (int j = 0; j < 2 * n + 1; j++)
            {
                if (j == 0)
                {
                    Console.Write('\\');
                }
                if (j == 2 * n)
                {
                    Console.Write('/');
                }
                if ((j < n-1 && j != 0) || (j > n + 1 && j < 2 * n))
                {
                    Console.Write('.');
                }
                if (j == n)
                {
                    Console.Write("\\_/");
                }
            }
        }
    }
}
