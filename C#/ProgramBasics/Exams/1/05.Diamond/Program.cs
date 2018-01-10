using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Diamond
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i<1; i+=1)
            {
                for (int j = 0; j<5*n; j+=1)
                {
                    if (j < n || j >= 4 * n)
                    {
                        Console.Write(".");
                    }else
                    {
                        Console.Write("*");
                    }
                }
                Console.WriteLine();
            }
            for (int i = 0; i < n-1; i += 1)
            {
                for (int j = 0; j < 5 * n; j += 1)
                {
                    if ((j==n-i-1)||(j==4*n+i))
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
            }
            for (int i = 0; i < 1; i += 1)
            {
                for (int j = 0; j < 5 * n; j += 1)
                {
                    
                        Console.Write("*");
                }
                Console.WriteLine();
            }
            for (int i = 0; i <= n*2; i += 1)
            {
                for (int j = 0; j < 5 * n; j += 1)
                {
                    if ((j == i+1) || (j == 5 * n - i-2)|| ((i == n * 2) && ((j > i + 1) && (j < 5 * n - i - 2))))
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                
                }
                Console.WriteLine();
            }


        }
    }
}
